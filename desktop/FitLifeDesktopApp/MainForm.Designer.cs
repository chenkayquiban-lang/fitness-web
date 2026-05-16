namespace FitLifeDesktopApp;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null!;
    private Panel sidebar;
    private Panel contentPanel;
    private Panel topPanel;
    private Label lblBrand;
    private Label lblUser;
    private Button btnDashboard;
    private Button btnMembers;
    private Button btnHealth;
    private Button btnActivity;
    private Button btnGoals;
    private Button btnClasses;
    private Button btnLogout;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        sidebar = new Panel();
        lblBrand = new Label();
        lblUser = new Label();
        btnDashboard = new Button();
        btnMembers = new Button();
        btnHealth = new Button();
        btnActivity = new Button();
        btnGoals = new Button();
        btnClasses = new Button();
        btnLogout = new Button();
        topPanel = new Panel();
        contentPanel = new Panel();
        sidebar.SuspendLayout();
        SuspendLayout();
        // 
        // sidebar
        // 
        sidebar.BackColor = Color.FromArgb(30, 41, 59);
        sidebar.Controls.Add(lblBrand);
        sidebar.Controls.Add(lblUser);
        sidebar.Controls.Add(btnDashboard);
        sidebar.Controls.Add(btnMembers);
        sidebar.Controls.Add(btnHealth);
        sidebar.Controls.Add(btnActivity);
        sidebar.Controls.Add(btnGoals);
        sidebar.Controls.Add(btnClasses);
        sidebar.Controls.Add(btnLogout);
        sidebar.Dock = DockStyle.Left;
        sidebar.Location = new Point(0, 0);
        sidebar.Margin = new Padding(2);
        sidebar.Name = "sidebar";
        sidebar.Size = new Size(224, 688);
        sidebar.TabIndex = 2;
        // 
        // lblBrand
        // 
        lblBrand.AutoSize = true;
        lblBrand.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
        lblBrand.ForeColor = Color.White;
        lblBrand.Location = new Point(22, 22);
        lblBrand.Margin = new Padding(2, 0, 2, 0);
        lblBrand.Name = "lblBrand";
        lblBrand.Size = new Size(139, 54);
        lblBrand.TabIndex = 0;
        lblBrand.Text = "FitLife";
        // 
        // lblUser
        // 
        lblUser.Font = new Font("Segoe UI", 10F);
        lblUser.ForeColor = Color.FromArgb(203, 213, 225);
        lblUser.Location = new Point(26, 70);
        lblUser.Margin = new Padding(2, 0, 2, 0);
        lblUser.Name = "lblUser";
        lblUser.Size = new Size(176, 32);
        lblUser.TabIndex = 1;
        // 
        // btnDashboard
        // 
        btnDashboard.ForeColor = Color.White;
        btnDashboard.Location = new Point(22, 124);
        btnDashboard.Margin = new Padding(2);
        btnDashboard.Name = "btnDashboard";
        btnDashboard.Size = new Size(176, 37);
        btnDashboard.TabIndex = 2;
        btnDashboard.Text = "Dashboard";
        // 
        // btnMembers
        // 
        btnMembers.ForeColor = Color.White;
        btnMembers.Location = new Point(22, 172);
        btnMembers.Margin = new Padding(2);
        btnMembers.Name = "btnMembers";
        btnMembers.Size = new Size(176, 37);
        btnMembers.TabIndex = 3;
        btnMembers.Text = "Members";
        // 
        // btnHealth
        // 
        btnHealth.ForeColor = Color.White;
        btnHealth.Location = new Point(22, 220);
        btnHealth.Margin = new Padding(2);
        btnHealth.Name = "btnHealth";
        btnHealth.Size = new Size(176, 37);
        btnHealth.TabIndex = 4;
        btnHealth.Text = "Health Records";
        // 
        // btnActivity
        // 
        btnActivity.ForeColor = Color.White;
        btnActivity.Location = new Point(22, 268);
        btnActivity.Margin = new Padding(2);
        btnActivity.Name = "btnActivity";
        btnActivity.Size = new Size(176, 37);
        btnActivity.TabIndex = 5;
        btnActivity.Text = "Activity Logs";
        // 
        // btnGoals
        // 
        btnGoals.ForeColor = Color.White;
        btnGoals.Location = new Point(22, 316);
        btnGoals.Margin = new Padding(2);
        btnGoals.Name = "btnGoals";
        btnGoals.Size = new Size(176, 37);
        btnGoals.TabIndex = 6;
        btnGoals.Text = "Goals";
        // 
        // btnClasses
        // 
        btnClasses.ForeColor = Color.White;
        btnClasses.Location = new Point(22, 364);
        btnClasses.Margin = new Padding(2);
        btnClasses.Name = "btnClasses";
        btnClasses.Size = new Size(176, 37);
        btnClasses.TabIndex = 7;
        btnClasses.Text = "Classes";
        // 
        // btnLogout
        // 
        btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnLogout.BackColor = Color.FromArgb(220, 38, 38);
        btnLogout.Location = new Point(22, 624);
        btnLogout.Margin = new Padding(2);
        btnLogout.Name = "btnLogout";
        btnLogout.Size = new Size(176, 37);
        btnLogout.TabIndex = 8;
        btnLogout.Text = "Logout";
        btnLogout.UseVisualStyleBackColor = false;
        // 
        // topPanel
        // 
        topPanel.BackColor = Color.FromArgb(128, 255, 255);
        topPanel.Dock = DockStyle.Top;
        topPanel.Location = new Point(224, 0);
        topPanel.Margin = new Padding(2);
        topPanel.Name = "topPanel";
        topPanel.Size = new Size(864, 58);
        topPanel.TabIndex = 1;
        // 
        // contentPanel
        // 
        contentPanel.BackColor = Color.FromArgb(248, 250, 252);
        contentPanel.Dock = DockStyle.Fill;
        contentPanel.Location = new Point(224, 58);
        contentPanel.Margin = new Padding(2);
        contentPanel.Name = "contentPanel";
        contentPanel.Padding = new Padding(19);
        contentPanel.Size = new Size(864, 630);
        contentPanel.TabIndex = 0;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1088, 688);
        Controls.Add(contentPanel);
        Controls.Add(topPanel);
        Controls.Add(sidebar);
        Margin = new Padding(2);
        MinimumSize = new Size(1004, 617);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "FitLife Desktop - Connected to Web";
        WindowState = FormWindowState.Maximized;
        sidebar.ResumeLayout(false);
        sidebar.PerformLayout();
        ResumeLayout(false);
    }
}
