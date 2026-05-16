<?php
require '../config/database.php';
require_once '../config/auth.php';
require_role('user');

$uid = (int)($_SESSION['user_id'] ?? 0);
$db_error = '';

function q_or_error($conn, $sql, &$db_error) {
    $res = mysqli_query($conn, $sql);
    if (!$res) { $db_error = mysqli_error($conn); }
    return $res;
}

$member_id = 0;
$m = null;
$res = q_or_error($conn, "SELECT * FROM members WHERE user_id=$uid LIMIT 1", $db_error);
if ($res) { $m = mysqli_fetch_assoc($res); }

if (!$db_error && !$m && $uid > 0) {
    $name = mysqli_real_escape_string($conn, $_SESSION['full_name'] ?? 'FitLife User');
    mysqli_query($conn, "INSERT INTO members(user_id,phone,address,gender,birthday,height_cm,weight_kg,goal,level_points) VALUES($uid,'','','','2000-01-01',170,70,'Fitness Goal',0)");
    $res = q_or_error($conn, "SELECT * FROM members WHERE user_id=$uid LIMIT 1", $db_error);
    if ($res) { $m = mysqli_fetch_assoc($res); }
}

if ($m) { $member_id = (int)$m['id']; }

$labels=[]; $cal=[]; $wt=[]; $steps=0; $streak=0; $health=null;
if (!$db_error && $member_id > 0) {
    $logs = q_or_error($conn, "SELECT * FROM activity_logs WHERE member_id=$member_id ORDER BY log_date DESC LIMIT 7", $db_error);
    if ($logs) {
        $rows=[];
        while($r=mysqli_fetch_assoc($logs)){ $rows[]=$r; }
        $rows=array_reverse($rows);
        foreach($rows as $r){
            $labels[]=$r['log_date'] ?? '';
            $cal[]=(int)($r['calories_burned'] ?? 0);
            $wt[]=(float)($r['weight_kg'] ?? 0);
            $steps+=(int)($r['steps'] ?? 0);
            $streak++;
        }
    }
    if (!$db_error) {
        $hres = q_or_error($conn, "SELECT * FROM health_records WHERE member_id=$member_id ORDER BY record_date DESC LIMIT 1", $db_error);
        if ($hres) { $health=mysqli_fetch_assoc($hres); }
    }
}
?>
<!DOCTYPE html>
<html>
<head>
    <title>Member Dashboard</title>
    <link rel="stylesheet" href="../assets/css/style.css">
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
</head>
<body>
<div class="layout">
    <?php include '_nav.php'; ?>
    <main class="main">
        <div class="header">
            <h1>Interactive Progress Dashboard</h1>
            <span class="badge">Level <?=floor((int)($m['level_points']??0)/100)+1?> • <?=e($m['level_points']??0)?> XP</span>
        </div>

        <?php if($db_error): ?>
            <div class="card" style="border-left:6px solid #ef4444">
                <h2>Database needs reset/import</h2>
                <p>The dashboard cannot read the current database schema.</p>
                <p><b>MySQL error:</b> <?=e($db_error)?></p>
                <p>Open phpMyAdmin, drop/delete <b>fitlife_db</b>, then import:</p>
                <code>web/database/RESET_AND_IMPORT_fitlife_db.sql</code>
            </div>
        <?php else: ?>
            <div class="stat-grid">
                <div class="stat"><span>Steps</span><h2><?=number_format($steps)?></h2></div>
                <div class="stat"><span>Workout Streak</span><h2><?=$streak?> days</h2></div>
                <div class="stat"><span>Current Weight</span><h2><?=e($m['weight_kg']??'0')?> kg</h2></div>
                <div class="stat"><span>BP Status</span><h2 style="font-size:20px"><?=e($health['status']??'No data')?></h2></div>
            </div>
            <div class="grid" style="padding:24px 0">
                <div class="card chart-card" style="grid-column:span 2"><h2>Calories Burned</h2><canvas id="cal"></canvas></div>
                <div class="card chart-card" style="grid-column:span 2"><h2>Weight Changes</h2><canvas id="wt"></canvas></div>
            </div>
            <div class="grid" style="padding:0">
                <div class="card"><div class="icon">Badges</div><h3>Badges</h3><p><span class="badge">Starter</span> <span class="badge warn">7-Day Streak</span></p></div>
                <div class="card"><div class="icon">Tip</div><h3>Personalized Tip</h3><p><?=($steps<5000)?'Try a 20-minute walk today to boost your step count.':'Great activity! Add protein-rich meals for better recovery.'?></p></div>
                <div class="card"><div class="icon">Goal</div><h3>Goal</h3><p><?=e($m['goal']??'Fitness Goal')?> • Keep consistent and update your records weekly.</p></div>
                <div class="card"><div class="icon">Health</div><h3>Health Reminder</h3><p>Record blood pressure, sugar, and temperature regularly.</p></div>
            </div>
            <script>
            new Chart(document.getElementById('cal'),{type:'line',data:{labels:<?=json_encode($labels)?>,datasets:[{label:'Calories',data:<?=json_encode($cal)?>,tension:.4}]},options:{animation:{duration:900}}});
            new Chart(document.getElementById('wt'),{type:'bar',data:{labels:<?=json_encode($labels)?>,datasets:[{label:'Weight kg',data:<?=json_encode($wt)?>}]},options:{animation:{duration:900}}});
            </script>
        <?php endif; ?>
    </main>
</div>
</body>
</html>
