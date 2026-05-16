using System.Data;
using MySql.Data.MySqlClient;

namespace FitnessHealthDesktopApp;

public class MainForm : Form
{
    private readonly TabControl tabs = new() { Dock = DockStyle.Fill };
    private readonly Label status = new() { Dock = DockStyle.Bottom, Height = 28, TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(10, 0, 0, 0) };
    private readonly System.Windows.Forms.Timer autoRefreshTimer = new() { Interval = 1000 };
    private readonly CheckBox autoRefreshCheck = new() { Text = "Auto refresh every 1 second", Checked = true, AutoSize = true, Dock = DockStyle.Top, Padding = new Padding(10, 6, 0, 6) };

    private readonly DataGridView dashboardGrid = Grid();
    private readonly DataGridView membersGrid = Grid();
    private readonly DataGridView healthGrid = Grid();
    private readonly DataGridView goalsGrid = Grid();
    private readonly DataGridView workoutsGrid = Grid();
    private readonly DataGridView reportsGrid = Grid();

    private readonly TextBox memberId = HiddenBox();
    private readonly TextBox memberName = Txt();
    private readonly TextBox memberAge = Txt();
    private readonly ComboBox memberGender = Combo("Male", "Female", "Other");
    private readonly TextBox memberContact = Txt();
    private readonly TextBox memberAddress = Txt();
    private readonly ComboBox memberType = Combo("Regular", "Premium", "Student", "Senior");
    private readonly DateTimePicker memberDate = DatePicker();

    private readonly TextBox healthId = HiddenBox();
    private readonly ComboBox healthMember = Combo();
    private readonly TextBox healthHeight = Txt();
    private readonly TextBox healthWeight = Txt();
    private readonly TextBox healthSys = Txt();
    private readonly TextBox healthDia = Txt();
    private readonly TextBox healthHeart = Txt();
    private readonly TextBox healthRemarks = Txt();
    private readonly DateTimePicker healthDate = DatePicker();

    private readonly TextBox goalId = HiddenBox();
    private readonly ComboBox goalMember = Combo();
    private readonly ComboBox goalType = Combo("Lose weight", "Gain muscle", "Maintain weight", "Improve blood pressure", "Increase stamina");
    private readonly TextBox goalTarget = Txt();
    private readonly DateTimePicker goalDate = DatePicker();
    private readonly ComboBox goalStatus = Combo("Ongoing", "Completed", "Cancelled");
    private readonly TextBox goalNotes = Txt();

    private readonly TextBox workoutId = HiddenBox();
    private readonly ComboBox workoutMember = Combo();
    private readonly ComboBox workoutPlan = Combo("Cardio", "Strength Training", "Weight Loss Program", "Beginner Workout", "Advanced Workout");
    private readonly TextBox workoutDescription = Txt();
    private readonly ComboBox workoutDifficulty = Combo("Beginner", "Intermediate", "Advanced");
    private readonly DateTimePicker workoutDate = DatePicker();

    public MainForm()
    {
        Text = "Fitness and Health Monitoring System - Desktop CRUD Connected";
        Width = 1280;
        Height = 800;
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Segoe UI", 10);
        Controls.Add(tabs);
        Controls.Add(autoRefreshCheck);
        Controls.Add(status);
        BuildDashboard();
        BuildMembers();
        BuildHealth();
        BuildGoals();
        BuildWorkouts();
        BuildReports();
        autoRefreshTimer.Tick += (_, _) => AutoRefresh();
        autoRefreshTimer.Start();
        autoRefreshCheck.CheckedChanged += (_, _) => autoRefreshTimer.Enabled = autoRefreshCheck.Checked;
        LoadAll();
    }

