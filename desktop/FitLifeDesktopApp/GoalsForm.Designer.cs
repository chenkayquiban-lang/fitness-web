namespace FitLifeDesktopApp;

partial class GoalsForm
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
    private TextBox txtTitle;
    private Label lbl3;
    private TextBox txtTarget;
    private Label lbl4;
    private TextBox txtCurrent;
    private Label lbl5;
    private TextBox txtUnit;

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
        txtTitle = new TextBox();
        lbl3 = new Label();
        txtTarget = new TextBox();
        lbl4 = new Label();
        txtCurrent = new TextBox();
        lbl5 = new Label();
        txtUnit = new TextBox();
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
        lblTitle.Size = new Size(126, 54);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Goals";
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
        formPanel.Controls.Add(txtTitle);
        formPanel.Controls.Add(lbl3);
        formPanel.Controls.Add(txtTarget);
        formPanel.Controls.Add(lbl4);
        formPanel.Controls.Add(txtCurrent);
        formPanel.Controls.Add(lbl5);
        formPanel.Controls.Add(txtUnit);
        formPanel.Controls.Add(dtDate);
        formPanel.Controls.Add(btnAdd);
        formPanel.Controls.Add(btnUpdate);
        formPanel.Controls.Add(btnDelete);
        formPanel.Controls.Add(btnClear);
        formPanel.Controls.Add(lblStatus);
        formPanel.Location = new Point(24, 96);
        formPanel.Margin = new Padding(2, 2, 2, 2);
        formPanel.Name = "formPanel";
        formPanel.Size = new Size(944, 224);
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
        lbl1.Size = new Size(84, 20);
        lbl1.TabIndex = 2;
        lbl1.Text = "Member ID";
        // 
        // txtMemberId
        // 
        txtMemberId.Location = new Point(240, 41);
        txtMemberId.Margin = new Padding(2, 2, 2, 2);
        txtMemberId.Name = "txtMemberId";
        txtMemberId.Size = new Size(193, 27);
        txtMemberId.TabIndex = 3;
        // 
        // lbl2
        // 
        lbl2.AutoSize = true;
        lbl2.ForeColor = Color.FromArgb(71, 85, 105);
        lbl2.Location = new Point(456, 19);
        lbl2.Margin = new Padding(2, 0, 2, 0);
        lbl2.Name = "lbl2";
        lbl2.Size = new Size(38, 20);
        lbl2.TabIndex = 4;
        lbl2.Text = "Title";
        // 
        // txtTitle
        // 
        txtTitle.Location = new Point(456, 41);
        txtTitle.Margin = new Padding(2, 2, 2, 2);
        txtTitle.Name = "txtTitle";
        txtTitle.Size = new Size(193, 27);
        txtTitle.TabIndex = 5;
        // 
        // lbl3
        // 
        lbl3.AutoSize = true;
        lbl3.ForeColor = Color.FromArgb(71, 85, 105);
        lbl3.Location = new Point(24, 74);
        lbl3.Margin = new Padding(2, 0, 2, 0);
        lbl3.Name = "lbl3";
        lbl3.Size = new Size(50, 20);
        lbl3.TabIndex = 6;
        lbl3.Text = "Target";
        // 
        // txtTarget
        // 
        txtTarget.Location = new Point(24, 95);
        txtTarget.Margin = new Padding(2, 2, 2, 2);
        txtTarget.Name = "txtTarget";
        txtTarget.Size = new Size(193, 27);
        txtTarget.TabIndex = 7;
        // 
        // lbl4
        // 
        lbl4.AutoSize = true;
        lbl4.ForeColor = Color.FromArgb(71, 85, 105);
        lbl4.Location = new Point(240, 74);
        lbl4.Margin = new Padding(2, 0, 2, 0);
        lbl4.Name = "lbl4";
        lbl4.Size = new Size(57, 20);
        lbl4.TabIndex = 8;
        lbl4.Text = "Current";
        // 
        // txtCurrent
        // 
        txtCurrent.Location = new Point(240, 95);
        txtCurrent.Margin = new Padding(2, 2, 2, 2);
        txtCurrent.Name = "txtCurrent";
        txtCurrent.Size = new Size(193, 27);
        txtCurrent.TabIndex = 9;
        // 
        // lbl5
        // 
        lbl5.AutoSize = true;
        lbl5.ForeColor = Color.FromArgb(71, 85, 105);
        lbl5.Location = new Point(456, 74);
        lbl5.Margin = new Padding(2, 0, 2, 0);
        lbl5.Name = "lbl5";
        lbl5.Size = new Size(36, 20);
        lbl5.TabIndex = 10;
        lbl5.Text = "Unit";
        // 
        // txtUnit
        // 
        txtUnit.Location = new Point(456, 95);
        txtUnit.Margin = new Padding(2, 2, 2, 2);
        txtUnit.Name = "txtUnit";
        txtUnit.Size = new Size(193, 27);
        txtUnit.TabIndex = 11;
        // 
        // dtDate
        // 
        dtDate.Location = new Point(672, 41);
        dtDate.Margin = new Padding(2, 2, 2, 2);
        dtDate.Name = "dtDate";
        dtDate.Size = new Size(225, 27);
        dtDate.TabIndex = 12;
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(24, 165);
        btnAdd.Margin = new Padding(2, 2, 2, 2);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(96, 34);
        btnAdd.TabIndex = 13;
        btnAdd.Text = "Add";
        // 
        // btnUpdate
        // 
        btnUpdate.Location = new Point(130, 165);
        btnUpdate.Margin = new Padding(2, 2, 2, 2);
        btnUpdate.Name = "btnUpdate";
        btnUpdate.Size = new Size(96, 34);
        btnUpdate.TabIndex = 14;
        btnUpdate.Text = "Update";
        // 
        // btnDelete
        // 
        btnDelete.BackColor = Color.FromArgb(220, 38, 38);
        btnDelete.Location = new Point(235, 165);
        btnDelete.Margin = new Padding(2, 2, 2, 2);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(96, 34);
        btnDelete.TabIndex = 15;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = false;
        // 
        // btnClear
        // 
        btnClear.BackColor = Color.FromArgb(100, 116, 139);
        btnClear.Location = new Point(341, 165);
        btnClear.Margin = new Padding(2, 2, 2, 2);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(96, 34);
        btnClear.TabIndex = 16;
        btnClear.Text = "Clear";
        btnClear.UseVisualStyleBackColor = false;
        // 
        // lblStatus
        // 
        lblStatus.ForeColor = Color.FromArgb(100, 116, 139);
        lblStatus.Location = new Point(456, 170);
        lblStatus.Margin = new Padding(2, 0, 2, 0);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(448, 34);
        lblStatus.TabIndex = 17;
        lblStatus.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // grid
        // 
        grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        grid.ColumnHeadersHeight = 29;
        grid.Location = new Point(24, 344);
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
        // GoalsForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(128, 255, 255);
        ClientSize = new Size(992, 584);
        Controls.Add(lblTitle);
        Controls.Add(formPanel);
        Controls.Add(grid);
        Margin = new Padding(2, 2, 2, 2);
        Name = "GoalsForm";
        Text = "Goals";
        formPanel.ResumeLayout(false);
        formPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)grid).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
