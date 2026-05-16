using MySql.Data.MySqlClient;

namespace FitLifeDesktopApp;

public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
        ModernTheme.Apply(this);
        btnLogin.Click += BtnLogin_Click;
        AcceptButton = btnLogin;
    }

    private void BtnLogin_Click(object? sender, EventArgs e)
    {
        try
        {
            var user = Convert.ToString(Database.Scalar(
                "SELECT username FROM users WHERE username=@u AND password=MD5(@p) AND status='active' LIMIT 1",
                Database.P("@u", txtUsername.Text), Database.P("@p", txtPassword.Text)));
            if (!string.IsNullOrWhiteSpace(user))
            {
                Hide();
                new MainForm(user).ShowDialog();
                Close();
            }
            else statusLabel.Text = "Invalid login. Use user / user123.";
        }
        catch (Exception ex)
        {
            statusLabel.Text = "Database connection error: " + ex.Message;
        }
    }
}
