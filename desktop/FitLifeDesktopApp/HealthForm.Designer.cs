namespace FitLifeDesktopApp;

partial class HealthForm
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
    private TextBox txtMemberId;
    private Label lbl2;
    private TextBox txtSystolic;
    private Label lbl3;
    private TextBox txtDiastolic;
    private Label lbl4;
    private TextBox txtHeart;
    private Label lbl5;
    private TextBox txtTemp;
    private Label lbl6;
    private TextBox txtSugar;
    private Label lbl7;
    private TextBox txtOxygen;
    private Label lbl8;
    private TextBox txtWeight;
    private Label lbl9;
    private TextBox txtBmi;
    private Label lbl10;
    private TextBox txtStatus;
    private Label lbl11;
    private TextBox txtNotes;

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
        txtMemberId = new TextBox();
        lbl2 = new Label();
        txtSystolic = new TextBox();
        lbl3 = new Label();
        txtDiastolic = new TextBox();
        lbl4 = new Label();
        txtHeart = new TextBox();
        lbl5 = new Label();
        txtTemp = new TextBox();
        lbl6 = new Label();
        txtSugar = new TextBox();
        lbl7 = new Label();
        txtOxygen = new TextBox();
        lbl8 = new Label();
        txtWeight = new TextBox();
        lbl9 = new Label();
        txtBmi = new TextBox();
        lbl10 = new Label();
        txtStatus = new TextBox();
        lbl11 = new Label();
        txtNotes = new TextBox();
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
        lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(31, 42, 68);
        lblTitle.Location = new Point(24, 16);
        lblTitle.Margin = new Padding(2, 0, 2, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(137, 50);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Health";
        // 
        // formPanel
        // 
        formPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        formPanel.BackColor = Color.White;
        formPanel.Controls.Add(lbl0);
        formPanel.Controls.Add(txtId);
        formPanel.Controls.Add(lbl1);
        formPanel.Controls.Add(txtMemberId);
        formPanel.Controls.Add(lbl2);
        formPanel.Controls.Add(txtSystolic);
        formPanel.Controls.Add(lbl3);
        formPanel.Controls.Add(txtDiastolic);
        formPanel.Controls.Add(lbl4);
        formPanel.Controls.Add(txtHeart);
        formPanel.Controls.Add(lbl5);
        formPanel.Controls.Add(txtTemp);
        formPanel.Controls.Add(lbl6);
        formPanel.Controls.Add(txtSugar);
        formPanel.Controls.Add(lbl7);
        formPanel.Controls.Add(txtOxygen);
        formPanel.Controls.Add(lbl8);
        formPanel.Controls.Add(txtWeight);
        formPanel.Controls.Add(lbl9);
        formPanel.Controls.Add(txtBmi);
        formPanel.Controls.Add(lbl10);
        formPanel.Controls.Add(txtStatus);
        formPanel.Controls.Add(lbl11);
        formPanel.Controls.Add(txtNotes);
        formPanel.Controls.Add(dtDate);
        formPanel.Controls.Add(btnAdd);
        formPanel.Controls.Add(btnUpdate);
        formPanel.Controls.Add(btnDelete);
        formPanel.Controls.Add(btnClear);
        formPanel.Controls.Add(lblStatus);
        formPanel.Location = new Point(24, 88);
        formPanel.Margin = new Padding(2);
        formPanel.Name = "formPanel";
        formPanel.Size = new Size(813, 399);
        formPanel.TabIndex = 2;
        // 
        // lbl0
        // 
        lbl0.AutoSize = true;
        lbl0.Location = new Point(24, 84);
        lbl0.Margin = new Padding(2, 0, 2, 0);
        lbl0.Name = "lbl0";
        lbl0.Size = new Size(24, 20);
        lbl0.TabIndex = 0;
        lbl0.Text = "ID";
        // 
        // txtId
        // 
        txtId.Location = new Point(24, 104);
        txtId.Margin = new Padding(2);
        txtId.Name = "txtId";
        txtId.Size = new Size(177, 27);
        txtId.TabIndex = 1;
        // 
        // lbl1
        // 
        lbl1.AutoSize = true;
        lbl1.Location = new Point(224, 84);
        lbl1.Margin = new Padding(2, 0, 2, 0);
        lbl1.Name = "lbl1";
        lbl1.Size = new Size(84, 20);
        lbl1.TabIndex = 2;
        lbl1.Text = "Member ID";
        // 
        // txtMemberId
        // 
        txtMemberId.Location = new Point(224, 104);
        txtMemberId.Margin = new Padding(2);
        txtMemberId.Name = "txtMemberId";
        txtMemberId.Size = new Size(177, 27);
        txtMemberId.TabIndex = 3;
        // 
        // lbl2
        // 
        lbl2.AutoSize = true;
        lbl2.Location = new Point(24, 134);
        lbl2.Margin = new Padding(2, 0, 2, 0);
        lbl2.Name = "lbl2";
        lbl2.Size = new Size(59, 20);
        lbl2.TabIndex = 4;
        lbl2.Text = "Systolic";
        // 
        // txtSystolic
        // 
        txtSystolic.Location = new Point(24, 154);
        txtSystolic.Margin = new Padding(2);
        txtSystolic.Name = "txtSystolic";
        txtSystolic.Size = new Size(177, 27);
        txtSystolic.TabIndex = 5;
        // 
        // lbl3
        // 
        lbl3.AutoSize = true;
        lbl3.Location = new Point(224, 134);
        lbl3.Margin = new Padding(2, 0, 2, 0);
        lbl3.Name = "lbl3";
        lbl3.Size = new Size(67, 20);
        lbl3.TabIndex = 6;
        lbl3.Text = "Diastolic";
        // 
        // txtDiastolic
        // 
        txtDiastolic.Location = new Point(224, 154);
        txtDiastolic.Margin = new Padding(2);
        txtDiastolic.Name = "txtDiastolic";
        txtDiastolic.Size = new Size(177, 27);
        txtDiastolic.TabIndex = 7;
        // 
        // lbl4
        // 
        lbl4.AutoSize = true;
        lbl4.Location = new Point(24, 183);
        lbl4.Margin = new Padding(2, 0, 2, 0);
        lbl4.Name = "lbl4";
        lbl4.Size = new Size(80, 20);
        lbl4.TabIndex = 8;
        lbl4.Text = "Heart Rate";
        // 
        // txtHeart
        // 
        txtHeart.Location = new Point(24, 203);
        txtHeart.Margin = new Padding(2);
        txtHeart.Name = "txtHeart";
        txtHeart.Size = new Size(177, 27);
        txtHeart.TabIndex = 9;
        // 
        // lbl5
        // 
        lbl5.AutoSize = true;
        lbl5.Location = new Point(224, 183);
        lbl5.Margin = new Padding(2, 0, 2, 0);
        lbl5.Name = "lbl5";
        lbl5.Size = new Size(46, 20);
        lbl5.TabIndex = 10;
        lbl5.Text = "Temp";
        // 
        // txtTemp
        // 
        txtTemp.Location = new Point(224, 203);
        txtTemp.Margin = new Padding(2);
        txtTemp.Name = "txtTemp";
        txtTemp.Size = new Size(177, 27);
        txtTemp.TabIndex = 11;
        // 
        // lbl6
        // 
        lbl6.AutoSize = true;
        lbl6.Location = new Point(24, 233);
        lbl6.Margin = new Padding(2, 0, 2, 0);
        lbl6.Name = "lbl6";
        lbl6.Size = new Size(91, 20);
        lbl6.TabIndex = 12;
        lbl6.Text = "Blood Sugar";
        // 
        // txtSugar
        // 
        txtSugar.Location = new Point(24, 253);
        txtSugar.Margin = new Padding(2);
        txtSugar.Name = "txtSugar";
        txtSugar.Size = new Size(177, 27);
        txtSugar.TabIndex = 13;
        // 
        // lbl7
        // 
        lbl7.AutoSize = true;
        lbl7.Location = new Point(224, 233);
        lbl7.Margin = new Padding(2, 0, 2, 0);
        lbl7.Name = "lbl7";
        lbl7.Size = new Size(59, 20);
        lbl7.TabIndex = 14;
        lbl7.Text = "Oxygen";
        // 
        // txtOxygen
        // 
        txtOxygen.Location = new Point(224, 253);
        txtOxygen.Margin = new Padding(2);
        txtOxygen.Name = "txtOxygen";
        txtOxygen.Size = new Size(177, 27);
        txtOxygen.TabIndex = 15;
        // 
        // lbl8
        // 
        lbl8.AutoSize = true;
        lbl8.Location = new Point(24, 282);
        lbl8.Margin = new Padding(2, 0, 2, 0);
        lbl8.Name = "lbl8";
        lbl8.Size = new Size(76, 20);
        lbl8.TabIndex = 16;
        lbl8.Text = "Weight kg";
        // 
        // txtWeight
        // 
        txtWeight.Location = new Point(24, 302);
        txtWeight.Margin = new Padding(2);
        txtWeight.Name = "txtWeight";
        txtWeight.Size = new Size(177, 27);
        txtWeight.TabIndex = 17;
        // 
        // lbl9
        // 
        lbl9.AutoSize = true;
        lbl9.Location = new Point(224, 282);
        lbl9.Margin = new Padding(2, 0, 2, 0);
        lbl9.Name = "lbl9";
        lbl9.Size = new Size(35, 20);
        lbl9.TabIndex = 18;
        lbl9.Text = "BMI";
        // 
        // txtBmi
        // 
        txtBmi.Location = new Point(224, 302);
        txtBmi.Margin = new Padding(2);
        txtBmi.Name = "txtBmi";
        txtBmi.Size = new Size(177, 27);
        txtBmi.TabIndex = 19;
        // 
        // lbl10
        // 
        lbl10.AutoSize = true;
        lbl10.Location = new Point(24, 332);
        lbl10.Margin = new Padding(2, 0, 2, 0);
        lbl10.Name = "lbl10";
        lbl10.Size = new Size(49, 20);
        lbl10.TabIndex = 20;
        lbl10.Text = "Status";
        // 
        // txtStatus
        // 
        txtStatus.Location = new Point(24, 352);
        txtStatus.Margin = new Padding(2);
        txtStatus.Name = "txtStatus";
        txtStatus.Size = new Size(177, 27);
        txtStatus.TabIndex = 21;
        // 
        // lbl11
        // 
        lbl11.AutoSize = true;
        lbl11.Location = new Point(224, 332);
        lbl11.Margin = new Padding(2, 0, 2, 0);
        lbl11.Name = "lbl11";
        lbl11.Size = new Size(48, 20);
        lbl11.TabIndex = 22;
        lbl11.Text = "Notes";
        // 
        // txtNotes
        // 
        txtNotes.Location = new Point(224, 352);
        txtNotes.Margin = new Padding(2);
        txtNotes.Name = "txtNotes";
        txtNotes.Size = new Size(177, 27);
        txtNotes.TabIndex = 23;
        // 
        // dtDate
        // 
        dtDate.Location = new Point(424, 20);
        dtDate.Margin = new Padding(2);
        dtDate.Name = "dtDate";
        dtDate.Size = new Size(209, 27);
        dtDate.TabIndex = 24;
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(424, 76);
        btnAdd.Margin = new Padding(2);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(80, 30);
        btnAdd.TabIndex = 25;
        btnAdd.Text = "Add";
        // 
        // btnUpdate
        // 
        btnUpdate.Location = new Point(512, 76);
        btnUpdate.Margin = new Padding(2);
        btnUpdate.Name = "btnUpdate";
        btnUpdate.Size = new Size(80, 30);
        btnUpdate.TabIndex = 26;
        btnUpdate.Text = "Update";
        // 
        // btnDelete
        // 
        btnDelete.Location = new Point(600, 76);
        btnDelete.Margin = new Padding(2);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(80, 30);
        btnDelete.TabIndex = 27;
        btnDelete.Text = "Delete";
        // 
        // btnClear
        // 
        btnClear.Location = new Point(688, 76);
        btnClear.Margin = new Padding(2);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(64, 30);
        btnClear.TabIndex = 28;
        btnClear.Text = "Clear";
        // 
        // lblStatus
        // 
        lblStatus.ForeColor = Color.FromArgb(100, 116, 139);
        lblStatus.Location = new Point(424, 120);
        lblStatus.Margin = new Padding(2, 0, 2, 0);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(320, 48);
        lblStatus.TabIndex = 29;
        // 
        // grid
        // 
        grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        grid.ColumnHeadersHeight = 29;
        grid.Location = new Point(24, 512);
        grid.Margin = new Padding(2);
        grid.Name = "grid";
        grid.RowHeadersWidth = 51;
        grid.Size = new Size(813, 244);
        grid.TabIndex = 3;
        // 
        // refreshTimer
        // 
        refreshTimer.Interval = 1000;
        // 
        // HealthForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(128, 255, 255);
        ClientSize = new Size(877, 767);
        Controls.Add(lblTitle);
        Controls.Add(formPanel);
        Controls.Add(grid);
        Margin = new Padding(2);
        Name = "HealthForm";
        Text = "HealthForm";
        Load += HealthForm_Load;
        formPanel.ResumeLayout(false);
        formPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)grid).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