    private void BuildDashboard()
    {
        var page = Page("Dashboard");
        var counts = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 105, AutoScroll = true };
        var refresh = new Button { Text = "Refresh", Dock = DockStyle.Top, Height = 36 };
        refresh.Click += (_, _) => LoadAll();
        page.Controls.Add(dashboardGrid);
        page.Controls.Add(refresh);
        page.Controls.Add(counts);
        counts.Tag = "counts";
    }

    private void BuildMembers()
    {
        var page = Page("Members CRUD");
        var form = FormPanel(220);
        AddLabeled(form, "Full Name", memberName);
        AddLabeled(form, "Age", memberAge);
        AddLabeled(form, "Gender", memberGender);
        AddLabeled(form, "Contact Number", memberContact);
        AddLabeled(form, "Membership Type", memberType);
        AddLabeled(form, "Date Registered", memberDate);
        AddLabeled(form, "Address", memberAddress);
        form.Controls.Add(memberId);
        form.Controls.Add(ActionButton("New", ClearMemberForm));
        form.Controls.Add(ActionButton("Save / Update", SaveMember));
        form.Controls.Add(ActionButton("Delete Selected", DeleteMember));
        membersGrid.SelectionChanged += (_, _) => FillMemberForm();
        page.Controls.Add(membersGrid);
        page.Controls.Add(form);
    }

    private void BuildHealth()
    {
        var page = Page("Health Logs CRUD");
        var form = FormPanel(250);
        AddLabeled(form, "Member", healthMember);
        AddLabeled(form, "Height (meters)", healthHeight);
        AddLabeled(form, "Weight (kg)", healthWeight);
        healthHeight.TextChanged += (_, _) => CalculateBMI();
        healthWeight.TextChanged += (_, _) => CalculateBMI();
        AddLabeled(form, "Systolic", healthSys);
        AddLabeled(form, "Diastolic", healthDia);
        AddLabeled(form, "Heart Rate", healthHeart);
        AddLabeled(form, "Date Checked", healthDate);
        AddLabeled(form, "Remarks", healthRemarks);
        form.Controls.Add(healthId);
        form.Controls.Add(ActionButton("New", ClearHealthForm));
        form.Controls.Add(ActionButton("Save / Update", SaveHealth));
        form.Controls.Add(ActionButton("Delete Selected", DeleteHealth));
        healthGrid.SelectionChanged += (_, _) => FillHealthForm();
        page.Controls.Add(healthGrid);
        page.Controls.Add(form);
    }

    private void BuildGoals()
    {
        var page = Page("Goals CRUD");
        var form = FormPanel(225);
        AddLabeled(form, "Member", goalMember);
        AddLabeled(form, "Goal Type", goalType);
        AddLabeled(form, "Target Weight", goalTarget);
        AddLabeled(form, "Target Date", goalDate);
        AddLabeled(form, "Status", goalStatus);
        AddLabeled(form, "Notes", goalNotes);
        form.Controls.Add(goalId);
        form.Controls.Add(ActionButton("New", ClearGoalForm));
        form.Controls.Add(ActionButton("Save / Update", SaveGoal));
        form.Controls.Add(ActionButton("Delete Selected", DeleteGoal));
        goalsGrid.SelectionChanged += (_, _) => FillGoalForm();
        page.Controls.Add(goalsGrid);
        page.Controls.Add(form);
    }

    private void BuildWorkouts()
    {
        var page = Page("Workout Plans CRUD");
        var form = FormPanel(225);
        AddLabeled(form, "Member", workoutMember);
        AddLabeled(form, "Plan Name", workoutPlan);
        AddLabeled(form, "Difficulty", workoutDifficulty);
        AddLabeled(form, "Assigned Date", workoutDate);
        AddLabeled(form, "Description", workoutDescription);
        form.Controls.Add(workoutId);
        form.Controls.Add(ActionButton("New", ClearWorkoutForm));
        form.Controls.Add(ActionButton("Save / Update", SaveWorkout));
        form.Controls.Add(ActionButton("Delete Selected", DeleteWorkout));
        workoutsGrid.SelectionChanged += (_, _) => FillWorkoutForm();
        page.Controls.Add(workoutsGrid);
        page.Controls.Add(form);
    }

    private void BuildReports()
    {
        var page = Page("Reports");
        var refresh = new Button { Text = "Refresh Reports", Dock = DockStyle.Top, Height = 36 };
        refresh.Click += (_, _) => LoadReports();
        page.Controls.Add(reportsGrid);
        page.Controls.Add(refresh);
    }

    private void AutoRefresh()
    {
        if (!autoRefreshCheck.Checked || IsEditingControlFocused()) return;
        var selectedTab = tabs.SelectedIndex;
        try
        {
            LoadMemberCombos();
            LoadDashboard();
            LoadMembers();
            LoadHealth();
            LoadGoals();
            LoadWorkouts();
            LoadReports();
            if (selectedTab >= 0 && selectedTab < tabs.TabPages.Count) tabs.SelectedIndex = selectedTab;
            status.Text = "Auto refreshed: " + DateTime.Now.ToString("hh:mm:ss tt");
        }
        catch (Exception ex)
        {
            status.Text = "Auto refresh failed: " + ex.Message;
        }
    }

    private bool IsEditingControlFocused()
    {
        var c = ActiveControl;
        while (c != null)
        {
            if (c is TextBox || c is ComboBox || c is DateTimePicker) return true;
            c = c.Parent;
        }
        return false;
    }

    private void LoadAll()
    {
        try
        {
            if (!Database.Test(out var msg))
            {
                status.Text = "Connection failed: " + msg;
                return;
            }
            status.Text = msg;
            LoadMemberCombos();
            LoadDashboard();
            LoadMembers();
            LoadHealth();
            LoadGoals();
            LoadWorkouts();
            LoadReports();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadDashboard()
    {
        var counts = tabs.TabPages[0].Controls.OfType<FlowLayoutPanel>().First();
        counts.Controls.Clear();
        AddCount(counts, "Total Members", "SELECT COUNT(*) FROM members");
        AddCount(counts, "Health Records", "SELECT COUNT(*) FROM health_records");
        AddCount(counts, "Fitness Goals", "SELECT COUNT(*) FROM fitness_goals");
        AddCount(counts, "Workout Plans", "SELECT COUNT(*) FROM workout_plans");
        AddCount(counts, "At-Risk Records", "SELECT COUNT(*) FROM health_records WHERE bmi_category IN ('Overweight','Obese') OR bp_status LIKE 'High%'");
        dashboardGrid.DataSource = Database.Query("SELECT hr.record_id, m.full_name, hr.bmi, hr.bmi_category, CONCAT(hr.systolic,'/',hr.diastolic) AS blood_pressure, hr.bp_status, hr.heart_rate, hr.date_checked FROM health_records hr JOIN members m ON m.member_id=hr.member_id ORDER BY hr.date_checked DESC, hr.record_id DESC LIMIT 10");
    }

    private static void AddCount(FlowLayoutPanel panel, string title, string sql)
    {
        var count = Database.Query(sql).Rows[0][0]?.ToString() ?? "0";
        panel.Controls.Add(new Label { Text = title + "\n" + count, Width = 220, Height = 80, BorderStyle = BorderStyle.FixedSingle, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 12, FontStyle.Bold) });
    }

    private void LoadMembers() => membersGrid.DataSource = Database.Query("SELECT member_id, full_name, age, gender, contact_number, address, membership_type, date_registered FROM members ORDER BY member_id DESC");

    private void LoadHealth() => healthGrid.DataSource = Database.Query("SELECT hr.record_id, hr.member_id, m.full_name, hr.height, hr.weight, hr.bmi, hr.bmi_category, hr.systolic, hr.diastolic, CONCAT(hr.systolic,'/',hr.diastolic) AS blood_pressure, hr.bp_status, hr.heart_rate, hr.remarks, hr.date_checked FROM health_records hr JOIN members m ON m.member_id=hr.member_id ORDER BY hr.record_id DESC");

    private void LoadGoals()
    {
        string notesSelect = ColumnExists("fitness_goals", "notes") ? "fg.notes" : "'' AS notes";
        goalsGrid.DataSource = Database.Query($"SELECT fg.goal_id, fg.member_id, m.full_name, fg.goal_type, fg.target_weight, fg.target_date, fg.status, {notesSelect} FROM fitness_goals fg JOIN members m ON m.member_id=fg.member_id ORDER BY fg.goal_id DESC");
    }

    private void LoadWorkouts()
    {
        workoutsGrid.DataSource = Database.Query("SELECT wp.plan_id, wp.member_id, m.full_name, wp.plan_name, wp.description, wp.difficulty_level, wp.assigned_date FROM workout_plans wp JOIN members m ON m.member_id=wp.member_id ORDER BY wp.plan_id DESC");
    }
    private void LoadReports() => reportsGrid.DataSource = Database.Query("SELECT m.full_name, m.membership_type, COUNT(hr.record_id) health_records, MAX(hr.date_checked) latest_check, ROUND(AVG(hr.bmi),2) average_bmi, SUM(CASE WHEN hr.bmi_category IN ('Overweight','Obese') OR hr.bp_status LIKE 'High%' THEN 1 ELSE 0 END) risk_count, (SELECT hr2.bmi_category FROM health_records hr2 WHERE hr2.member_id=m.member_id ORDER BY hr2.date_checked DESC, hr2.record_id DESC LIMIT 1) latest_bmi_category, (SELECT hr3.bp_status FROM health_records hr3 WHERE hr3.member_id=m.member_id ORDER BY hr3.date_checked DESC, hr3.record_id DESC LIMIT 1) latest_bp_status FROM members m LEFT JOIN health_records hr ON hr.member_id=m.member_id GROUP BY m.member_id, m.full_name, m.membership_type ORDER BY m.full_name");

    private void LoadMemberCombos()
    {
        var members = Database.Query("SELECT member_id, full_name FROM members ORDER BY full_name");
        foreach (var c in new[] { healthMember, goalMember, workoutMember })
        {
            var old = c.SelectedValue;
            c.DataSource = members.Copy();
            c.DisplayMember = "full_name";
            c.ValueMember = "member_id";
            c.DropDownStyle = ComboBoxStyle.DropDownList;
            c.Width = 180;
            if (old != null) TrySetCombo(c, old);
        }
    }

    private void SaveMember()
    {
        Require(memberName.Text, "Full name is required.");
        int age = ParseInt(memberAge.Text, "Age");
        if (string.IsNullOrWhiteSpace(memberId.Text))
        {
            Database.Execute("INSERT INTO members(full_name,age,gender,contact_number,address,membership_type,date_registered) VALUES(@n,@a,@g,@c,@ad,@t,@dt)", P("@n", memberName.Text), P("@a", age), P("@g", memberGender.Text), P("@c", memberContact.Text), P("@ad", memberAddress.Text), P("@t", memberType.Text), P("@dt", SqlDate(memberDate)));
        }
        else
        {
            Database.Execute("UPDATE members SET full_name=@n, age=@a, gender=@g, contact_number=@c, address=@ad, membership_type=@t, date_registered=@dt WHERE member_id=@id", P("@n", memberName.Text), P("@a", age), P("@g", memberGender.Text), P("@c", memberContact.Text), P("@ad", memberAddress.Text), P("@t", memberType.Text), P("@dt", SqlDate(memberDate)), P("@id", memberId.Text));
        }
        ClearMemberForm();
        LoadAll();
    }

    private void DeleteMember()
    {
        var id = SelectedId(membersGrid, "member_id");
        if (id == null) return;
        if (MessageBox.Show("Delete selected member? Related health logs, goals, and workouts will also be deleted.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
        Database.Execute("DELETE FROM members WHERE member_id=@id", P("@id", id));
        ClearMemberForm();
        LoadAll();
    }

    private void FillMemberForm()
    {
        var r = membersGrid.CurrentRow;
        if (r == null || r.IsNewRow) return;
        memberId.Text = Cell(r, "member_id");
        memberName.Text = Cell(r, "full_name");
        memberAge.Text = Cell(r, "age");
        SetComboText(memberGender, Cell(r, "gender"));
        memberContact.Text = Cell(r, "contact_number");
        memberAddress.Text = Cell(r, "address");
        SetComboText(memberType, Cell(r, "membership_type"));
        SetDate(memberDate, Cell(r, "date_registered"));
    }

    private void ClearMemberForm()
    {
        memberId.Clear(); memberName.Clear(); memberAge.Clear(); memberContact.Clear(); memberAddress.Clear(); memberDate.Value = DateTime.Today;
        if (memberGender.Items.Count > 0) memberGender.SelectedIndex = 0;
        if (memberType.Items.Count > 0) memberType.SelectedIndex = 0;
    }

    private void SaveHealth()
    {
        if (healthMember.SelectedValue == null) throw new InvalidOperationException("Please add or select a member first.");
        decimal h = ParseDecimal(healthHeight.Text, "Height");
        decimal w = ParseDecimal(healthWeight.Text, "Weight");
        int s = ParseInt(healthSys.Text, "Systolic");
        int d = ParseInt(healthDia.Text, "Diastolic");
        int? hr = string.IsNullOrWhiteSpace(healthHeart.Text) ? null : ParseInt(healthHeart.Text, "Heart rate");
        decimal bmi = Math.Round(w / (h * h), 2);
        if (string.IsNullOrWhiteSpace(healthId.Text))
        {
            Database.Execute("INSERT INTO health_records(member_id,height,weight,bmi,bmi_category,systolic,diastolic,bp_status,heart_rate,remarks,date_checked) VALUES(@m,@h,@w,@b,@bc,@s,@d,@bp,@hr,@r,@dt)", P("@m", healthMember.SelectedValue), P("@h", h), P("@w", w), P("@b", bmi), P("@bc", BmiCategory(bmi)), P("@s", s), P("@d", d), P("@bp", BpStatus(s, d)), P("@hr", hr), P("@r", healthRemarks.Text), P("@dt", SqlDate(healthDate)));
        }
        else
        {
            Database.Execute("UPDATE health_records SET member_id=@m, height=@h, weight=@w, bmi=@b, bmi_category=@bc, systolic=@s, diastolic=@d, bp_status=@bp, heart_rate=@hr, remarks=@r, date_checked=@dt WHERE record_id=@id", P("@m", healthMember.SelectedValue), P("@h", h), P("@w", w), P("@b", bmi), P("@bc", BmiCategory(bmi)), P("@s", s), P("@d", d), P("@bp", BpStatus(s, d)), P("@hr", hr), P("@r", healthRemarks.Text), P("@dt", SqlDate(healthDate)), P("@id", healthId.Text));
        }
        ClearHealthForm();
        LoadAll();
    }

    private void CalculateBMI()
    {
        if (decimal.TryParse(healthHeight.Text, out decimal h) &&
            decimal.TryParse(healthWeight.Text, out decimal w) &&
            h > 0)
        {
            decimal bmi = Math.Round(w / (h * h), 2);
            Text = $"BMI: {bmi} ({BmiCategory(bmi)})";
        }
    }
    private void DeleteHealth()
    {
        var id = SelectedId(healthGrid, "record_id");
        if (id == null) return;
        if (MessageBox.Show("Delete selected health log?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
        Database.Execute("DELETE FROM health_records WHERE record_id=@id", P("@id", id));
        ClearHealthForm();
        LoadAll();
    }

    private void FillHealthForm()
    {
        var r = healthGrid.CurrentRow;
        if (r == null || r.IsNewRow) return;
        healthId.Text = Cell(r, "record_id");
        TrySetCombo(healthMember, Cell(r, "member_id"));
        healthHeight.Text = Cell(r, "height");
        healthWeight.Text = Cell(r, "weight");
        healthSys.Text = Cell(r, "systolic");
        healthDia.Text = Cell(r, "diastolic");
        healthHeart.Text = Cell(r, "heart_rate");
        healthRemarks.Text = Cell(r, "remarks");
        SetDate(healthDate, Cell(r, "date_checked"));
    }

    private void ClearHealthForm()
    {
        healthId.Clear(); healthHeight.Clear(); healthWeight.Clear(); healthSys.Clear(); healthDia.Clear(); healthHeart.Clear(); healthRemarks.Clear(); healthDate.Value = DateTime.Today;
        if (healthMember.Items.Count > 0) healthMember.SelectedIndex = 0;
    }

    private void SaveGoal()
    {
        if (goalMember.SelectedValue == null) throw new InvalidOperationException("Please add or select a member first.");
        decimal? target = string.IsNullOrWhiteSpace(goalTarget.Text) ? null : ParseDecimal(goalTarget.Text, "Target weight");
        bool hasNotes = ColumnExists("fitness_goals", "notes");

        if (string.IsNullOrWhiteSpace(goalId.Text))
        {
            if (hasNotes)
                Database.Execute("INSERT INTO fitness_goals(member_id,goal_type,target_weight,target_date,status,notes) VALUES(@m,@g,@tw,@dt,@s,@n)", P("@m", goalMember.SelectedValue), P("@g", goalType.Text), P("@tw", target), P("@dt", SqlDate(goalDate)), P("@s", goalStatus.Text), P("@n", goalNotes.Text));
            else
                Database.Execute("INSERT INTO fitness_goals(member_id,goal_type,target_weight,target_date,status) VALUES(@m,@g,@tw,@dt,@s)", P("@m", goalMember.SelectedValue), P("@g", goalType.Text), P("@tw", target), P("@dt", SqlDate(goalDate)), P("@s", goalStatus.Text));
        }
        else
        {
            if (hasNotes)
                Database.Execute("UPDATE fitness_goals SET member_id=@m, goal_type=@g, target_weight=@tw, target_date=@dt, status=@s, notes=@n WHERE goal_id=@id", P("@m", goalMember.SelectedValue), P("@g", goalType.Text), P("@tw", target), P("@dt", SqlDate(goalDate)), P("@s", goalStatus.Text), P("@n", goalNotes.Text), P("@id", goalId.Text));
            else
                Database.Execute("UPDATE fitness_goals SET member_id=@m, goal_type=@g, target_weight=@tw, target_date=@dt, status=@s WHERE goal_id=@id", P("@m", goalMember.SelectedValue), P("@g", goalType.Text), P("@tw", target), P("@dt", SqlDate(goalDate)), P("@s", goalStatus.Text), P("@id", goalId.Text));
        }
        ClearGoalForm();
        LoadAll();
    }
    private void DeleteGoal()
    {
        var id = SelectedId(goalsGrid, "goal_id");
        if (id == null) return;
        if (MessageBox.Show("Delete selected goal?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
        Database.Execute("DELETE FROM fitness_goals WHERE goal_id=@id", P("@id", id));
        ClearGoalForm();
        LoadAll();
    }

    private void FillGoalForm()
    {
        var r = goalsGrid.CurrentRow;
        if (r == null || r.IsNewRow) return;
        goalId.Text = Cell(r, "goal_id");
        TrySetCombo(goalMember, Cell(r, "member_id"));
        SetComboText(goalType, Cell(r, "goal_type"));
        goalTarget.Text = Cell(r, "target_weight");
        SetDate(goalDate, Cell(r, "target_date"));
        SetComboText(goalStatus, Cell(r, "status"));
        goalNotes.Text = Cell(r, "notes");
    }

    private void ClearGoalForm()
    {
        goalId.Clear(); goalTarget.Clear(); goalNotes.Clear(); goalDate.Value = DateTime.Today;
        if (goalMember.Items.Count > 0) goalMember.SelectedIndex = 0;
        if (goalType.Items.Count > 0) goalType.SelectedIndex = 0;
        if (goalStatus.Items.Count > 0) goalStatus.SelectedIndex = 0;
    }

    private void SaveWorkout()
    {
        if (workoutMember.SelectedValue == null) throw new InvalidOperationException("Please add or select a member first.");
        if (string.IsNullOrWhiteSpace(workoutId.Text))
        {
            Database.Execute("INSERT INTO workout_plans(member_id,plan_name,description,difficulty_level,assigned_date) VALUES(@m,@p,@d,@l,@dt)", P("@m", workoutMember.SelectedValue), P("@p", workoutPlan.Text), P("@d", workoutDescription.Text), P("@l", workoutDifficulty.Text), P("@dt", SqlDate(workoutDate)));
        }
        else
        {
            Database.Execute("UPDATE workout_plans SET member_id=@m, plan_name=@p, description=@d, difficulty_level=@l, assigned_date=@dt WHERE plan_id=@id", P("@m", workoutMember.SelectedValue), P("@p", workoutPlan.Text), P("@d", workoutDescription.Text), P("@l", workoutDifficulty.Text), P("@dt", SqlDate(workoutDate)), P("@id", workoutId.Text));
        }
        ClearWorkoutForm();
        LoadAll();
    }

    private void DeleteWorkout()
    {
        var id = SelectedId(workoutsGrid, "plan_id");
        if (id == null) return;
        if (MessageBox.Show("Delete selected workout plan?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
        Database.Execute("DELETE FROM workout_plans WHERE plan_id=@id", P("@id", id));
        ClearWorkoutForm();
        LoadAll();
    }

    private void FillWorkoutForm()
    {
        var r = workoutsGrid.CurrentRow;
        if (r == null || r.IsNewRow) return;
        workoutId.Text = Cell(r, "plan_id");
        TrySetCombo(workoutMember, Cell(r, "member_id"));
        SetComboText(workoutPlan, Cell(r, "plan_name"));
        workoutDescription.Text = Cell(r, "description");
        SetComboText(workoutDifficulty, Cell(r, "difficulty_level"));
        SetDate(workoutDate, Cell(r, "assigned_date"));
    }

    private void ClearWorkoutForm()
    {
        workoutId.Clear(); workoutDescription.Clear(); workoutDate.Value = DateTime.Today;
        if (workoutMember.Items.Count > 0) workoutMember.SelectedIndex = 0;
        if (workoutPlan.Items.Count > 0) workoutPlan.SelectedIndex = 0;
        if (workoutDifficulty.Items.Count > 0) workoutDifficulty.SelectedIndex = 0;
    }

    private static DataGridView Grid() => new()
    {
        Dock = DockStyle.Fill,
        ReadOnly = true,
        AllowUserToAddRows = false,
        AllowUserToDeleteRows = false,
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        MultiSelect = false
    };

    private TabPage Page(string title)
    {
        var p = new TabPage(title) { Padding = new Padding(10) };
        tabs.TabPages.Add(p);
        return p;
    }

    private static TableLayoutPanel FormPanel(int height) => new()
    {
        Dock = DockStyle.Top,
        Height = height,
        AutoScroll = true,
        ColumnCount = 6,
        RowCount = 4
    };

    private static Button ActionButton(string text, Action action)
    {
        var b = new Button { Text = text, Width = 150, Height = 36, Margin = new Padding(8) };
        b.Click += (_, _) =>
        {
            try { action(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Action failed", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        };
        return b;
    }

    private static TextBox Txt() => new() { Width = 180 };
    private static TextBox HiddenBox() => new() { Visible = false };
    private static DateTimePicker DatePicker() => new() { Width = 180, Format = DateTimePickerFormat.Short, Value = DateTime.Today };

    private static ComboBox Combo(params string[] items)
    {
        var c = new ComboBox { Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };
        c.Items.AddRange(items);
        if (items.Length > 0) c.SelectedIndex = 0;
        return c;
    }

    private static void AddLabeled(TableLayoutPanel panel, string label, Control control)
    {
        var box = new FlowLayoutPanel { Width = 210, Height = 68, FlowDirection = FlowDirection.TopDown, Margin = new Padding(8) };
        box.Controls.Add(new Label { Text = label, Width = 195 });
        box.Controls.Add(control);
        panel.Controls.Add(box);
    }

    private static bool ColumnExists(string tableName, string columnName)
    {
        try
        {
            var result = Database.Query("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME=@table AND COLUMN_NAME=@column", P("@table", tableName), P("@column", columnName));
            return Convert.ToInt32(result.Rows[0][0]) > 0;
        }
        catch
        {
            return false;
        }
    }

    private static MySqlParameter P(string name, object? value) => new(name, value ?? DBNull.Value);
    private static string SqlDate(DateTimePicker picker) => picker.Value.ToString("yyyy-MM-dd");

    private static string? SelectedId(DataGridView grid, string column)
    {
        if (grid.CurrentRow == null || !grid.Columns.Contains(column)) return null;
        var value = grid.CurrentRow.Cells[column].Value;
        if (value == null || value == DBNull.Value || string.IsNullOrWhiteSpace(value.ToString())) return null;
        return value.ToString();
    }

    private static string Cell(DataGridViewRow row, string column)
    {
        if (!row.DataGridView.Columns.Contains(column)) return string.Empty;
        var value = row.Cells[column].Value;
        return value == null || value == DBNull.Value ? string.Empty : value.ToString() ?? string.Empty;
    }

    private static void SetDate(DateTimePicker picker, string value)
    {
        if (DateTime.TryParse(value, out var date)) picker.Value = date;
        else picker.Value = DateTime.Today;
    }

    private static void SetComboText(ComboBox combo, int value)
    {
        if (value == 0) return;
        try { combo.SelectedValue = value; } catch { }
    }

    private static void SetComboText(ComboBox combo, string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return;
        if (!combo.Items.Contains(value)) combo.Items.Add(value);
        combo.SelectedItem = value;
    }

    private static void TrySetCombo(ComboBox combo, object? value)
    {
        if (value == null) return;
        try { combo.SelectedValue = value; } catch { }
    }

    private static void Require(string value, string message)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new InvalidOperationException(message);
    }

    private static int ParseInt(string value, string field)
    {
        if (!int.TryParse(value, out var result)) throw new InvalidOperationException(field + " must be a valid whole number.");
        return result;
    }

    private static decimal ParseDecimal(string value, string field)
    {
        if (!decimal.TryParse(value, out var result)) throw new InvalidOperationException(field + " must be a valid number.");
        return result;
    }

    private static string BmiCategory(decimal bmi) => bmi < 18.5m ? "Underweight" : bmi < 25m ? "Normal weight" : bmi < 30m ? "Overweight" : "Obese";

    private static string BpStatus(int s, int d)
    {
        if (s < 120 && d < 80) return "Normal";
        if (s < 130 && d < 80) return "Elevated";
        if (s < 140 || d < 90) return "High blood pressure stage 1";
        return "High blood pressure stage 2";
    }
}

