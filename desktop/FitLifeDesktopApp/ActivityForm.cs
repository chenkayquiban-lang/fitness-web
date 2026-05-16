namespace FitLifeDesktopApp;

public partial class ActivityForm : Form
{
    public ActivityForm(){ InitializeComponent(); ModernTheme.Apply(this); txtId.ReadOnly=true; grid.CellClick += (_,_)=>Pick(); btnAdd.Click += (_,_)=>Save(false); btnUpdate.Click += (_,_)=>Save(true); btnDelete.Click += (_,_)=>Delete(); btnClear.Click += (_,_)=>ClearFields(); refreshTimer.Tick += (_,_)=>LoadData(); if(!DesignModeHelper.IsInDesignMode){LoadData();refreshTimer.Start();} }
    private void LoadData(){ try{ grid.DataSource=Database.Query("SELECT a.*,u.full_name FROM activity_logs a JOIN members m ON m.id=a.member_id JOIN users u ON u.id=m.user_id ORDER BY a.id DESC"); lblStatus.Text="Activity data is shared with the web dashboard.";}catch(Exception ex){lblStatus.Text=ex.Message;} }
    private string S(string col)=>grid.CurrentRow?.Cells[col]?.Value?.ToString() ?? "";
    private void Pick(){ if(grid.CurrentRow==null)return; txtId.Text=S("id"); txtMemberId.Text=S("member_id"); txtSteps.Text=S("steps"); txtWorkout.Text=S("workout"); txtCalories.Text=S("calories_burned"); txtWeight.Text=S("weight_kg"); txtNotes.Text=S("notes"); }
    private void Save(bool update){ try{ if(update) Database.Execute("UPDATE activity_logs SET member_id=@m,log_date=@d,steps=@s,workout=@wo,calories_burned=@c,weight_kg=@w,notes=@n WHERE id=@id",P(Database.P("@id",txtId.Text))); else Database.Execute("INSERT INTO activity_logs(member_id,log_date,steps,workout,calories_burned,weight_kg,notes) VALUES(@m,@d,@s,@wo,@c,@w,@n)",P()); LoadData(); ClearFields(); }catch(Exception ex){lblStatus.Text=ex.Message;} }
    private MySql.Data.MySqlClient.MySqlParameter[] P(params MySql.Data.MySqlClient.MySqlParameter[] extra)=>new[]{Database.P("@m",txtMemberId.Text),Database.P("@d",dtDate.Value.Date),Database.P("@s",txtSteps.Text),Database.P("@wo",txtWorkout.Text),Database.P("@c",txtCalories.Text),Database.P("@w",txtWeight.Text),Database.P("@n",txtNotes.Text)}.Concat(extra).ToArray();
    private void Delete(){ if(string.IsNullOrWhiteSpace(txtId.Text))return; try{ Database.Execute("DELETE FROM activity_logs WHERE id=@id",Database.P("@id",txtId.Text)); LoadData(); ClearFields(); }catch(Exception ex){lblStatus.Text=ex.Message;} }
    private void ClearFields(){ foreach(Control c in formPanel.Controls) if(c is TextBox t) t.Clear(); }
}
