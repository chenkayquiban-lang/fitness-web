namespace FitLifeDesktopApp;

public partial class GoalsForm : Form
{
    public GoalsForm(){ InitializeComponent(); ModernTheme.Apply(this); txtId.ReadOnly=true; grid.CellClick += (_,_)=>Pick(); btnAdd.Click += (_,_)=>Save(false); btnUpdate.Click += (_,_)=>Save(true); btnDelete.Click += (_,_)=>Delete(); btnClear.Click += (_,_)=>ClearFields(); refreshTimer.Tick += (_,_)=>LoadData(); if(!DesignModeHelper.IsInDesignMode){LoadData();refreshTimer.Start();} }
    private void LoadData(){ try{ grid.DataSource=Database.Query("SELECT g.*,u.full_name FROM goals g JOIN members m ON m.id=g.member_id JOIN users u ON u.id=m.user_id ORDER BY g.id DESC"); lblStatus.Text="Goals CRUD with 1-second refresh.";}catch(Exception ex){lblStatus.Text=ex.Message;} }
    private string S(string col)=>grid.CurrentRow?.Cells[col]?.Value?.ToString() ?? "";
    private void Pick(){ if(grid.CurrentRow==null)return; txtId.Text=S("id"); txtMemberId.Text=S("member_id"); txtTitle.Text=S("title"); txtTarget.Text=S("target_value"); txtCurrent.Text=S("current_value"); txtUnit.Text=S("unit"); }
    private void Save(bool update){ try{ if(update) Database.Execute("UPDATE goals SET member_id=@m,title=@t,target_value=@tv,current_value=@cv,unit=@u,target_date=@d WHERE id=@id",P(Database.P("@id",txtId.Text))); else Database.Execute("INSERT INTO goals(member_id,title,target_value,current_value,unit,target_date) VALUES(@m,@t,@tv,@cv,@u,@d)",P()); LoadData(); ClearFields(); }catch(Exception ex){lblStatus.Text=ex.Message;} }
    private MySql.Data.MySqlClient.MySqlParameter[] P(params MySql.Data.MySqlClient.MySqlParameter[] extra)=>new[]{Database.P("@m",txtMemberId.Text),Database.P("@t",txtTitle.Text),Database.P("@tv",txtTarget.Text),Database.P("@cv",txtCurrent.Text),Database.P("@u",txtUnit.Text),Database.P("@d",dtDate.Value.Date)}.Concat(extra).ToArray();
    private void Delete(){ if(string.IsNullOrWhiteSpace(txtId.Text))return; try{ Database.Execute("DELETE FROM goals WHERE id=@id",Database.P("@id",txtId.Text)); LoadData(); ClearFields(); }catch(Exception ex){lblStatus.Text=ex.Message;} }
    private void ClearFields(){ foreach(Control c in formPanel.Controls) if(c is TextBox t) t.Clear(); }
}
