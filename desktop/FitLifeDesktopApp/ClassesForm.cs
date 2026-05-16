namespace FitLifeDesktopApp;

public partial class ClassesForm : Form
{
    public ClassesForm(){ InitializeComponent(); ModernTheme.Apply(this); txtId.ReadOnly=true; grid.CellClick += (_,_)=>Pick(); btnAdd.Click += (_,_)=>Save(false); btnUpdate.Click += (_,_)=>Save(true); btnDelete.Click += (_,_)=>Delete(); btnClear.Click += (_,_)=>ClearFields(); refreshTimer.Tick += (_,_)=>LoadData(); if(!DesignModeHelper.IsInDesignMode){LoadData();refreshTimer.Start();} }
    private void LoadData(){ try{ grid.DataSource=Database.Query("SELECT id,title,class_type,schedule_datetime,capacity,stream_link,description FROM classes ORDER BY id DESC"); lblStatus.Text="Classes are shown in both web and desktop.";}catch(Exception ex){lblStatus.Text=ex.Message;} }
    private string S(string col)=>grid.CurrentRow?.Cells[col]?.Value?.ToString() ?? "";
    private void Pick(){ if(grid.CurrentRow==null)return; txtId.Text=S("id"); txtTitle.Text=S("title"); txtType.Text=S("class_type"); txtCapacity.Text=S("capacity"); txtLink.Text=S("stream_link"); txtDescription.Text=S("description"); }
    private void Save(bool update){ try{ if(update) Database.Execute("UPDATE classes SET title=@t,class_type=@ct,schedule_datetime=@d,capacity=@c,stream_link=@l,description=@de WHERE id=@id",P(Database.P("@id",txtId.Text))); else Database.Execute("INSERT INTO classes(title,class_type,schedule_datetime,capacity,stream_link,description) VALUES(@t,@ct,@d,@c,@l,@de)",P()); LoadData(); ClearFields(); }catch(Exception ex){lblStatus.Text=ex.Message;} }
    private MySql.Data.MySqlClient.MySqlParameter[] P(params MySql.Data.MySqlClient.MySqlParameter[] extra)=>new[]{Database.P("@t",txtTitle.Text),Database.P("@ct",txtType.Text),Database.P("@d",dtDate.Value),Database.P("@c",txtCapacity.Text),Database.P("@l",txtLink.Text),Database.P("@de",txtDescription.Text)}.Concat(extra).ToArray();
    private void Delete(){ if(string.IsNullOrWhiteSpace(txtId.Text))return; try{ Database.Execute("DELETE FROM classes WHERE id=@id",Database.P("@id",txtId.Text)); LoadData(); ClearFields(); }catch(Exception ex){lblStatus.Text=ex.Message;} }
    private void ClearFields(){ foreach(Control c in formPanel.Controls) if(c is TextBox t) t.Clear(); }
}
