<?php
require_once '../config/database.php';

if (!function_exists('e')) {
    function e($value) {
        return htmlspecialchars($value ?? '', ENT_QUOTES, 'UTF-8');
    }
}

$records = $pdo->query("
    SELECT hr.*, m.full_name
    FROM health_records hr
    JOIN members m ON m.member_id = hr.member_id
    ORDER BY hr.date_checked DESC, hr.record_id DESC
")->fetchAll();
?>

<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<title>Health Records - FitHealth</title>
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
table{width:100%;border-collapse:collapse;min-width:1100px}
th{background:#f0fdf4;color:#166534;text-align:left;padding:14px}
td{padding:14px;border-bottom:1px solid #e5e7eb}
tr:hover{background:#f9fafb}
.badge{padding:6px 10px;border-radius:999px;font-size:12px;font-weight:bold}
.normal{background:#dcfce7;color:#166534}
.warning{background:#fef3c7;color:#92400e}
.danger-badge{background:#fee2e2;color:#991b1b}
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
    <a href="index.php" class="active">Health Records</a>
    <a href="../goals/index.php">Fitness Goals</a>
    <a href="../workouts/index.php">Workout Plans</a>
    <a href="../reports/index.php">Reports</a>
</aside>

<main class="main">

<div class="topbar">
    <h1>Health Records</h1>
    <a class="btn" href="add.php">+ Add Record</a>
</div>

<div class="card">

<div class="table-wrapper">

<table>

<tr>
    <th>Member</th>
    <th>Height</th>
    <th>Weight</th>
    <th>BMI</th>
    <th>Category</th>
    <th>Blood Pressure</th>
    <th>Status</th>
    <th>Heart Rate</th>
    <th>Date</th>
    <th>Action</th>
</tr>

<?php if (!empty($records)): ?>

<?php foreach ($records as $r): ?>

<?php
$class = 'normal';

if (
    stripos($r['bmi_category'], 'Overweight') !== false ||
    stripos($r['bp_status'], 'High') !== false
) {
    $class = 'warning';
}

if (
    stripos($r['bmi_category'], 'Obese') !== false ||
    stripos($r['bp_status'], 'Stage') !== false
) {
    $class = 'danger-badge';
}
?>

<tr>

<td><?= e($r['full_name']) ?></td>

<td><?= e($r['height']) ?> m</td>

<td><?= e($r['weight']) ?> kg</td>

<td><?= e($r['bmi']) ?></td>

<td>
<span class="badge <?= $class ?>">
<?= e($r['bmi_category']) ?>
</span>
</td>

<td>
<?= e($r['systolic']) ?>/<?= e($r['diastolic']) ?>
</td>

<td>
<span class="badge <?= $class ?>">
<?= e($r['bp_status']) ?>
</span>
</td>

<td><?= e($r['heart_rate']) ?></td>

<td><?= e($r['date_checked']) ?></td>

<td>
<a
class="btn danger"
onclick="return confirm('Delete this record?')"
href="delete.php?id=<?= e($r['record_id']) ?>"
>
Delete
</a>
</td>

</tr>

<?php endforeach; ?>

<?php else: ?>

<tr>
<td colspan="10" class="empty">
No health records found.
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