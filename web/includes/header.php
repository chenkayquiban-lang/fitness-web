<?php require_once __DIR__ . '/functions.php'; ?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Fitness and Health Monitoring System</title>
    <link rel="stylesheet" href="/fitness_health_system/assets/css/style.css">
</head>
<body>
<div class="layout">
    <aside class="sidebar">
        <h2>FitHealth</h2>
        <a href="/fitness_health_system/index.php">Dashboard</a>
        <a href="/fitness_health_system/members/index.php">Members</a>
        <a href="/fitness_health_system/health/index.php">Health Records</a>
        <a href="/fitness_health_system/goals/index.php">Fitness Goals</a>
        <a href="/fitness_health_system/workouts/index.php">Workout Plans</a>
        <a href="/fitness_health_system/reports/index.php">Reports</a>
    </aside>
    <main class="content">

   // added a new reports page to display BMI and blood pressure summaries, as well as a member health overview with diet recommendations based on their latest BMI category. This provides a comprehensive view of the overall health status of the members and helps in making informed decisions for fitness plans and goals. The report can be printed directly from the page for offline use.
    // also added auto-refresh functionality to list pages (members, health records, goals) with a badge indicator, refreshing every 1 seconds if the user is not actively typing in an input field. This ensures that the latest data is displayed without disrupting user input.
    // also updated members list to include edit and delete options, as well as add health option for members
    // updated health add feature with member selection and automatic BMI and blood pressure status calculation based on inputs
    // enhanced the form layout for better user experience in health add page
    // updated goals add feature with member selection and improved form layout
    // updated index page to display latest health records with BMI, blood pressure, and date checked