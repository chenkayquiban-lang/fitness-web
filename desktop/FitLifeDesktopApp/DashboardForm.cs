namespace FitLifeDesktopApp;

public partial class DashboardForm : Form
{
    public DashboardForm()
    {
        InitializeComponent();
        ModernTheme.Apply(this);
        refreshTimer.Tick += (_, _) => LoadDashboard();
        if (!DesignModeHelper.IsInDesignMode)
        {
            LoadDashboard();
            refreshTimer.Start();
        }
    }
    private void LoadDashboard()
    {
        try
        {
            lblMembers.Text = "Members\n" + Count("members");
            lblHealth.Text = "Health\n" + Count("health_records");
            lblActivity.Text = "Activity\n" + Count("activity_logs");
            lblGoals.Text = "Goals\n" + Count("goals");
            lblClasses.Text = "Classes\n" + Count("classes");
            gridRecent.DataSource = Database.Query("SELECT a.id,u.full_name,a.log_date,a.steps,a.workout,a.calories_burned,a.weight_kg FROM activity_logs a JOIN members m ON m.id=a.member_id JOIN users u ON u.id=m.user_id ORDER BY a.id DESC LIMIT 20");
        }
        catch { }
    }
    private static int Count(string table) => Convert.ToInt32(Database.Scalar("SELECT COUNT(*) FROM " + table) ?? 0);
}
