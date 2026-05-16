<?php
require_once '../config/database.php';

$id = $_GET['id'] ?? 0;

if ($id) {
    $stmt = $pdo->prepare("
        DELETE FROM workout_plans
        WHERE plan_id = ?
    ");

    $stmt->execute([$id]);
}

header('Location: index.php');
exit;