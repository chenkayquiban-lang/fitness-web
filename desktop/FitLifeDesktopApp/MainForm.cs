namespace FitLifeDesktopApp;

public partial class MainForm : Form
{
    private readonly string _username;
    public MainForm(string username = "user")
    {
        _username = username;
        InitializeComponent();
        ModernTheme.Apply(this);
        foreach (Control c in sidebar.Controls) if (c is Button b) b.BackColor = Color.FromArgb(51, 65, 85);
        lblUser.Text = "Logged in as " + _username;
        btnDashboard.Click += (_, _) => ShowChild(new DashboardForm());
        btnMembers.Click += (_, _) => ShowChild(new MembersForm());
        btnHealth.Click += (_, _) => ShowChild(new HealthForm());
        btnActivity.Click += (_, _) => ShowChild(new ActivityForm());
        btnGoals.Click += (_, _) => ShowChild(new GoalsForm());
        btnClasses.Click += (_, _) => ShowChild(new ClassesForm());
        btnLogout.Click += (_, _) => Close();
        if (!DesignModeHelper.IsInDesignMode) ShowChild(new DashboardForm());
    }

    private void ShowChild(Form child)
    {
        contentPanel.Controls.Clear();
        child.TopLevel = false;
        child.FormBorderStyle = FormBorderStyle.None;
        child.Dock = DockStyle.Fill;
        contentPanel.Controls.Add(child);
        child.Show();
    }
}
