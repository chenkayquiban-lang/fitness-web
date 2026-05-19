<?php
require '../config/database.php';
require_once '../config/auth.php';
require_role('admin');

$msg = '';
$error = '';
$edit = null;

function clean_email($email) {
    return strtolower(trim((string)$email));
}

function esc($conn, $value) {
    return mysqli_real_escape_string($conn, trim((string)$value));
}

function make_username($conn, $email, $ignore_id = 0) {
    $base = strtolower(trim(explode('@', $email)[0] ?? 'user'));
    $base = preg_replace('/[^a-z0-9_]/', '', $base);
    if ($base === '') $base = 'user';
    $base = substr($base, 0, 45);

    $username = $base;
    $i = 1;

    while (true) {
        $safe = mysqli_real_escape_string($conn, $username);
        $extra = $ignore_id > 0 ? "AND id != " . (int)$ignore_id : '';
        $q = mysqli_query($conn, "SELECT id FROM users WHERE username='$safe' $extra LIMIT 1");

        if ($q && mysqli_num_rows($q) === 0) {
            return $username;
        }

        $username = substr($base, 0, 42) . $i;
        $i++;
    }
}

function save_member_details($conn, $user_id, $phone, $address, $gender, $birthday, $height, $weight, $goal) {
    $user_id = (int)$user_id;
    $birthday_sql = $birthday !== '' ? "'$birthday'" : "NULL";

    $has = mysqli_fetch_assoc(mysqli_query($conn, "SELECT id FROM members WHERE user_id=$user_id LIMIT 1"));

    if ($has) {
        return mysqli_query($conn, "
            UPDATE members
            SET phone='$phone',
                address='$address',
                gender='$gender',
                birthday=$birthday_sql,
                height_cm=$height,
                weight_kg=$weight,
                goal='$goal'
            WHERE user_id=$user_id
        ");
    }

    return mysqli_query($conn, "
        INSERT INTO members(user_id, phone, address, gender, birthday, height_cm, weight_kg, goal)
        VALUES($user_id, '$phone', '$address', '$gender', $birthday_sql, $height, $weight, '$goal')
    ");
}

if (isset($_GET['delete'])) {
    $id = (int)$_GET['delete'];

    mysqli_query($conn, "DELETE FROM members WHERE user_id=$id");
    mysqli_query($conn, "DELETE FROM users WHERE id=$id AND role='user'");

    header('Location: members.php?msg=deleted');
    exit;
}

if (isset($_GET['toggle'])) {
    $id = (int)$_GET['toggle'];
    mysqli_query($conn, "UPDATE users SET status=IF(status='active','inactive','active') WHERE id=$id AND role='user'");
    header('Location: members.php?msg=updated');
    exit;
}

if (isset($_GET['edit'])) {
    $id = (int)$_GET['edit'];

    $res = mysqli_query($conn, "
        SELECT u.id, u.full_name, u.email, u.username, u.status,
               m.phone, m.address, m.gender, m.birthday, m.height_cm, m.weight_kg, m.goal
        FROM users u
        LEFT JOIN members m ON u.id = m.user_id
        WHERE u.id=$id AND u.role='user'
        LIMIT 1
    ");

    $edit = mysqli_fetch_assoc($res);
}

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $id = (int)($_POST['id'] ?? 0);

    $name = esc($conn, $_POST['full_name'] ?? '');
    $email_raw = clean_email($_POST['email'] ?? '');
    $email = mysqli_real_escape_string($conn, $email_raw);

    $phone = esc($conn, $_POST['phone'] ?? '');
    $address = esc($conn, $_POST['address'] ?? '');
    $gender = esc($conn, $_POST['gender'] ?? '');
    $birthday = esc($conn, $_POST['birthday'] ?? '');
    $goal = esc($conn, $_POST['goal'] ?? '');
    $status = esc($conn, $_POST['status'] ?? 'active');

    $height = ($_POST['height_cm'] ?? '') !== '' ? (float)$_POST['height_cm'] : 0;
    $weight = ($_POST['weight_kg'] ?? '') !== '' ? (float)$_POST['weight_kg'] : 0;
    $pass = $_POST['password'] ?? '';

    if ($name === '' || $email === '') {
        $error = 'Name and email are required.';
    } else {
        if ($id > 0) {
            $dup = mysqli_query($conn, "SELECT id, role FROM users WHERE LOWER(TRIM(email))='$email' AND id != $id LIMIT 1");

            if ($dup && mysqli_num_rows($dup) > 0) {
                $duprow = mysqli_fetch_assoc($dup);
                $error = 'Email already exists in another account with role: ' . e($duprow['role']);
            } else {
                $username = mysqli_real_escape_string($conn, make_username($conn, $email, $id));
                $passSql = '';

                if ($pass !== '') {
                    $safePass = mysqli_real_escape_string($conn, $pass);
                    $passSql = ", password=MD5('$safePass')";
                }

                $ok = mysqli_query($conn, "
                    UPDATE users
                    SET full_name='$name',
                        email='$email',
                        username='$username',
                        status='$status'
                        $passSql
                    WHERE id=$id AND role='user'
                ");

                if (!$ok) {
                    $error = mysqli_error($conn);
                } else {
                    $details_ok = save_member_details($conn, $id, $phone, $address, $gender, $birthday, $height, $weight, $goal);
                    if (!$details_ok) {
                        $error = mysqli_error($conn);
                    } else {
                        header('Location: members.php?msg=updated');
                        exit;
                    }
                }
            }
        } else {
            $existing = mysqli_query($conn, "SELECT id, role FROM users WHERE LOWER(TRIM(email))='$email' LIMIT 1");

            if ($existing && mysqli_num_rows($existing) > 0) {
                $user = mysqli_fetch_assoc($existing);
                $existing_id = (int)$user['id'];

                if ($user['role'] !== 'user') {
                    $error = 'Email already exists as ' . e($user['role']) . '. Use a different email.';
                } else {
                    // Fix for hidden existing users: if user exists but not visible/complete in members, complete/update it instead of failing.
                    $username = mysqli_real_escape_string($conn, make_username($conn, $email, $existing_id));
                    $passSql = '';

                    if ($pass !== '') {
                        $safePass = mysqli_real_escape_string($conn, $pass);
                        $passSql = ", password=MD5('$safePass')";
                    }

                    $ok = mysqli_query($conn, "
                        UPDATE users
                        SET full_name='$name',
                            email='$email',
                            username='$username',
                            status='$status'
                            $passSql
                        WHERE id=$existing_id AND role='user'
                    ");

                    if (!$ok) {
                        $error = mysqli_error($conn);
                    } else {
                        $details_ok = save_member_details($conn, $existing_id, $phone, $address, $gender, $birthday, $height, $weight, $goal);
                        if (!$details_ok) {
                            $error = mysqli_error($conn);
                        } else {
                            header('Location: members.php?msg=updated');
                            exit;
                        }
                    }
                }
            } else {
                if ($pass === '') $pass = 'user123';

                $safePass = mysqli_real_escape_string($conn, $pass);
                $username = mysqli_real_escape_string($conn, make_username($conn, $email));

                $ok = mysqli_query($conn, "
                    INSERT INTO users(full_name, username, email, password, role, status)
                    VALUES('$name', '$username', '$email', MD5('$safePass'), 'user', '$status')
                ");

                if (!$ok) {
                    $error = mysqli_error($conn);
                } else {
                    $uid = mysqli_insert_id($conn);
                    $details_ok = save_member_details($conn, $uid, $phone, $address, $gender, $birthday, $height, $weight, $goal);
                    if (!$details_ok) {
                        $error = mysqli_error($conn);
                    } else {
                        header('Location: members.php?msg=added');
                        exit;
                    }
                }
            }
        }
    }
}

if (isset($_GET['msg'])) {
    $msg = 'Member ' . e($_GET['msg']) . ' successfully.';
}

$rows = mysqli_query($conn, "
    SELECT u.id, u.full_name, u.email, u.username, u.status,
           m.phone, m.gender, m.height_cm, m.weight_kg, m.goal
    FROM users u
    LEFT JOIN members m ON u.id = m.user_id
    WHERE u.role='user'
    ORDER BY u.id DESC
");
?>
<!DOCTYPE html>
<html>
<head>
    <title>Members</title>
    <link rel="stylesheet" href="../assets/css/style.css">
</head>
<body>
<div class="layout">
<?php include '_nav.php'; ?>

<main class="main">
<div class="header"><h1>Member Management</h1></div>

<?php if($msg): ?><div class="alert success"><?= $msg ?></div><?php endif; ?>
<?php if($error): ?><div class="alert"><?= e($error) ?></div><?php endif; ?>

<form class="form" method="post">
<h2><?= $edit ? 'Edit Member' : 'Add Member' ?></h2>
<input type="hidden" name="id" value="<?= e($edit['id'] ?? 0) ?>">

<div class="two">
    <div><label>Full Name</label><input name="full_name" required value="<?= e($edit['full_name'] ?? '') ?>"></div>
    <div><label>Email</label><input type="email" name="email" required value="<?= e($edit['email'] ?? '') ?>"></div>
</div>

<div class="two">
    <div><label>Password <?= $edit ? '(leave blank to keep old)' : '' ?></label><input type="password" name="password" <?= $edit ? '' : 'required' ?>></div>
    <div><label>Status</label><select name="status"><option value="active" <?= ($edit['status'] ?? 'active') === 'active' ? 'selected' : '' ?>>active</option><option value="inactive" <?= ($edit['status'] ?? '') === 'inactive' ? 'selected' : '' ?>>inactive</option></select></div>
</div>

<div class="two">
    <div><label>Phone</label><input name="phone" value="<?= e($edit['phone'] ?? '') ?>"></div>
    <div><label>Gender</label><input name="gender" value="<?= e($edit['gender'] ?? '') ?>"></div>
</div>

<label>Address</label><input name="address" value="<?= e($edit['address'] ?? '') ?>">

<div class="two">
    <div><label>Birthday</label><input type="date" name="birthday" value="<?= e($edit['birthday'] ?? '') ?>"></div>
    <div><label>Goal</label><input name="goal" value="<?= e($edit['goal'] ?? '') ?>"></div>
</div>

<div class="two">
    <div><label>Height cm</label><input type="number" step="0.01" name="height_cm" value="<?= e($edit['height_cm'] ?? '') ?>"></div>
    <div><label>Weight kg</label><input type="number" step="0.01" name="weight_kg" value="<?= e($edit['weight_kg'] ?? '') ?>"></div>
</div>

<button><?= $edit ? 'Update Member' : 'Add Member' ?></button>
<?php if($edit): ?> <a class="btn light" href="members.php">Cancel</a><?php endif; ?>
</form>
<br>

<table class="table">
<tr><th>Name</th><th>Email</th><th>Username</th><th>Phone</th><th>Goal</th><th>Height</th><th>Weight</th><th>Status</th><th>Actions</th></tr>
<?php while($r = mysqli_fetch_assoc($rows)): ?>
<tr>
<td><?= e($r['full_name']) ?></td>
<td><?= e($r['email']) ?></td>
<td><?= e($r['username']) ?></td>
<td><?= e($r['phone']) ?></td>
<td><?= e($r['goal']) ?></td>
<td><?= e($r['height_cm']) ?></td>
<td><?= e($r['weight_kg']) ?></td>
<td><span class="badge <?= $r['status'] == 'active' ? '' : 'danger' ?>"><?= e($r['status']) ?></span></td>
<td><a class="btn light" href="?edit=<?= $r['id'] ?>">Edit</a> <a class="btn light" href="?toggle=<?= $r['id'] ?>">Toggle</a> <a class="btn danger" onclick="return confirm('Delete this member?')" href="?delete=<?= $r['id'] ?>">Delete</a></td>
</tr>
<?php endwhile; ?>
</table>
</main>
</div>
</body>
</html>
