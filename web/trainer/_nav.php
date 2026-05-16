<?php require_once '../config/auth.php'; require_role('trainer'); ?>
<div class="sidebar"><a class="brand">FitLife Trainer</a><a class="<?=active('dashboard.php')?>" href="dashboard.php">📊 Dashboard</a><a class="<?=active('classes.php')?>" href="classes.php">📅 My Classes</a><a class="<?=active('members.php')?>" href="members.php">👥 Members</a><a href="../logout.php">🚪 Logout</a></div>
