FITLIFE: Fitness and Health Management System
PHP + MySQL Complete System

ONE-ROLE USER VERSION:
- Removed admin/trainer login roles.
- Login now uses one role only: user.
- Every registered user automatically has a member profile.
- Added User / Member Management page.
- Users can add, edit, and delete members.

INSTALLATION:
1. Extract this folder to:
   C:\xampp\htdocs\fitlife_fixed_final\

2. Start Apache and MySQL in XAMPP.

3. Open phpMyAdmin:
   http://localhost/phpmyadmin

4. Import the SQL file:
   database/fitlife_db.sql

5. Open the system:
   http://localhost/fitlife_fixed_final/

LOGIN ACCOUNT:
Email: user@example.com
Password: user123

DATABASE:
Database name: fitlife_db
Connection file: config/database.php

If your MySQL uses another port, edit config/database.php and add the port:
$conn = mysqli_connect($host, $user, $password, $dbname, 3307);
