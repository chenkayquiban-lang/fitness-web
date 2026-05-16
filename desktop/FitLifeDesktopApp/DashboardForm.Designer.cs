namespace FitLifeDesktopApp;

partial class DashboardForm
{
    private System.ComponentModel.IContainer components = null!;
    private Label lblTitle;
    private Label lblSubtitle;
    private FlowLayoutPanel cards;
    private Label lblMembers;
    private Label lblHealth;
    private Label lblActivity;
    private Label lblGoals;
    private Label lblClasses;
    private DataGridView gridRecent;
    private Label lblRecent;
    private System.Windows.Forms.Timer refreshTimer;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        lblTitle = new Label();
        lblSubtitle = new Label();
        cards = new FlowLayoutPanel();
        lblMembers = new Label();
        lblHealth = new Label();
        lblActivity = new Label();
        lblGoals = new Label();
        lblClasses = new Label();
        lblRecent = new Label();
        gridRecent = new DataGridView();
        refreshTimer = new System.Windows.Forms.Timer(components);
        cards.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridRecent).BeginInit();
        SuspendLayout();
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
        lblTitle.Location = new Point(30, 24);
        lblTitle.Text = "Dashboard";
        lblSubtitle.AutoSize = true;
        lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
        lblSubtitle.Location = new Point(34, 82);
        lblSubtitle.Text = "Live summary from fitlife_db shared by web and desktop";
        cards.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        cards.Location = new Point(30, 128);
        cards.Name = "cards";
        cards.Size = new Size(1180, 135);
        cards.Controls.Add(lblMembers);
        cards.Controls.Add(lblHealth);
        cards.Controls.Add(lblActivity);
        cards.Controls.Add(lblGoals);
        cards.Controls.Add(lblClasses);
        cards.WrapContents = true;
        foreach (var label in new[] { lblMembers, lblHealth, lblActivity, lblGoals, lblClasses })
        {
            label.BackColor = Color.White;
            label.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(15, 23, 42);
            label.Margin = new Padding(0, 0, 18, 18);
            label.Padding = new Padding(20);
            label.Size = new Size(220, 110);
            label.TextAlign = ContentAlignment.MiddleLeft;
        }
        lblRecent.AutoSize = true;
        lblRecent.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblRecent.ForeColor = Color.FromArgb(15, 23, 42);
        lblRecent.Location = new Point(30, 295);
        lblRecent.Text = "Recent Activity Logs";
        gridRecent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        gridRecent.Location = new Point(30, 350);
        gridRecent.Name = "gridRecent";
        gridRecent.Size = new Size(1180, 330);
        refreshTimer.Interval = 1000;
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(248, 250, 252);
        ClientSize = new Size(1240, 720);
        Controls.Add(lblTitle);
        Controls.Add(lblSubtitle);
        Controls.Add(cards);
        Controls.Add(lblRecent);
        Controls.Add(gridRecent);
        Name = "DashboardForm";
        Text = "Dashboard";
        cards.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridRecent).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
