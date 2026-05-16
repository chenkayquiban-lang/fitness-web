FITNESS WEB MAIN UPDATED TO FITLIFE ONE ROLE USER MEMBER CRUD

This package contains:
1. web/     - enhanced FitLife web system replacing the previous fitness-web-main web app
2. desktop/ - Visual Studio 2022 WinForms counterpart connected to the same MySQL database

Default credentials:
Username: user
Password: user123

Database:
Name: fitlife_db
XAMPP MySQL user: root
Password: blank

Install web:
1. Copy the web folder contents to C:\xampp\htdocs\fitness-web-main\
2. Start Apache and MySQL in XAMPP.
3. Import web\database\fitlife_db.sql using phpMyAdmin.
4. Visit http://localhost/fitness-web-main/login.php

Run desktop:
1. Open desktop\FitLifeDesktopApp.sln in Visual Studio 2022.
2. Restore NuGet packages when prompted.
3. Press F5.
4. Login using user / user123.

Designer support:
The desktop project includes .Designer.cs files for LoginForm and MainForm. Use Shift + F7 or right click > View Designer. Runtime database code is skipped when the Visual Studio Designer is open.
