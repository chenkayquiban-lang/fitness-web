<?php
require_once '../config/database.php';

if (!function_exists('e')) {
    function e($value) {
        return htmlspecialchars($value ?? '', ENT_QUOTES, 'UTF-8');
    }
}

$members = $pdo->query("
    SELECT member_id, full_name
    FROM members
    ORDER BY full_name
")->fetchAll();

if ($_SERVER['REQUEST_METHOD'] === 'POST') {

    $stmt = $pdo->prepare("
        INSERT INTO workout_plans
        (
            member_id,
            plan_name,
            description,
            difficulty_level,
            assigned_date
        )
        VALUES (?, ?, ?, ?, ?)
    ");

    $stmt->execute([
        $_POST['member_id'],
        $_POST['plan_name'],
        $_POST['description'],
        $_POST['difficulty_level'],
        $_POST['assigned_date']
    ]);

    header('Location: index.php');
    exit;
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<title>Add Workout Plan - FitHealth</title>
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
.topbar{margin-bottom:30px}
.topbar h1{font-size:32px;color:#111827}
.card{background:white;padding:25px;border-radius:20px;box-shadow:0 10px 25px rgba(0,0,0,.06)}
.form-grid{display:grid;grid-template-columns:repeat(auto-fit,minmax(220px,1fr));gap:18px}
label{display:block;font-weight:bold;margin-bottom:8px;color:#374151}
input,select,textarea{width:100%;padding:12px;border:1px solid #d1d5db;border-radius:10px;font-size:14px}
textarea{min-height:120px;margin-top:8px}
.form-actions{margin-top:20px;display:flex;gap:10px}
.btn{display:inline-block;background:#16a34a;color:white;padding:12px 16px;border-radius:10px;text-decoration:none;font-weight:bold;border:0;cursor:pointer}
.btn:hover{background:#15803d}
.secondary{background:#64748b}
.secondary:hover{background:#475569}
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
    <a href="../goals/index.php">Fitness Goals</a>
    <a href="index.php" class="active">Workout Plans</a>
    <a href="../reports/index.php">Reports</a>
</aside>

<main class="main">

<div class="topbar">
    <h1>Add Workout Plan</h1>
</div>

<div class="card">

<form method="post">

<div class="form-grid">

    <div>
        <label>Member</label>
        <select name="member_id" required>
            <option value="">Select member</option>
            <?php foreach ($members as $m): ?>
                <option value="<?= e($m['member_id']) ?>">
                    <?= e($m['full_name']) ?>
                </option>
            <?php endforeach; ?>
        </select>
    </div>

    <div>
        <label>Plan Name</label>
        <select name="plan_name" required>
            <option value="Cardio">Cardio</option>
            <option value="Strength Training">Strength Training</option>
            <option value="Weight Loss Program">Weight Loss Program</option>
            <option value="Beginner Workout">Beginner Workout</option>
            <option value="Advanced Workout">Advanced Workout</option>
        </select>
    </div>

    <div>
        <label>Difficulty</label>
        <select name="difficulty_level" required>
            <option value="Beginner">Beginner</option>
            <option value="Intermediate">Intermediate</option>
            <option value="Advanced">Advanced</option>
        </select>
    </div>

    <div>
        <label>Assigned Date</label>
        <input type="date" name="assigned_date" value="<?= date('Y-m-d') ?>" required>
    </div>

</div>

<label style="margin-top:18px;">Description</label>
<textarea 
    name="description"
    placeholder="Example: 30 minutes treadmill, squats, push-ups, stretching."
></textarea>

<div class="form-actions">
    <button class="btn" type="submit">Save Plan</button>
    <a class="btn secondary" href="index.php">Cancel</a>
</div>

</form>

</div>

</main>
</div>

</body>
</html>