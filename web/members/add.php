<?php
require_once '../config/database.php';

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $stmt = $pdo->prepare("
        INSERT INTO members 
        (full_name, age, gender, contact_number, address, membership_type, date_registered) 
        VALUES (?, ?, ?, ?, ?, ?, ?)
    ");

    $stmt->execute([
        $_POST['full_name'],
        $_POST['age'],
        $_POST['gender'],
        $_POST['contact_number'],
        $_POST['address'],
        $_POST['membership_type'],
        $_POST['date_registered']
    ]);

    header('Location: index.php');
    exit;
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<title>Add Member - FitHealth</title>
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
textarea{min-height:100px;margin-top:8px}
.form-actions{margin-top:20px;display:flex;gap:10px}
.btn{display:inline-block;background:#16a34a;color:white;padding:12px 16px;border-radius:10px;text-decoration:none;font-weight:bold;border:0;cursor:pointer}
.secondary{background:#64748b}
@media(max-width:768px){.sidebar{position:relative;width:100%;height:auto}.layout{flex-direction:column}.main{margin-left:0;width:100%;padding:20px}}
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
    <a href="../workout_plans/index.php">Workout Plans</a>
    <a href="../reports/index.php">Reports</a>
</aside>

<main class="main">
    <div class="topbar">
        <h1>Add Member</h1>
    </div>

    <div class="card">
        <form method="post">
            <div class="form-grid">
                <div>
                    <label>Full Name</label>
                    <input name="full_name" required>
                </div>

                <div>
                    <label>Age</label>
                    <input type="number" name="age" required>
                </div>

                <div>
                    <label>Gender</label>
                    <select name="gender">
                        <option>Male</option>
                        <option>Female</option>
                        <option>Other</option>
                    </select>
                </div>

                <div>
                    <label>Contact Number</label>
                    <input name="contact_number">
                </div>

                <div>
                    <label>Membership Type</label>
                    <select name="membership_type">
                        <option>Regular</option>
                        <option>Premium</option>
                        <option>Student</option>
                    </select>
                </div>

                <div>
                    <label>Date Registered</label>
                    <input type="date" name="date_registered" value="<?= date('Y-m-d') ?>">
                </div>
            </div>

            <label style="margin-top:18px;">Address</label>
            <textarea name="address"></textarea>

            <div class="form-actions">
                <button class="btn" type="submit">Save Member</button>
                <a class="btn secondary" href="index.php">Cancel</a>
            </div>
        </form>
    </div>
</main>
</div>

</body>
</html>