namespace FitLifeDesktopApp;

partial class MembersForm
{
    private System.ComponentModel.IContainer components = null!;
    private Label lblTitle;
    private Panel formPanel;
    private DataGridView grid;
    private Button btnAdd;
    private Button btnUpdate;
    private Button btnDelete;
    private Button btnClear;
    private Label lblStatus;
    private DateTimePicker dtDate;
    private System.Windows.Forms.Timer refreshTimer;
    private Label lbl0;
    private TextBox txtId;
    private Label lbl1;
    private TextBox txtFullName;
    private Label lbl2;
    private TextBox txtUsername;
    private Label lbl3;
    private TextBox txtEmail;
    private Label lbl4;
    private TextBox txtPhone;
    private Label lbl5;
    private TextBox txtAddress;
    private Label lbl6;
    private TextBox txtGender;
    private Label lbl7;
    private TextBox txtHeight;
    private Label lbl8;
    private TextBox txtWeight;
    private Label lbl9;
    private TextBox txtGoal;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        lblTitle = new Label();
        formPanel = new Panel();
        lbl0 = new Label();
        txtId = new TextBox();
        lbl1 = new Label();
        txtFullName = new TextBox();
        lbl2 = new Label();
        txtUsername = new TextBox();
        lbl3 = new Label();
        txtEmail = new TextBox();
        lbl4 = new Label();
        txtPhone = new TextBox();
        lbl5 = new Label();
        txtAddress = new TextBox();
        lbl6 = new Label();
        txtGender = new TextBox();
        lbl7 = new Label();
        txtHeight = new TextBox();
        lbl8 = new Label();
        txtWeight = new TextBox();
        lbl9 = new Label();
        txtGoal = new TextBox();
        dtDate = new DateTimePicker();
        btnAdd = new Button();
        btnUpdate = new Button();
        btnDelete = new Button();
        btnClear = new Button();
        lblStatus = new Label();
        grid = new DataGridView();
        refreshTimer = new System.Windows.Forms.Timer(components);
        formPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
        lblTitle.Location = new Point(24, 16);
        lblTitle.Margin = new Padding(2, 0, 2, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(201, 54);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Members";
        // 
        // formPanel
        // 
        formPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        formPanel.BackColor = Color.White;
        formPanel.Controls.Add(lbl0);
        formPanel.Controls.Add(txtId);
        formPanel.Controls.Add(lbl1);
        formPanel.Controls.Add(txtFullName);
        formPanel.Controls.Add(lbl2);
        formPanel.Controls.Add(txtUsername);
        formPanel.Controls.Add(lbl3);
        formPanel.Controls.Add(txtEmail);
        formPanel.Controls.Add(lbl4);
        formPanel.Controls.Add(txtPhone);
        formPanel.Controls.Add(lbl5);
        formPanel.Controls.Add(txtAddress);
        formPanel.Controls.Add(lbl6);
        formPanel.Controls.Add(txtGender);
        formPanel.Controls.Add(lbl7);
        formPanel.Controls.Add(txtHeight);
        formPanel.Controls.Add(lbl8);
        formPanel.Controls.Add(txtWeight);
        formPanel.Controls.Add(lbl9);
        formPanel.Controls.Add(txtGoal);
        formPanel.Controls.Add(dtDate);
        formPanel.Controls.Add(btnAdd);
        formPanel.Controls.Add(btnUpdate);
        formPanel.Controls.Add(btnDelete);
        formPanel.Controls.Add(btnClear);
        formPanel.Controls.Add(lblStatus);
        formPanel.Location = new Point(24, 96);
        formPanel.Margin = new Padding(2, 2, 2, 2);
        formPanel.Name = "formPanel";
        formPanel.Size = new Size(944, 313);
        formPanel.TabIndex = 2;
        // 
        // lbl0
        // 
        lbl0.AutoSize = true;
        lbl0.ForeColor = Color.FromArgb(71, 85, 105);
        lbl0.Location = new Point(24, 19);
        lbl0.Margin = new Padding(2, 0, 2, 0);
        lbl0.Name = "lbl0";
        lbl0.Size = new Size(24, 20);
        lbl0.TabIndex = 0;
        lbl0.Text = "ID";
        // 
        // txtId
        // 
        txtId.Location = new Point(24, 41);
        txtId.Margin = new Padding(2, 2, 2, 2);
        txtId.Name = "txtId";
        txtId.Size = new Size(193, 27);
        txtId.TabIndex = 1;
        // 
        // lbl1
        // 
        lbl1.AutoSize = true;
        lbl1.ForeColor = Color.FromArgb(71, 85, 105);
        lbl1.Location = new Point(240, 19);
        lbl1.Margin = new Padding(2, 0, 2, 0);
        lbl1.Name = "lbl1";
        lbl1.Size = new Size(76, 20);
        lbl1.TabIndex = 2;
        lbl1.Text = "Full Name";
        // 
        // txtFullName
        // 
        txtFullName.Location = new Point(240, 41);
        txtFullName.Margin = new Padding(2, 2, 2, 2);
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new Size(193, 27);
        txtFullName.TabIndex = 3;
        // 
        // lbl2
        // 
        lbl2.AutoSize = true;
        lbl2.ForeColor = Color.FromArgb(71, 85, 105);
        lbl2.Location = new Point(456, 19);
        lbl2.Margin = new Padding(2, 0, 2, 0);
        lbl2.Name = "lbl2";
        lbl2.Size = new Size(75, 20);
        lbl2.TabIndex = 4;
        lbl2.Text = "Username";
        // 
        // txtUsername
        // 
        txtUsername.Location = new Point(456, 41);
        txtUsername.Margin = new Padding(2, 2, 2, 2);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(193, 27);
        txtUsername.TabIndex = 5;
        // 
        // lbl3
        // 
        lbl3.AutoSize = true;
        lbl3.ForeColor = Color.FromArgb(71, 85, 105);
        lbl3.Location = new Point(24, 74);
        lbl3.Margin = new Padding(2, 0, 2, 0);
        lbl3.Name = "lbl3";
        lbl3.Size = new Size(46, 20);
        lbl3.TabIndex = 6;
        lbl3.Text = "Email";
        // 
        // txtEmail
        // 
        txtEmail.Location = new Point(24, 95);
        txtEmail.Margin = new Padding(2, 2, 2, 2);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(193, 27);
        txtEmail.TabIndex = 7;
        // 
        // lbl4
        // 
        lbl4.AutoSize = true;
        lbl4.ForeColor = Color.FromArgb(71, 85, 105);
        lbl4.Location = new Point(240, 74);
        lbl4.Margin = new Padding(2, 0, 2, 0);
        lbl4.Name = "lbl4";
        lbl4.Size = new Size(50, 20);
        lbl4.TabIndex = 8;
        lbl4.Text = "Phone";
        // 
        // txtPhone
        // 
        txtPhone.Location = new Point(240, 95);
        txtPhone.Margin = new Padding(2, 2, 2, 2);
        txtPhone.Name = "txtPhone";
        txtPhone.Size = new Size(193, 27);
        txtPhone.TabIndex = 9;
        // 
        // lbl5
        // 
        lbl5.AutoSize = true;
        lbl5.ForeColor = Color.FromArgb(71, 85, 105);
        lbl5.Location = new Point(456, 74);
        lbl5.Margin = new Padding(2, 0, 2, 0);
        lbl5.Name = "lbl5";
        lbl5.Size = new Size(62, 20);
        lbl5.TabIndex = 10;
        lbl5.Text = "Address";
        // 
        // txtAddress
        // 
        txtAddress.Location = new Point(456, 95);
        txtAddress.Margin = new Padding(2, 2, 2, 2);
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new Size(193, 27);
        txtAddress.TabIndex = 11;
        // 
        // lbl6
        // 
        lbl6.AutoSize = true;
        lbl6.ForeColor = Color.FromArgb(71, 85, 105);
        lbl6.Location = new Point(24, 128);
        lbl6.Margin = new Padding(2, 0, 2, 0);
        lbl6.Name = "lbl6";
        lbl6.Size = new Size(57, 20);
        lbl6.TabIndex = 12;
        lbl6.Text = "Gender";
        // 
        // txtGender
        // 
        txtGender.Location = new Point(24, 150);
        txtGender.Margin = new Padding(2, 2, 2, 2);
        txtGender.Name = "txtGender";
        txtGender.Size = new Size(193, 27);
        txtGender.TabIndex = 13;
        // 
        // lbl7
        // 
        lbl7.AutoSize = true;
        lbl7.ForeColor = Color.FromArgb(71, 85, 105);
        lbl7.Location = new Point(240, 128);
        lbl7.Margin = new Padding(2, 0, 2, 0);
        lbl7.Name = "lbl7";
        lbl7.Size = new Size(78, 20);
        lbl7.TabIndex = 14;
        lbl7.Text = "Height cm";
        // 
        // txtHeight
        // 
        txtHeight.Location = new Point(240, 150);
        txtHeight.Margin = new Padding(2, 2, 2, 2);
        txtHeight.Name = "txtHeight";
        txtHeight.Size = new Size(193, 27);
        txtHeight.TabIndex = 15;
        // 
        // lbl8
        // 
        lbl8.AutoSize = true;
        lbl8.ForeColor = Color.FromArgb(71, 85, 105);
        lbl8.Location = new Point(456, 128);
        lbl8.Margin = new Padding(2, 0, 2, 0);
        lbl8.Name = "lbl8";
        lbl8.Size = new Size(76, 20);
        lbl8.TabIndex = 16;
        lbl8.Text = "Weight kg";
        // 
        // txtWeight
        // 
        txtWeight.Location = new Point(456, 150);
        txtWeight.Margin = new Padding(2, 2, 2, 2);
        txtWeight.Name = "txtWeight";
        txtWeight.Size = new Size(193, 27);
        txtWeight.TabIndex = 17;
        // 
        // lbl9
        // 
        lbl9.AutoSize = true;
        lbl9.ForeColor = Color.FromArgb(71, 85, 105);
        lbl9.Location = new Point(24, 182);
        lbl9.Margin = new Padding(2, 0, 2, 0);
        lbl9.Name = "lbl9";
        lbl9.Size = new Size(40, 20);
        lbl9.TabIndex = 18;
        lbl9.Text = "Goal";
        // 
        // txtGoal
        // 
        txtGoal.Location = new Point(24, 204);
        txtGoal.Margin = new Padding(2, 2, 2, 2);
        txtGoal.Name = "txtGoal";
        txtGoal.Size = new Size(193, 27);
        txtGoal.TabIndex = 19;
        // 
        // dtDate
        // 
        dtDate.Location = new Point(672, 41);
        dtDate.Margin = new Padding(2, 2, 2, 2);
        dtDate.Name = "dtDate";
        dtDate.Size = new Size(225, 27);
        dtDate.TabIndex = 20;
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(24, 254);
        btnAdd.Margin = new Padding(2, 2, 2, 2);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(96, 34);
        btnAdd.TabIndex = 21;
        btnAdd.Text = "Add";
        // 
        // btnUpdate
        // 
        btnUpdate.Location = new Point(130, 254);
        btnUpdate.Margin = new Padding(2, 2, 2, 2);
        btnUpdate.Name = "btnUpdate";
        btnUpdate.Size = new Size(96, 34);
        btnUpdate.TabIndex = 22;
        btnUpdate.Text = "Update";
        // 
        // btnDelete
        // 
        btnDelete.BackColor = Color.FromArgb(220, 38, 38);
        btnDelete.Location = new Point(235, 254);
        btnDelete.Margin = new Padding(2, 2, 2, 2);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(96, 34);
        btnDelete.TabIndex = 23;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = false;
        // 
        // btnClear
        // 
        btnClear.BackColor = Color.FromArgb(100, 116, 139);
        btnClear.Location = new Point(341, 254);
        btnClear.Margin = new Padding(2, 2, 2, 2);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(96, 34);
        btnClear.TabIndex = 24;
        btnClear.Text = "Clear";
        btnClear.UseVisualStyleBackColor = false;
        // 
        // lblStatus
        // 
        lblStatus.ForeColor = Color.FromArgb(100, 116, 139);
        lblStatus.Location = new Point(456, 258);
        lblStatus.Margin = new Padding(2, 0, 2, 0);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(448, 34);
        lblStatus.TabIndex = 25;
        lblStatus.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // grid
        // 
        grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        grid.ColumnHeadersHeight = 29;
        grid.Location = new Point(24, 433);
        grid.Margin = new Padding(2, 2, 2, 2);
        grid.Name = "grid";
        grid.RowHeadersWidth = 51;
        grid.Size = new Size(944, 224);
        grid.TabIndex = 3;
        // 
        // refreshTimer
        // 
        refreshTimer.Interval = 1000;
        // 
        // MembersForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(128, 255, 255);
        ClientSize = new Size(992, 673);
        Controls.Add(lblTitle);
        Controls.Add(formPanel);
        Controls.Add(grid);
        Margin = new Padding(2, 2, 2, 2);
        Name = "MembersForm";
        Text = "Members";
        formPanel.ResumeLayout(false);
        formPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)grid).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
