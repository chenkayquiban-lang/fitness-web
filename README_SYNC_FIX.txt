FITLIFE DESKTOP + WEB SYNC FIX

This version uses a WEB API so the desktop app updates the SAME database used by the website.

FILES CHANGED/ADDED:
1. web/api/desktop_db.php
   - Upload this file/folder to your online website.

2. desktop/FitLifeDesktopApp/Database.cs
   - Replace this line with your real website link:
     private const string ApiUrl = "https://YOUR_WEBSITE_LINK/api/desktop_db.php";

Example:
     private const string ApiUrl = "https://fitlife.infinityfreeapp.com/api/desktop_db.php";

IMPORTANT:
- Do NOT expect localhost desktop database to sync with web.
- Desktop must connect through the online web API above.
- Your online web/config/database.php must connect to your online MySQL database.
- After changing Database.cs, rebuild/run the desktop app.

LOGIN NOTE:
- Desktop login now accepts username OR email.
- Password is still checked using MD5, same as your current system.

MEMBER DELETE NOTE:
- Desktop delete now deletes both members row and users row, same as web.
