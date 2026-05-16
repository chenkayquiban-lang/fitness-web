<?php
require_once 'config/auth.php';
require 'config/database.php';

if(isset($_SESSION['user_id']) && isset($_SESSION['role'])){
    redirect_to_role_dashboard($_SESSION['role']);
}

$error='';
if($_SERVER['REQUEST_METHOD']=='POST'){
    $login=mysqli_real_escape_string($conn,$_POST['login']);
    $pass=md5($_POST['password']);
    $q=mysqli_query($conn,"SELECT * FROM users WHERE (email='$login' OR username='$login') AND password='$pass' AND status='active' LIMIT 1");
    if($u=mysqli_fetch_assoc($q)){
        session_regenerate_id(true);
        $_SESSION['user_id']=$u['id'];
        $_SESSION['full_name']=$u['full_name'];
        $_SESSION['role']=$u['role'];
        redirect_to_role_dashboard($u['role']);
    } else {
        $error='Invalid login credentials.';
    }
}
?>
<!DOCTYPE html><html><head><title>Login</title><meta name="viewport" content="width=device-width,initial-scale=1"><link rel="stylesheet" href="assets/css/style.css"></head><body class="auth"><form class="form" method="post"><h1>Welcome Back</h1><p>Login to FitLife System</p><?php if($error):?><div class="alert"><?= e($error) ?></div><?php endif;?><label>Username or Email</label><input name="login" type="text" required value="user"><label>Password</label><input name="password" type="password" required value="user123"><button>Login</button><p>Default Login: user / user123</p><a href="register.php">Create account</a></form></body></html>
