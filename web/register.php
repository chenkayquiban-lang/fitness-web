<?php
session_start();
require 'config/database.php';

$msg = '';
$error = '';

function make_username($conn, $email) {
    $base = strtolower(trim(explode('@', $email)[0] ?? 'user'));
    $base = preg_replace('/[^a-z0-9_]/', '', $base);
    if ($base === '') $base = 'user';
    $base = substr($base, 0, 45);
    $username = $base;
    $i = 1;
    while (true) {
        $safe = mysqli_real_escape_string($conn, $username);
        $q = mysqli_query($conn, "SELECT id FROM users WHERE username='$safe' LIMIT 1");
        if (mysqli_num_rows($q) === 0) return $username;
        $username = substr($base, 0, 42) . $i;
        $i++;
    }
}

if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    $name = trim(mysqli_real_escape_string($conn, $_POST['full_name'] ?? ''));
    $email = trim(mysqli_real_escape_string($conn, $_POST['email'] ?? ''));
    $password = $_POST['password'] ?? '';
    $h = ($_POST['height'] ?? '') !== '' ? floatval($_POST['height']) : 0;
    $w = ($_POST['weight'] ?? '') !== '' ? floatval($_POST['weight']) : 0;
    $goal = trim(mysqli_real_escape_string($conn, $_POST['goal'] ?? ''));

    if ($name === '' || $email === '' || $password === '') {
        $error = 'Please complete all required fields.';
    } else {
        $check = mysqli_query($conn, "SELECT id FROM users WHERE email='$email' LIMIT 1");
        if (mysqli_num_rows($check) > 0) {
            $error = 'Email already exists.';
        } else {
            $username = make_username($conn, $email);
            $pass = md5($password);
            $ok = mysqli_query($conn, "
                INSERT INTO users(full_name,username,email,password,role,status)
                VALUES('$name','$username','$email','$pass','user','active')
            ");
            if ($ok) {
                $uid = mysqli_insert_id($conn);
                mysqli_query($conn, "INSERT INTO members(user_id,height_cm,weight_kg,goal) VALUES($uid,$h,$w,'$goal')");
                $msg = 'Account created. You can login now.';
            } else {
                $error = mysqli_error($conn);
            }
        }
    }
}
?>
<!DOCTYPE html><html><head><title>Register</title><meta name="viewport" content="width=device-width,initial-scale=1"><link rel="stylesheet" href="assets/css/style.css"><script src="assets/js/app.js"></script></head><body class="auth"><form class="form" method="post"><h1>Create Account</h1><?php if($msg):?><div class="alert success"><?= $msg ?></div><?php endif;?><?php if($error):?><div class="alert"><?= $error ?></div><?php endif;?><label>Full Name</label><input name="full_name" required><label>Email</label><input name="email" type="email" required><label>Password</label><input name="password" type="password" required><div class="two"><div><label>Height cm</label><input id="height" name="height" oninput="bmiCalc()"></div><div><label>Weight kg</label><input id="weight" name="weight" oninput="bmiCalc()"></div></div><div id="bmiResult" class="badge"></div><label>Goal</label><select name="goal"><option>Weight Loss</option><option>Muscle Gain</option><option>Maintenance</option></select><button>Register</button><p><a href="login.php">Already have account?</a></p></form></body></html>
