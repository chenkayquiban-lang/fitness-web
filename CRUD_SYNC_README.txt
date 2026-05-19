CRUD SYNC SETUP

Goal:
- Web CRUD and Desktop CRUD must use the same online database/API.
- Desktop should NOT use separate localhost database if you want auto sync with web.

Included fixes:
1. web/api/desktop_db.php
   - Desktop sends SELECT/INSERT/UPDATE/DELETE here.
   - This file uses web/config/database.php, so it updates the same database as your website.

2. desktop/FitLifeDesktopApp/Database.cs
   - Desktop database calls go through the API.
   - Change DesktopApiUrl to your real hosted URL after upload.

3. desktop/FitLifeDesktopApp/MembersForm.cs
   - Fixed CRUD sync for members.
   - Fixed email already exists caused by blank/duplicate username.
   - Delete removes members row first, then users row.

Required steps:
1. Upload the web folder to your hosting.
2. Make sure this URL works:
   https://YOUR-WEBSITE/api/desktop_db.php

3. In desktop/FitLifeDesktopApp/Database.cs, replace:
   http://localhost/fitness-web-main/web/api/desktop_db.php
   with:
   https://YOUR-WEBSITE/api/desktop_db.php

4. In web/config/database.php, use the hosting database credentials, not localhost/root.

5. Rebuild the desktop app.

Important:
- If DesktopApiUrl still points to localhost, sync is local only.
- If web/config/database.php still points to localhost, hosting web will not share with desktop.
- If InfinityFree blocks external MySQL, this API method still works because desktop talks to PHP API, not directly to MySQL.
