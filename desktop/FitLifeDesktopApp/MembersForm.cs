using MySql.Data.MySqlClient;

namespace FitLifeDesktopApp;

public partial class MembersForm : Form
{
    public MembersForm()
    {
        InitializeComponent();
        ModernTheme.Apply(this);
        txtId.ReadOnly = true;

        grid.CellClick += (_, _) => Pick();
        btnAdd.Click += (_, _) => Save(false);
        btnUpdate.Click += (_, _) => Save(true);
        btnDelete.Click += (_, _) => Delete();
        btnClear.Click += (_, _) => ClearFields();
        refreshTimer.Tick += (_, _) => LoadData();

        if (!DesignModeHelper.IsInDesignMode)
        {
            LoadData();
            refreshTimer.Start();
        }
    }

    private void LoadData()
    {
        try
        {
            grid.DataSource = Database.Query(@"
                SELECT 
                    m.id,
                    m.user_id,
                    u.full_name,
                    u.username,
                    u.email,
                    m.phone,
                    m.address,
                    m.gender,
                    m.height_cm,
                    m.weight_kg,
                    m.goal
                FROM members m
                JOIN users u ON u.id = m.user_id
                WHERE u.role='user'
                ORDER BY m.id DESC
            ");

            lblStatus.Text = "CRUD sync active: desktop and web use the same API/database.";
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }

    private void Pick()
    {
        if (grid.CurrentRow == null) return;

        txtId.Text = S("id");
        txtFullName.Text = S("full_name");
        txtUsername.Text = S("username");
        txtEmail.Text = S("email");
        txtPhone.Text = S("phone");
        txtAddress.Text = S("address");
        txtGender.Text = S("gender");
        txtHeight.Text = S("height_cm");
        txtWeight.Text = S("weight_kg");
        txtGoal.Text = S("goal");
    }

    private string S(string col) => grid.CurrentRow?.Cells[col]?.Value?.ToString() ?? "";

    private void Save(bool update)
    {
        try
        {
            var name = txtFullName.Text.Trim();
            var email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                lblStatus.Text = "Full name and email are required.";
                return;
            }

            // IMPORTANT: username is always same as email to avoid blank/duplicate username errors.
            txtUsername.Text = email;

            if (update)
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    lblStatus.Text = "Select a member to update.";
                    return;
                }

                var duplicate = Convert.ToString(Database.Scalar(@"
                    SELECT u.id
                    FROM users u
                    JOIN members m ON m.user_id = u.id
                    WHERE (u.email=@e OR u.username=@e)
                    AND m.id != @id
                    LIMIT 1
                ", Database.P("@e", email), Database.P("@id", txtId.Text)));

                if (!string.IsNullOrWhiteSpace(duplicate))
                {
                    lblStatus.Text = "Email already exists.";
                    return;
                }

                Database.Execute(@"
                    UPDATE users u
                    JOIN members m ON m.user_id = u.id
                    SET 
                        u.full_name=@n,
                        u.username=@e,
                        u.email=@e,
                        m.phone=@p,
                        m.address=@a,
                        m.gender=@g,
                        m.height_cm=@h,
                        m.weight_kg=@w,
                        m.goal=@go
                    WHERE m.id=@id
                ",
                    Database.P("@n", name),
                    Database.P("@e", email),
                    Database.P("@p", txtPhone.Text),
                    Database.P("@a", txtAddress.Text),
                    Database.P("@g", txtGender.Text),
                    Database.P("@h", txtHeight.Text),
                    Database.P("@w", txtWeight.Text),
                    Database.P("@go", txtGoal.Text),
                    Database.P("@id", txtId.Text)
                );

                lblStatus.Text = "Member updated and synced to web.";
            }
            else
            {
                // If user exists but has no member row, complete the missing member profile instead of erroring.
                var existingUserId = Convert.ToString(Database.Scalar(@"
                    SELECT id FROM users
                    WHERE email=@e OR username=@e
                    LIMIT 1
                ", Database.P("@e", email)));

                if (!string.IsNullOrWhiteSpace(existingUserId))
                {
                    var existingMemberId = Convert.ToString(Database.Scalar(@"
                        SELECT id FROM members
                        WHERE user_id=@uid
                        LIMIT 1
                    ", Database.P("@uid", existingUserId)));

                    if (!string.IsNullOrWhiteSpace(existingMemberId))
                    {
                        lblStatus.Text = "Email already exists.";
                        return;
                    }

                    Database.Execute(@"
                        UPDATE users
                        SET full_name=@n, username=@e, email=@e, role='user', status='active'
                        WHERE id=@uid
                    ", Database.P("@n", name), Database.P("@e", email), Database.P("@uid", existingUserId));

                    Database.Execute(@"
                        INSERT INTO members(user_id,phone,address,gender,height_cm,weight_kg,goal)
                        VALUES(@uid,@p,@a,@g,@h,@w,@go)
                    ",
                        Database.P("@uid", existingUserId),
                        Database.P("@p", txtPhone.Text),
                        Database.P("@a", txtAddress.Text),
                        Database.P("@g", txtGender.Text),
                        Database.P("@h", txtHeight.Text),
                        Database.P("@w", txtWeight.Text),
                        Database.P("@go", txtGoal.Text)
                    );
                }
                else
                {
                    Database.Execute(@"
                        INSERT INTO users(full_name,username,email,password,role,status)
                        VALUES(@n,@e,@e,MD5('user123'),'user','active')
                    ", Database.P("@n", name), Database.P("@e", email));

                    var uid = Database.Scalar("SELECT LAST_INSERT_ID()");

                    Database.Execute(@"
                        INSERT INTO members(user_id,phone,address,gender,height_cm,weight_kg,goal)
                        VALUES(@uid,@p,@a,@g,@h,@w,@go)
                    ",
                        Database.P("@uid", uid),
                        Database.P("@p", txtPhone.Text),
                        Database.P("@a", txtAddress.Text),
                        Database.P("@g", txtGender.Text),
                        Database.P("@h", txtHeight.Text),
                        Database.P("@w", txtWeight.Text),
                        Database.P("@go", txtGoal.Text)
                    );
                }

                lblStatus.Text = "Member added and synced to web.";
            }

            LoadData();
            ClearFields();
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }

    private void Delete()
    {
        if (string.IsNullOrWhiteSpace(txtId.Text)) return;

        try
        {
            var userId = S("user_id");

            // Delete member row first, then user row. This works even without cascade constraints.
            Database.Execute("DELETE FROM members WHERE id=@id", Database.P("@id", txtId.Text));

            if (!string.IsNullOrWhiteSpace(userId))
            {
                Database.Execute("DELETE FROM users WHERE id=@uid AND role='user'", Database.P("@uid", userId));
            }

            lblStatus.Text = "Member deleted and synced to web.";
            LoadData();
            ClearFields();
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }

    private void ClearFields()
    {
        foreach (Control c in formPanel.Controls)
        {
            if (c is TextBox t) t.Clear();
        }
    }
}
