<?php
require_once 'config/auth.php';
if(isset($_SESSION['user_id']) && isset($_SESSION['role'])){
    redirect_to_role_dashboard($_SESSION['role']);
}
?>
<!DOCTYPE html><html><head><title>FitLife System</title><meta name="viewport" content="width=device-width,initial-scale=1"><link rel="stylesheet" href="assets/css/style.css"></head><body>
<div class="topbar"><a class="brand">FitLife</a><div class="nav"><a href="login.php">Login</a><a class="btn" href="register.php">Register</a></div></div>
<section class="hero"><div><span class="pill">Fitness • Health • Gym Management</span><h1>One modern system for gym membership, fitness tracking, meals, classes, and health records.</h1><p>Built using PHP, MySQL, HTML, CSS, JavaScript, and Chart.js. Manage members, subscriptions, trainers, workouts, meal plans, blood pressure, BMI, goals, and community wellness.</p><a class="btn orange" href="register.php">Start Now</a> <a class="btn light" href="login.php">Member Login</a></div><div class="hero-card glass"><h2>Health Score</h2><div class="ring"><div>86%</div></div><p><b>Today:</b> 7,200 steps • 320 calories • Normal BP</p></div></section>
<section class="features"><div class="card"><div class="icon">🏋️</div><h3>Gym Membership</h3><p>Profiles, plans, payments, invoices, trainer schedules.</p></div><div class="card"><div class="icon">📈</div><h3>Fitness Tracker</h3><p>BMI, body goals, daily activity logs, Chart.js progress.</p></div><div class="card"><div class="icon">🥗</div><h3>Diet Planner</h3><p>Recipes, calories, macros, weekly meal planner.</p></div><div class="card"><div class="icon">🩺</div><h3>Medical Records</h3><p>Blood pressure, heart rate, sugar, temperature status.</p></div></section>
</body></html>
