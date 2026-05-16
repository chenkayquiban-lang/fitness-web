<?php
require_once '../config/database.php';

if (!function_exists('e')) {
    function e($value) {
        return htmlspecialchars($value ?? '', ENT_QUOTES, 'UTF-8');
    }
}

$goals = $pdo->query("
    SELECT g.*, m.full_name
    FROM fitness_goals g
    JOIN members m ON m.member_id = g.member_id
    ORDER BY g.goal_id DESC
")->fetchAll();
?>

<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<title>Fitness Goals - FitHealth</title>
<meta name="viewport" content="width=device-width, initial-scale=1.0">

<style>
*{box-sizing:border-box;margin:0;padding:0;font-family:Arial,sans-serif}
body{background:#f4f7fb;color:#1f2937}
.layout{display:flex;min-height:100vh}
.sidebar{width:250px;background:linear-gradient(180deg,#16a34a,#15803d);color:white;padding:25px 20px;position:fixed;height:100vh}
.sidebar h2{margin-bottom:35px;font-size:26px}
.sidebar a{display:block;color:white;text-decoration:none;padding:13px 15px;border-radius:12px;margin-bottom:10px;font-weight:600}
.sidebar a:hover,.sidebar a.active{background:rgba(255,255,255,.18)}
.main{margin-left:250px;width:calc(100% - 250px);padding:35px}
.topbar{display:flex;justify-content:space-between;align-items:center;margin-bottom:30px}
.topbar h1{font-size:32px}
.btn{display:inline-block;background:#16a34a;color:white;padding:10px 14px;border-radius:10px;text-decoration:none;font-weight:bold}
.btn:hover{background:#15803d}
.danger{background:#dc2626}
.danger:hover{background:#b91c1c}
.card{background:white;padding:25px;border-radius:20px;box-shadow:0 10px 25px rgba(0,0,0,.06)}
.table-wrapper{overflow-x:auto}
table{width:100%;border-collapse:collapse;min-width:1000px}
th{background:#f0fdf4;color:#166534;text-align:left;padding:14px}
td{padding:14px;border-bottom:1px solid #e5e7eb}
tr:hover{background:#f9fafb}
.badge{padding:6px 10px;border-radius:999px;font-size:12px;font-weight:bold}
.ongoing{background:#fef3c7;color:#92400e}
.completed{background:#dcfce7;color:#166534}
.cancelled{background:#fee2e2;color:#991b1b}
.empty{text-align:center;color:#6b7280;padding:25px}
@media(max-width:768px){.sidebar{position:relative;width:100%;height:auto}.layout{flex-direction:column}.main{margin-left:0;width:100%;padding:20px}}
</style>
</head>

<body>

<div class="layout">

<aside class="sidebar">
    <h2>FitHealth</h2>

    <a href="../index.php">Dashboard</a>
    <a href="../members/index.php">Members</a>
    <a href="../health/index.php">Health Records</a>
    <a href="index.php" class="active">Fitness Goals</a>
    <a href="../workout_plans/index.php">Workout Plans</a>
    <a href="../reports/index.php">Reports</a>
</aside>

<main class="main">

<div class="topbar">
    <h1>Fitness Goals</h1>
    <a class="btn" href="add.php">+ Add Goal</a>
</div>

<div class="card">

<div class="table-wrapper">

<table>

<tr>
    <th>Member</th>
    <th>Goal Type</th>
    <th>Target Weight</th>
    <th>Target Date</th>
    <th>Status</th>
    <th>Notes</th>
    <th>Action</th>
</tr>

<?php if (!empty($goals)): ?>

<?php foreach ($goals as $g): ?>

<?php
$class = 'ongoing';

if ($g['status'] == 'Completed') {
    $class = 'completed';
}

if ($g['status'] == 'Cancelled') {
    $class = 'cancelled';
}
?>

<tr>

<td><?= e($g['full_name']) ?></td>

<td><?= e($g['goal_type']) ?></td>

<td><?= e($g['target_weight']) ?> kg</td>

<td><?= e($g['target_date']) ?></td>

<td>
<span class="badge <?= $class ?>">
<?= e($g['status']) ?>
</span>
</td>

<td><?= e($g['notes']) ?></td>

<td>
<a
class="btn danger"
onclick="return confirm('Delete this goal?')"
href="delete.php?id=<?= e($g['goal_id']) ?>"
>
Delete
</a>
</td>

</tr>

<?php endforeach; ?>

<?php else: ?>

<tr>
<td colspan="7" class="empty">
No goals found.
</td>
</tr>

<?php endif; ?>

</table>

</div>
</div>

</main>
</div>

</body>
</html>