FITNESS AND HEALTH MONITORING SYSTEM - DESKTOP CRUD COUNTERPART
C# WinForms + MySQL, Visual Studio 2022

This desktop app connects to the same XAMPP MySQL database as the PHP web system.

DATABASE CONNECTION
Host: localhost
Database: fitness_health_system
Username: root
Password: blank

WHAT IS INCLUDED
- FitnessHealthDesktopApp.sln
- FitnessHealthDesktopApp.csproj
- Program.cs
- Database.cs
- MainForm.cs

CRUD FEATURES INCLUDED
1. Members CRUD
   - Add member
   - View members
   - Edit selected member
   - Delete selected member

2. Health Logs CRUD
   - Add health log
   - View health logs
   - Edit selected health log
   - Delete selected health log
   - Auto BMI calculation
   - Auto BMI category
   - Auto blood pressure status

3. Fitness Goals CRUD
   - Add goal
   - View goals
   - Edit selected goal
   - Delete selected goal

4. Workout Plans CRUD
   - Add workout plan
   - View workout plans
   - Edit selected workout plan
   - Delete selected workout plan

5. Dashboard and Reports
   - Total members
   - Total health records
   - Total goals
   - Total workout plans
   - At-risk records
   - Member health report summary

HOW WEB AND DESKTOP ARE CONNECTED
Both systems use the same MySQL tables:
- members
- health_records
- fitness_goals
- workout_plans

Records added, edited, or deleted in the desktop app will reflect in the PHP web system.
Records added, edited, or deleted in the PHP web system will reflect in the desktop app after clicking Refresh or restarting the app.

HOW TO RUN
1. Start XAMPP Control Panel.
2. Start MySQL.
3. Make sure the web system database is already imported in phpMyAdmin:
   fitness_health_system
4. Extract this desktop app.
5. Open FitnessHealthDesktopApp.sln in Visual Studio 2022.
6. Let Visual Studio restore NuGet packages.
7. Press Start.

IF MYSQL PASSWORD CHANGES
Open Database.cs and update the connection string:
server=localhost;port=3306;database=fitness_health_system;user=root;password=;

AUTO REFRESH
Desktop refreshes every 5 seconds and pauses while typing/editing. Web pages refresh every 7 seconds.
