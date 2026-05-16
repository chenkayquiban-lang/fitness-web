<?php
require '../config/database.php';
require_once '../config/auth.php';
require_role('user');

$msg = $error = '';
$edit = null;

if (isset($_GET['delete'])) {
    $id = (int)$_GET['delete'];
    mysqli_query($conn, "DELETE FROM users WHERE id=$id AND role='user'");
    header('Location: members.php?msg=deleted'); exit;
}

if (isset($_GET['edit'])) {
    $id = (int)$_GET['edit'];
    $res = mysqli_query($conn, "SELECT u.id,u.full_name,u.email,u.status,m.phone,m.address,m.gender,m.birthday,m.height_cm,m.weight_kg,m.goal FROM users u LEFT JOIN members m ON u.id=m.user_id WHERE u.id=$id AND u.role='user' LIMIT 1");
    $edit = mysqli_fetch_assoc($res);
}

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $id = (int)($_POST['id'] ?? 0);
    $name = mysqli_real_escape_string($conn, $_POST['full_name'] ?? '');
    $email = mysqli_real_escape_string($conn, $_POST['email'] ?? '');
    $phone = mysqli_real_escape_string($conn, $_POST['phone'] ?? '');
    $address = mysqli_real_escape_string($conn, $_POST['address'] ?? '');
    $gender = mysqli_real_escape_string($conn, $_POST['gender'] ?? '');
    $birthday = mysqli_real_escape_string($conn, $_POST['birthday'] ?? '');
    $height = (float)($_POST['height_cm'] ?? 0);
    $weight = (float)($_POST['weight_kg'] ?? 0);
    $goal = mysqli_real_escape_string($conn, $_POST['goal'] ?? '');
    $status = mysqli_real_escape_string($conn, $_POST['status'] ?? 'active');
    $pass = $_POST['password'] ?? '';

    if ($id > 0) {
        $passSql = $pass !== '' ? ", password=MD5('".mysqli_real_escape_string($conn,$pass)."')" : '';
        mysqli_query($conn, "UPDATE users SET full_name='$name', email='$email', status='$status' $passSql WHERE id=$id AND role='user'");
        $has = mysqli_fetch_assoc(mysqli_query($conn, "SELECT id FROM members WHERE user_id=$id"));
        if ($has) {
            mysqli_query($conn, "UPDATE members SET phone='$phone', address='$address', gender='$gender', birthday=".($birthday?"'$birthday'":"NULL").", height_cm=$height, weight_kg=$weight, goal='$goal' WHERE user_id=$id");
        } else {
            mysqli_query($conn, "INSERT INTO members(user_id,phone,address,gender,birthday,height_cm,weight_kg,goal) VALUES($id,'$phone','$address','$gender',".($birthday?"'$birthday'":"NULL").",$height,$weight,'$goal')");
        }
        header('Location: members.php?msg=updated'); exit;
    } else {
        if ($pass === '') { $pass = 'user123'; }
        if (mysqli_query($conn, "INSERT INTO users(full_name,email,password,role,status) VALUES('$name','$email',MD5('".mysqli_real_escape_string($conn,$pass)."'),'user','$status')")) {
            $uid = mysqli_insert_id($conn);
            mysqli_query($conn, "INSERT INTO members(user_id,phone,address,gender,birthday,height_cm,weight_kg,goal) VALUES($uid,'$phone','$address','$gender',".($birthday?"'$birthday'":"NULL").",$height,$weight,'$goal')");
            header('Location: members.php?msg=added'); exit;
        } else { $error = 'Email already exists.'; }
    }
}

if(isset($_GET['msg'])) $msg = 'Member '.$_GET['msg'].' successfully.';
$rows = mysqli_query($conn, "SELECT u.id,u.full_name,u.email,u.status,m.phone,m.gender,m.height_cm,m.weight_kg,m.goal FROM users u LEFT JOIN members m ON u.id=m.user_id WHERE u.role='user' ORDER BY u.id DESC");
?>
<!DOCTYPE html><html><head><title>Members</title><link rel="stylesheet" href="../assets/css/style.css"></head><body><div class="layout"><?php include '_nav.php'; ?><main class="main">
<div class="header"><h1>User / Member Management</h1></div>
<?php if($msg):?><div class="alert success"><?=e($msg)?></div><?php endif;?><?php if($error):?><div class="alert"><?=e($error)?></div><?php endif;?>
<form class="form" method="post">
<h2><?= $edit ? 'Edit Member' : 'Add Member' ?></h2><input type="hidden" name="id" value="<?=e($edit['id'] ?? 0)?>">
<div class="two"><div><label>Full Name</label><input name="full_name" required value="<?=e($edit['full_name'] ?? '')?>"></div><div><label>Email</label><input type="email" name="email" required value="<?=e($edit['email'] ?? '')?>"></div></div>
<div class="two"><div><label>Password <?= $edit ? '(leave blank to keep old)' : '' ?></label><input type="password" name="password" <?= $edit ? '' : 'required' ?>></div><div><label>Status</label><select name="status"><option value="active" <?=($edit['status']??'active')==='active'?'selected':''?>>active</option><option value="inactive" <?=($edit['status']??'')==='inactive'?'selected':''?>>inactive</option></select></div></div>
<div class="two"><div><label>Phone</label><input name="phone" value="<?=e($edit['phone'] ?? '')?>"></div><div><label>Gender</label><input name="gender" value="<?=e($edit['gender'] ?? '')?>"></div></div>
<label>Address</label><input name="address" value="<?=e($edit['address'] ?? '')?>">
<div class="two"><div><label>Birthday</label><input type="date" name="birthday" value="<?=e($edit['birthday'] ?? '')?>"></div><div><label>Goal</label><input name="goal" value="<?=e($edit['goal'] ?? '')?>"></div></div>
<div class="two"><div><label>Height cm</label><input type="number" step="0.01" name="height_cm" value="<?=e($edit['height_cm'] ?? '')?>"></div><div><label>Weight kg</label><input type="number" step="0.01" name="weight_kg" value="<?=e($edit['weight_kg'] ?? '')?>"></div></div>
<button><?= $edit ? 'Update Member' : 'Add Member' ?></button><?php if($edit):?> <a class="btn light" href="members.php">Cancel</a><?php endif;?>
</form><br>
<table class="table"><tr><th>Name</th><th>Email</th><th>Phone</th><th>Goal</th><th>Height</th><th>Weight</th><th>Status</th><th>Actions</th></tr><?php while($r=mysqli_fetch_assoc($rows)):?><tr><td><?=e($r['full_name'])?></td><td><?=e($r['email'])?></td><td><?=e($r['phone'])?></td><td><?=e($r['goal'])?></td><td><?=e($r['height_cm'])?></td><td><?=e($r['weight_kg'])?></td><td><span class="badge <?=$r['status']=='active'?'':'danger'?>"><?=e($r['status'])?></span></td><td><a class="btn light" href="?edit=<?=$r['id']?>">Edit</a> <a class="btn danger" onclick="return confirm('Delete this member?')" href="?delete=<?=$r['id']?>">Delete</a></td></tr><?php endwhile;?></table>
</main></div></body></html>
