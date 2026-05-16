namespace FitLifeDesktopApp;

public partial class HealthForm : Form
{
    public HealthForm() { InitializeComponent(); ModernTheme.Apply(this); txtId.ReadOnly = true; txtBmi.ReadOnly = true; txtWeight.TextChanged += (_, _) => CalcBmi(); txtMemberId.TextChanged += (_, _) => CalcBmi(); grid.CellClick += (_, _) => Pick(); btnAdd.Click += (_, _) => Save(false); btnUpdate.Click += (_, _) => Save(true); btnDelete.Click += (_, _) => Delete(); btnClear.Click += (_, _) => ClearFields(); refreshTimer.Tick += (_, _) => LoadData(); if (!DesignModeHelper.IsInDesignMode) { LoadData(); refreshTimer.Start(); } }
    private void LoadData() { try { grid.DataSource = Database.Query("SELECT h.*,u.full_name FROM health_records h JOIN members m ON m.id=h.member_id JOIN users u ON u.id=m.user_id ORDER BY h.id DESC"); lblStatus.Text = "BMI auto-calculates from member height and weight."; } catch (Exception ex) { lblStatus.Text = ex.Message; } }
    private string S(string col) => grid.CurrentRow?.Cells[col]?.Value?.ToString() ?? "";
    private void Pick() { if (grid.CurrentRow == null) return; txtId.Text = S("id"); txtMemberId.Text = S("member_id"); txtSystolic.Text = S("systolic"); txtDiastolic.Text = S("diastolic"); txtHeart.Text = S("heart_rate"); txtTemp.Text = S("temperature"); txtSugar.Text = S("blood_sugar"); txtOxygen.Text = S("oxygen_level"); txtWeight.Text = S("weight_kg"); txtBmi.Text = S("bmi"); txtStatus.Text = S("status"); txtNotes.Text = S("notes"); }
    private void CalcBmi() { try { var height = Database.Scalar("SELECT height_cm FROM members WHERE id=@id", Database.P("@id", txtMemberId.Text)); if (decimal.TryParse(Convert.ToString(height), out var cm) && decimal.TryParse(txtWeight.Text, out var kg) && cm > 0) { var bmi = kg / ((cm / 100) * (cm / 100)); txtBmi.Text = bmi.ToString("0.00"); txtStatus.Text = bmi < 18.5m ? "Underweight" : bmi < 25m ? "Normal" : bmi < 30m ? "Overweight" : "Obese"; } } catch { } }
    private void Save(bool update) { try { CalcBmi(); if (update) Database.Execute("UPDATE health_records SET member_id=@m,record_date=@d,systolic=@s,diastolic=@di,heart_rate=@hr,temperature=@t,blood_sugar=@bs,oxygen_level=@o,weight_kg=@w,bmi=@b,status=@st,notes=@n WHERE id=@id", P(), Database.P("@id", txtId.Text)); else Database.Execute("INSERT INTO health_records(member_id,record_date,systolic,diastolic,heart_rate,temperature,blood_sugar,oxygen_level,weight_kg,bmi,status,notes) VALUES(@m,@d,@s,@di,@hr,@t,@bs,@o,@w,@b,@st,@n)", P()); LoadData(); ClearFields(); } catch (Exception ex) { lblStatus.Text = ex.Message; } }
    private MySql.Data.MySqlClient.MySqlParameter[] P() => new[] { Database.P("@m", txtMemberId.Text), Database.P("@d", dtDate.Value.Date), Database.P("@s", txtSystolic.Text), Database.P("@di", txtDiastolic.Text), Database.P("@hr", txtHeart.Text), Database.P("@t", txtTemp.Text), Database.P("@bs", txtSugar.Text), Database.P("@o", txtOxygen.Text), Database.P("@w", txtWeight.Text), Database.P("@b", txtBmi.Text), Database.P("@st", txtStatus.Text), Database.P("@n", txtNotes.Text) };
    private void Delete() { if (string.IsNullOrWhiteSpace(txtId.Text)) return; try { Database.Execute("DELETE FROM health_records WHERE id=@id", Database.P("@id", txtId.Text)); LoadData(); ClearFields(); } catch (Exception ex) { lblStatus.Text = ex.Message; } }
    private void ClearFields() { foreach (Control c in formPanel.Controls) if (c is TextBox t) t.Clear(); }

    private void HealthForm_Load(object sender, EventArgs e)
    {

    }
}
