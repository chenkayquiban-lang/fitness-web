<?php
if (session_status() === PHP_SESSION_NONE) { session_start(); }

function e($str){ return htmlspecialchars((string)$str, ENT_QUOTES, 'UTF-8'); }
function active($page){ return basename($_SERVER['PHP_SELF']) === $page ? 'active' : ''; }

function app_base_url(){
    $script = str_replace('\\', '/', $_SERVER['SCRIPT_NAME'] ?? '');
    $dir = rtrim(str_replace('\\', '/', dirname($script)), '/');
    return ($dir === '' || $dir === '.') ? '/' : $dir . '/';
}

function redirect_to_role_dashboard($role='user'){
    $base = app_base_url();
    header('Location: ' . $base . 'member/dashboard.php');
    exit;
}

function require_login(){
    if(!isset($_SESSION['user_id'])){
        $base = app_base_url();
        header('Location: ' . $base . 'login.php');
        exit;
    }
}

function require_role($role='user'){
    require_login();
    if(($_SESSION['role'] ?? 'user') !== 'user'){
        $_SESSION['role'] = 'user';
    }
}

function bmi_category($bmi){ if($bmi < 18.5) return 'Underweight'; if($bmi < 25) return 'Normal'; if($bmi < 30) return 'Overweight'; return 'Obese'; }
function bp_category($sys,$dia){ if($sys < 120 && $dia < 80) return 'Normal'; if($sys < 130 && $dia < 80) return 'Elevated'; if($sys < 140 || $dia < 90) return 'High BP Stage 1'; if($sys >= 140 || $dia >= 90) return 'High BP Stage 2'; return 'Hypertensive Crisis'; }
?>
