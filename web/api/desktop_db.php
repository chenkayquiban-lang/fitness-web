<?php
// Desktop-to-web database API for FitLife
// Upload this file to: web/api/desktop_db.php
// Then set DesktopApiUrl in desktop/FitLifeDesktopApp/Database.cs

header('Content-Type: application/json');
require_once __DIR__ . '/../config/database.php';

$API_TOKEN = 'fitlife_desktop_sync_2026';

function out($data, $code = 200) {
    http_response_code($code);
    echo json_encode($data);
    exit;
}

$raw = file_get_contents('php://input');
$data = json_decode($raw, true);
if (!$data) out(['ok' => false, 'error' => 'Invalid JSON'], 400);
if (($data['token'] ?? '') !== $API_TOKEN) out(['ok' => false, 'error' => 'Unauthorized'], 401);

$action = $data['action'] ?? '';
$sql = trim($data['sql'] ?? '');
$params = $data['params'] ?? [];

if ($sql === '') out(['ok' => false, 'error' => 'Missing SQL'], 400);

// Basic safety: this desktop app only needs normal CRUD.
$blocked = ['DROP ', 'TRUNCATE ', 'ALTER ', 'CREATE ', 'GRANT ', 'REVOKE ', 'LOAD_FILE', 'INTO OUTFILE'];
$upper = strtoupper($sql);
foreach ($blocked as $b) {
    if (strpos($upper, $b) !== false) out(['ok' => false, 'error' => 'Blocked SQL command'], 400);
}

uksort($params, function($a, $b) { return strlen($b) - strlen($a); });
foreach ($params as $name => $value) {
    if ($value === null || $value === '') {
        $replacement = 'NULL';
    } elseif (is_numeric($value) && !preg_match('/^0[0-9]+/', (string)$value)) {
        $replacement = (string)$value;
    } else {
        $replacement = "'" . mysqli_real_escape_string($conn, (string)$value) . "'";
    }
    $sql = str_replace($name, $replacement, $sql);
}

$result = mysqli_query($conn, $sql);
if (!$result) out(['ok' => false, 'error' => mysqli_error($conn), 'sql' => $sql], 500);

if ($action === 'query') {
    $rows = [];
    while ($row = mysqli_fetch_assoc($result)) $rows[] = $row;
    out(['ok' => true, 'rows' => $rows]);
}

if ($action === 'scalar') {
    $row = mysqli_fetch_row($result);
    out(['ok' => true, 'value' => $row ? $row[0] : null]);
}

out(['ok' => true, 'affected' => mysqli_affected_rows($conn), 'last_insert_id' => mysqli_insert_id($conn)]);
