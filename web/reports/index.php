<?php
require_once '../config/database.php';

/*
|--------------------------------------------------------------------------
| HELPER FUNCTIONS
|--------------------------------------------------------------------------
*/
if (!function_exists('e')) {
    function e($value) {
        return htmlspecialchars($value ?? '', ENT_QUOTES, 'UTF-8');
    }
}

function diet_recommendation($category)
{
    switch ($category) {

        case 'Underweight':
            return 'Increase calorie intake with healthy proteins and carbohydrates.';

        case 'Normal':
            return 'Maintain a balanced diet with fruits, vegetables, and protein.';

        case 'Overweight':
            return 'Reduce sugary foods and increase physical activity.';

        case 'Obese':
            return 'Follow a low-fat diet and consult a nutrition specialist.';

        default:
            return 'No recommendation available.';
    }
}

/*
|--------------------------------------------------------------------------
| MEMBER HEALTH OVERVIEW
|--------------------------------------------------------------------------
*/
$members = $pdo->query("
    SELECT 
        m.*,

        (
            SELECT bmi_category
            FROM health_records hr
            WHERE hr.member_id = m.member_id
            ORDER BY hr.date_checked DESC, hr.record_id DESC
            LIMIT 1
        ) AS latest_bmi_category,

        (
            SELECT bmi
            FROM health_records hr
            WHERE hr.member_id = m.member_id
            ORDER BY hr.date_checked DESC, hr.record_id DESC
            LIMIT 1
        ) AS latest_bmi,

        (
            SELECT bp_status
            FROM health_records hr
            WHERE hr.member_id = m.member_id
            ORDER BY hr.date_checked DESC, hr.record_id DESC
            LIMIT 1
        ) AS latest_bp

    FROM members m
    ORDER BY m.full_name
")->fetchAll();

/*
|--------------------------------------------------------------------------
| BLOOD PRESSURE SUMMARY
|--------------------------------------------------------------------------
*/
$bp = $pdo->query("
    SELECT 
        bp_status,
        COUNT(*) AS total
    FROM health_records
    GROUP BY bp_status
")->fetchAll();

/*
|--------------------------------------------------------------------------
| BMI SUMMARY
|--------------------------------------------------------------------------
*/
$bmi = $pdo->query("
    SELECT 
        bmi_category,
        COUNT(*) AS total
    FROM health_records
    GROUP BY bmi_category
")->fetchAll();
?>

<!DOCTYPE html>
<html lang="en">
<head>

<meta charset="UTF-8">
<title>Reports - FitHealth</title>
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

/* LAYOUT */

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

/* BUTTON */

.btn{
    background:#16a34a;
    color:white;
    padding:12px 18px;
    border-radius:12px;
    text-decoration:none;
    font-weight:bold;
    border:none;
    cursor:pointer;
    box-shadow:0 8px 18px rgba(22,163,74,.25);
}

.btn:hover{
    background:#15803d;
}

/* GRID */

.grid{
    display:grid;
    grid-template-columns:repeat(auto-fit,minmax(320px,1fr));
    gap:20px;
    margin-bottom:30px;
}

/* CARD */

.card{
    background:white;
    padding:25px;
    border-radius:20px;
    box-shadow:0 10px 25px rgba(0,0,0,.06);
    margin-bottom:30px;
}

.card h2{
    margin-bottom:20px;
    font-size:24px;
}

/* TABLE */

.table-wrapper{
    overflow-x:auto;
}

table{
    width:100%;
    border-collapse:collapse;
    min-width:700px;
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
    display:inline-block;
}

.normal{
    background:#dcfce7;
    color:#166534;
}

.warning{
    background:#fef3c7;
    color:#92400e;
}

.danger{
    background:#fee2e2;
    color:#991b1b;
}

.none{
    background:#e5e7eb;
    color:#374151;
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

/* PRINT */

@media print{

    .sidebar,
    .btn{
        display:none;
    }

    .main{
        margin-left:0;
        width:100%;
        padding:0;
    }

    body{
        background:white;
    }

    .card{
        box-shadow:none;
        border:1px solid #ddd;
    }
}

</style>
</head>

<body>

<div class="layout">

    <!-- SIDEBAR -->

    <aside class="sidebar">

        <h2>FitHealth</h2>

        <a href="../index.php">
            Dashboard
        </a>

        <a href="../members/index.php">
            Members
        </a>

        <a href="../health/index.php">
            Health Records
        </a>

        <a href="../goals/index.php">
            Fitness Goals
        </a>

        <a href="../workouts/index.php">
            Workout Plans
        </a>

        <a href="../reports/index.php" class="active">
            Reports
        </a>

    </aside>

    <!-- MAIN -->

    <main class="main">

        <div class="topbar">

            <h1>Reports</h1>

            <button class="btn" onclick="window.print()">
                Print Report
            </button>

        </div>

        <!-- SUMMARY -->

        <div class="grid">

            <!-- BMI -->

            <div class="card">

                <h2>BMI Summary</h2>

                <div class="table-wrapper">

                    <table>

                        <tr>
                            <th>Category</th>
                            <th>Total</th>
                        </tr>

                        <?php foreach ($bmi as $row): ?>

                            <tr>
                                <td><?= e($row['bmi_category']) ?></td>
                                <td><?= e($row['total']) ?></td>
                            </tr>

                        <?php endforeach; ?>

                    </table>

                </div>

            </div>

            <!-- BLOOD PRESSURE -->

            <div class="card">

                <h2>Blood Pressure Summary</h2>

                <div class="table-wrapper">

                    <table>

                        <tr>
                            <th>Status</th>
                            <th>Total</th>
                        </tr>

                        <?php foreach ($bp as $row): ?>

                            <tr>
                                <td><?= e($row['bp_status']) ?></td>
                                <td><?= e($row['total']) ?></td>
                            </tr>

                        <?php endforeach; ?>

                    </table>

                </div>

            </div>

        </div>

        <!-- MEMBER OVERVIEW -->

        <div class="card">

            <h2>
                Member Health Overview and Diet Recommendation
            </h2>

            <div class="table-wrapper">

                <table>

                    <tr>
                        <th>Member</th>
                        <th>Latest BMI</th>
                        <th>BMI Category</th>
                        <th>Latest BP Status</th>
                        <th>Diet Recommendation</th>
                    </tr>

                    <?php foreach ($members as $m): ?>

                        <?php
                        $bmiClass = 'none';

                        if ($m['latest_bmi_category']) {

                            $bmiClass = 'normal';

                            if (
                                stripos($m['latest_bmi_category'], 'Overweight') !== false
                            ) {
                                $bmiClass = 'warning';
                            }

                            if (
                                stripos($m['latest_bmi_category'], 'Obese') !== false
                            ) {
                                $bmiClass = 'danger';
                            }
                        }
                        ?>

                        <tr>

                            <td><?= e($m['full_name']) ?></td>

                            <td><?= e($m['latest_bmi'] ?: 'No record') ?></td>

                            <td>

                                <span class="badge <?= e($bmiClass) ?>">

                                    <?= e($m['latest_bmi_category'] ?: 'No record') ?>

                                </span>

                            </td>

                            <td><?= e($m['latest_bp'] ?: 'No record') ?></td>

                            <td>
                                <?= e(diet_recommendation($m['latest_bmi_category'])) ?>
                            </td>

                        </tr>

                    <?php endforeach; ?>

                </table>

            </div>

        </div>

    </main>

</div>

</body>
</html>