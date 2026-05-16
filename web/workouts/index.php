<?php
require_once '../config/database.php';

if (!function_exists('e')) {
    function e($value) {
        return htmlspecialchars($value ?? '', ENT_QUOTES, 'UTF-8');
    }
}

$plans = $pdo->query("
    SELECT w.*, m.full_name
    FROM workout_plans w
    JOIN members m ON m.member_id = w.member_id
    ORDER BY w.plan_id DESC
")->fetchAll();
?>

<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<title>Workout Plans - FitHealth</title>
<meta name="viewport" content="width=device-width, initial-scale=1.0">

<style>

*{
    box-sizing:border-box;
    margin:0;
    padding:0;
    font-family:Arial,sans-serif;
}

body{
    background:#f4f7fb;
    color:#1f2937;
}

.layout{
    display:flex;
    min-height:100vh;
}

/* SIDEBAR */

.sidebar{
    width:250px;
    background:linear-gradient(180deg,#16a34a,#15803d);
    color:white;
    padding:25px 20px;
    position:fixed;
    height:100vh;
}

.sidebar h2{
    margin-bottom:35px;
    font-size:26px;
}

.sidebar a{
    display:block;
    color:white;
    text-decoration:none;
    padding:13px 15px;
    border-radius:12px;
    margin-bottom:10px;
    font-weight:600;
    transition:.2s;
}

.sidebar a:hover,
.sidebar a.active{
    background:rgba(255,255,255,.18);
}

/* MAIN */

.main{
    margin-left:250px;
    width:calc(100% - 250px);
    padding:35px;
}

/* TOPBAR */

.topbar{
    display:flex;
    justify-content:space-between;
    align-items:center;
    margin-bottom:30px;
}

.topbar h1{
    font-size:32px;
    color:#111827;
}

/* BUTTONS */

.btn{
    display:inline-block;
    background:#16a34a;
    color:white;
    padding:10px 14px;
    border-radius:10px;
    text-decoration:none;
    font-weight:bold;
    transition:.2s;
}

.btn:hover{
    background:#15803d;
}

.danger{
    background:#dc2626;
}

.danger:hover{
    background:#b91c1c;
}

/* CARD */

.card{
    background:white;
    padding:25px;
    border-radius:20px;
    box-shadow:0 10px 25px rgba(0,0,0,.06);
}

/* TABLE */

.table-wrapper{
    overflow-x:auto;
}

table{
    width:100%;
    border-collapse:collapse;
    min-width:950px;
}

th{
    background:#f0fdf4;
    color:#166534;
    text-align:left;
    padding:14px;
    font-size:14px;
}

td{
    padding:14px;
    border-bottom:1px solid #e5e7eb;
    font-size:14px;
}

tr:hover{
    background:#f9fafb;
}

/* BADGES */

.badge{
    padding:6px 10px;
    border-radius:999px;
    font-size:12px;
    font-weight:bold;
}

.beginner{
    background:#dcfce7;
    color:#166534;
}

.intermediate{
    background:#fef3c7;
    color:#92400e;
}

.advanced{
    background:#fee2e2;
    color:#991b1b;
}

/* EMPTY */

.empty{
    text-align:center;
    color:#6b7280;
    padding:25px;
}

/* MOBILE */

@media(max-width:768px){

    .sidebar{
        position:relative;
        width:100%;
        height:auto;
    }

    .layout{
        flex-direction:column;
    }

    .main{
        margin-left:0;
        width:100%;
        padding:20px;
    }

    .topbar{
        flex-direction:column;
        align-items:flex-start;
        gap:15px;
    }
}

</style>
</head>

<body>

<div class="layout">

    <!-- SIDEBAR -->

    <aside class="sidebar">

        <h2>FitHealth</h2>

        <a href="/index.php">
            Dashboard
        </a>

        <a href="/members/index.php">
            Members
        </a>

        <a href="/health/index.php">
            Health Records
        </a>

        <a href="/goals/index.php">
            Fitness Goals
        </a>

        <a href="/workout_plans/index.php" class="active">
            Workout Plans
        </a>

        <a href="/reports/index.php">
            Reports
        </a>

    </aside>

    <!-- MAIN -->

    <main class="main">

        <!-- TOPBAR -->

        <div class="topbar">

            <h1>Workout Plans</h1>

            <a class="btn" href="/workout_plans/add.php">
                + Add Workout Plan
            </a>

        </div>

        <!-- CARD -->

        <div class="card">

            <div class="table-wrapper">

                <table>

                    <tr>
                        <th>Member</th>
                        <th>Plan</th>
                        <th>Description</th>
                        <th>Difficulty</th>
                        <th>Assigned Date</th>
                        <th>Action</th>
                    </tr>

                    <?php if (!empty($plans)): ?>

                        <?php foreach ($plans as $p): ?>

                            <?php
                                $class = 'beginner';

                                if ($p['difficulty_level'] == 'Intermediate') {
                                    $class = 'intermediate';
                                }

                                if ($p['difficulty_level'] == 'Advanced') {
                                    $class = 'advanced';
                                }
                            ?>

                            <tr>

                                <td><?= e($p['full_name']) ?></td>

                                <td><?= e($p['plan_name']) ?></td>

                                <td><?= e($p['description']) ?></td>

                                <td>
                                    <span class="badge <?= e($class) ?>">
                                        <?= e($p['difficulty_level']) ?>
                                    </span>
                                </td>

                                <td><?= e($p['assigned_date']) ?></td>

                                <td>

                                    <a
                                        class="btn danger"
                                        onclick="return confirm('Delete this workout plan?')"
                                        href="/workout_plans/delete.php?id=<?= e($p['plan_id']) ?>"
                                    >
                                        Delete
                                    </a>

                                </td>

                            </tr>

                        <?php endforeach; ?>

                    <?php else: ?>

                        <tr>
                            <td colspan="6" class="empty">
                                No workout plans found.
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