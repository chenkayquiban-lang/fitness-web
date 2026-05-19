FIXED DESKTOP + WEB SYNC

This zip already includes:
1. web/api/desktop_db.php
2. fixed desktop/FitLifeDesktopApp/Database.cs
3. fixed desktop login to allow username OR email
4. fixed desktop member delete so it deletes from BOTH users and members table

DEFAULT API URL in Database.cs:
http://localhost/fitness-web-main/web/api/desktop_db.php

This works if your folder is here:
C:\xampp\htdocs\fitness-web-main\web

If your website is online, open:
desktop/FitLifeDesktopApp/Database.cs

Change:
public static string ApiUrl = "http://localhost/fitness-web-main/web/api/desktop_db.php";

To your online website, example:
public static string ApiUrl = "https://yourwebsite.infinityfreeapp.com/api/desktop_db.php";

Also upload this folder/file to hosting:
web/api/desktop_db.php

If desktop says Cannot connect to web API, open this in browser:
http://localhost/fitness-web-main/web/api/desktop_db.php

Expected: JSON error like Invalid JSON request. That means API exists.
