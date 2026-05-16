FITLIFE DESKTOP APP - VISUAL STUDIO 2022

Open:
  desktop/FitLifeDesktopApp.sln

Database connection:
  server=localhost
  database=fitlife_db
  user=root
  password=(blank)

Login:
  username: user
  password: user123

Designer tools:
  Each form has a .cs and .Designer.cs file so Visual Studio Designer can open them.
  Right click any form file, then click View Designer or press Shift+F7.

Forms included:
  LoginForm
  MainForm
  DashboardForm
  MembersForm
  HealthForm
  ActivityForm
  GoalsForm
  ClassesForm

Features:
  - Connected to the same MySQL database used by the web system
  - Modern sidebar interface
  - Members CRUD
  - Health Records CRUD with BMI auto-calculation
  - Activity Logs CRUD
  - Goals CRUD
  - Classes CRUD
  - 1 second auto-refresh on data forms

If connection fails:
  1. Start XAMPP MySQL and Apache
  2. Open phpMyAdmin
  3. Import web/database/RESET_AND_IMPORT_fitlife_db.sql
  4. Rebuild the project in Visual Studio 2022

NuGet:
  The project uses MySql.Data. Visual Studio will restore it automatically.
