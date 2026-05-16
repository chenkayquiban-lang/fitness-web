<?php
require_once '../config/database.php';

if (!function_exists('e')) {
    function e($value) {
        return htmlspecialchars($value ?? '', ENT_QUOTES, 'UTF-8');
    }
}

$members = $pdo->query("SELECT * FROM members ORDER BY member_id DESC")->fetchAll();
?>

<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<title>Members - FitHealth</title>
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
.topbar h1{font-size:32px;color:#111827}
.btn{display:inline-block;background:#16a34a;color:white;padding:10px 14px;border-radius:10px;text-decoration:none;font-weight:bold;border:0;cursor:pointer}
.btn:hover{background:#15803d}
.secondary{background:#64748b}
.secondary:hover{background:#475569}
.danger{background:#dc2626}
.danger:hover{background:#b91c1c}
.card{background:white;padding:25px;border-radius:20px;box-shadow:0 10px 25px rgba(0,0,0,.06)}
.table-wrapper{overflow-x:auto}
table{width:100%;border-collapse:collapse;min-width:900px}
th{background:#f0fdf4;color:#166534;text-align:left;padding:14px;font-size:14px}
td{padding:14px;border-bottom:1px solid #e5e7eb;font-size:14px}
tr:hover{background:#f9fafb}
.actions{display:flex;gap:8px;flex-wrap:wrap}
.empty{text-align:center;color:#6b7280;padding:25px}
@media(max-width:768px){.sidebar{position:relative;width:100%;height:auto}.layout{flex-direction:column}.main{margin-left:0;width:100%;padding:20px}.topbar{flex-direction:column;align-items:flex-start;gap:15px}}
</style>
</head>
<body>

<div class="layout">
<aside class="sidebar">
    <h2>FitHealth</h2>
    <a href="../index.php">Dashboard</a>
    <a href="index.php" class="active">Members</a>
    <a href="../health/index.php">Health Records</a>
    <a href="../goals/index.php">Fitness Goals</a>
    <a href="../workouts/index.php">Workout Plans</a>
    <a href="../reports/index.php">Reports</a>
</aside>

<main class="main">
    <div class="topbar">
        <h1>Members</h1>
        <a class="btn" href="add.php">+ Add Member</a>
    </div>

    <div class="card">
        <div class="table-wrapper">
            <table>
                <tr>
                    <th>Name</th>
                    <th>Age</th>
                    <th>Gender</th>
                    <th>Contact</th>
                    <th>Membership</th>
                    <th>Date</th>
                    <th>Actions</th>
                </tr>

                <?php if (!empty($members)): ?>
                    <?php foreach ($members as $m): ?>
                        <tr>
                            <td><?= e($m['full_name']) ?></td>
                            <td><?= e($m['age']) ?></td>
                            <td><?= e($m['gender']) ?></td>
                            <td><?= e($m['contact_number']) ?></td>
                            <td><?= e($m['membership_type']) ?></td>
                            <td><?= e($m['date_registered']) ?></td>
                            <td class="actions">
                                <a class="btn secondary" href="edit.php?id=<?= e($m['member_id']) ?>">Edit</a>
                                <a class="btn" href="../health/add.php?member_id=<?= e($m['member_id']) ?>">Add Health</a>
                                <a class="btn danger" onclick="return confirm('Delete this member?')" href="delete.php?id=<?= e($m['member_id']) ?>">Delete</a>
                            </td>
                        </tr>
                    <?php endforeach; ?>
                <?php else: ?>
                    <tr>
                        <td colspan="7" class="empty">No members found.</td>
                    </tr>
                <?php endif; ?>
            </table>
        </div>
    </div>
</main>
</div>

</body>
</html>