namespace FitLifeDesktopApp;

partial class LoginForm
{
    private System.ComponentModel.IContainer components = null!;
    private Panel heroPanel;
    private Panel card;
    private Label heroTitle;
    private Label titleLabel;
    private Label subtitleLabel;
    private Label userLabel;
    private TextBox txtUsername;
    private Label passLabel;
    private TextBox txtPassword;
    private Button btnLogin;
    private Label statusLabel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        heroPanel = new Panel();
        heroTitle = new Label();
        card = new Panel();
        titleLabel = new Label();
        subtitleLabel = new Label();
        userLabel = new Label();
        txtUsername = new TextBox();
        passLabel = new Label();
        txtPassword = new TextBox();
        btnLogin = new Button();
        statusLabel = new Label();
        heroPanel.SuspendLayout();
        card.SuspendLayout();
        SuspendLayout();
        // 
        // heroPanel
        // 
        heroPanel.BackColor = Color.FromArgb(30, 41, 59);
        heroPanel.Controls.Add(heroTitle);
        heroPanel.Dock = DockStyle.Left;
        heroPanel.Location = new Point(0, 0);
        heroPanel.Margin = new Padding(2, 2, 2, 2);
        heroPanel.Name = "heroPanel";
        heroPanel.Size = new Size(336, 512);
        heroPanel.TabIndex = 1;
        // 
        // heroTitle
        // 
        heroTitle.AutoSize = true;
        heroTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
        heroTitle.ForeColor = Color.White;
        heroTitle.Location = new Point(35, 144);
        heroTitle.Margin = new Padding(2, 0, 2, 0);
        heroTitle.Name = "heroTitle";
        heroTitle.Size = new Size(162, 62);
        heroTitle.TabIndex = 0;
        heroTitle.Text = "FitLife";
        // 
        // card
        // 
        card.BackColor = Color.White;
        card.Controls.Add(titleLabel);
        card.Controls.Add(subtitleLabel);
        card.Controls.Add(userLabel);
        card.Controls.Add(txtUsername);
        card.Controls.Add(passLabel);
        card.Controls.Add(txtPassword);
        card.Controls.Add(btnLogin);
        card.Controls.Add(statusLabel);
        card.Location = new Point(416, 84);
        card.Margin = new Padding(2, 2, 2, 2);
        card.Name = "card";
        card.Size = new Size(368, 344);
        card.TabIndex = 0;
        // 
        // titleLabel
        // 
        titleLabel.AutoSize = true;
        titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
        titleLabel.ForeColor = Color.FromArgb(15, 23, 42);
        titleLabel.Location = new Point(34, 30);
        titleLabel.Margin = new Padding(2, 0, 2, 0);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(297, 54);
        titleLabel.TabIndex = 0;
        titleLabel.Text = "Welcome Back";
        // 
        // subtitleLabel
        // 
        subtitleLabel.AutoSize = true;
        subtitleLabel.ForeColor = Color.FromArgb(100, 116, 139);
        subtitleLabel.Location = new Point(37, 76);
        subtitleLabel.Margin = new Padding(2, 0, 2, 0);
        subtitleLabel.Name = "subtitleLabel";
        subtitleLabel.Size = new Size(145, 20);
        subtitleLabel.TabIndex = 1;
        subtitleLabel.Text = "Login: user / user123";
        // 
        // userLabel
        // 
        userLabel.AutoSize = true;
        userLabel.Location = new Point(37, 120);
        userLabel.Margin = new Padding(2, 0, 2, 0);
        userLabel.Name = "userLabel";
        userLabel.Size = new Size(75, 20);
        userLabel.TabIndex = 2;
        userLabel.Text = "Username";
        // 
        // txtUsername
        // 
        txtUsername.Location = new Point(37, 142);
        txtUsername.Margin = new Padding(2, 2, 2, 2);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(293, 27);
        txtUsername.TabIndex = 3;
        txtUsername.Text = "user";
        // 
        // passLabel
        // 
        passLabel.AutoSize = true;
        passLabel.Location = new Point(37, 184);
        passLabel.Margin = new Padding(2, 0, 2, 0);
        passLabel.Name = "passLabel";
        passLabel.Size = new Size(70, 20);
        passLabel.TabIndex = 4;
        passLabel.Text = "Password";
        // 
        // txtPassword
        // 
        txtPassword.Location = new Point(37, 206);
        txtPassword.Margin = new Padding(2, 2, 2, 2);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '●';
        txtPassword.Size = new Size(293, 27);
        txtPassword.TabIndex = 5;
        txtPassword.Text = "user123";
        // 
        // btnLogin
        // 
        btnLogin.Location = new Point(37, 256);
        btnLogin.Margin = new Padding(2, 2, 2, 2);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(292, 37);
        btnLogin.TabIndex = 6;
        btnLogin.Text = "Login";
        btnLogin.UseVisualStyleBackColor = false;
        // 
        // statusLabel
        // 
        statusLabel.ForeColor = Color.Firebrick;
        statusLabel.Location = new Point(37, 301);
        statusLabel.Margin = new Padding(2, 0, 2, 0);
        statusLabel.Name = "statusLabel";
        statusLabel.Size = new Size(292, 29);
        statusLabel.TabIndex = 7;
        statusLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // LoginForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(248, 250, 252);
        ClientSize = new Size(832, 512);
        Controls.Add(card);
        Controls.Add(heroPanel);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(2, 2, 2, 2);
        MaximizeBox = false;
        Name = "LoginForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "FitLife Login";
        heroPanel.ResumeLayout(false);
        heroPanel.PerformLayout();
        card.ResumeLayout(false);
        card.PerformLayout();
        ResumeLayout(false);
    }
}
