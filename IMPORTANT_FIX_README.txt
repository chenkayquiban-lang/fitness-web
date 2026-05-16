FIX FOR 404 /fitness-web-main/member/dashboard.php

This package has redirect files at the root, so old URLs like:
http://localhost/fitness-web-main/member/dashboard.php
will redirect to:
http://localhost/fitness-web-main/web/member/dashboard.php

Install:
1. Delete old C:\xampp\htdocs\fitness-web-main folder.
2. Copy this fitness-web-main folder to C:\xampp\htdocs\.
3. Import web/database/fitlife_db.sql in phpMyAdmin.
4. Open http://localhost/fitness-web-main/web/login.php
5. Login: user / user123
