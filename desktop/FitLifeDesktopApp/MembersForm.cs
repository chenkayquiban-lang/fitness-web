using MySql.Data.MySqlClient;

namespace FitLifeDesktopApp;

public partial class MembersForm : Form
{
    public MembersForm()
    {
        InitializeComponent(); ModernTheme.Apply(this); txtId.ReadOnly = true;
        grid.CellClick += (_, _) => Pick(); btnAdd.Click += (_, _) => Save(false); btnUpdate.Click += (_, _) => Save(true); btnDelete.Click += (_, _) => Delete(); btnClear.Click += (_, _) => ClearFields();
        refreshTimer.Tick += (_, _) => LoadData(); if (!DesignModeHelper.IsInDesignMode) { LoadData(); refreshTimer.Start(); }
    }
    private void LoadData(){ try{ grid.DataSource=Database.Query("SELECT m.id,u.full_name,u.username,u.email,m.phone,m.address,m.gender,m.height_cm,m.weight_kg,m.goal FROM members m JOIN users u ON u.id=m.user_id ORDER BY m.id DESC"); lblStatus.Text="Auto-refresh active. Changes sync with web.";}catch(Exception ex){lblStatus.Text=ex.Message;} }
    private void Pick(){ if(grid.CurrentRow==null)return; txtId.Text=S("id"); txtFullName.Text=S("full_name"); txtUsername.Text=S("username"); txtEmail.Text=S("email"); txtPhone.Text=S("phone"); txtAddress.Text=S("address"); txtGender.Text=S("gender"); txtHeight.Text=S("height_cm"); txtWeight.Text=S("weight_kg"); txtGoal.Text=S("goal"); }
    private string S(string col)=>grid.CurrentRow?.Cells[col]?.Value?.ToString() ?? "";
    private void Save(bool update){ try{ if(update){ Database.Execute("UPDATE users u JOIN members m ON m.user_id=u.id SET u.full_name=@n,u.username=@un,u.email=@e,m.phone=@p,m.address=@a,m.gender=@g,m.height_cm=@h,m.weight_kg=@w,m.goal=@go WHERE m.id=@id", Database.P("@n",txtFullName.Text),Database.P("@un",txtUsername.Text),Database.P("@e",txtEmail.Text),Database.P("@p",txtPhone.Text),Database.P("@a",txtAddress.Text),Database.P("@g",txtGender.Text),Database.P("@h",txtHeight.Text),Database.P("@w",txtWeight.Text),Database.P("@go",txtGoal.Text),Database.P("@id",txtId.Text)); } else { Database.Execute("INSERT INTO users(full_name,username,email,password,role,status) VALUES(@n,@un,@e,MD5('user123'),'user','active')",Database.P("@n",txtFullName.Text),Database.P("@un",txtUsername.Text),Database.P("@e",txtEmail.Text)); var uid=Database.Scalar("SELECT LAST_INSERT_ID()"); Database.Execute("INSERT INTO members(user_id,phone,address,gender,height_cm,weight_kg,goal) VALUES(@uid,@p,@a,@g,@h,@w,@go)",Database.P("@uid",uid),Database.P("@p",txtPhone.Text),Database.P("@a",txtAddress.Text),Database.P("@g",txtGender.Text),Database.P("@h",txtHeight.Text),Database.P("@w",txtWeight.Text),Database.P("@go",txtGoal.Text)); } LoadData(); ClearFields(); }catch(Exception ex){lblStatus.Text=ex.Message;} }
    private void Delete(){ if(string.IsNullOrWhiteSpace(txtId.Text))return; try{ Database.Execute("DELETE FROM members WHERE id=@id",Database.P("@id",txtId.Text)); LoadData(); ClearFields(); }catch(Exception ex){lblStatus.Text=ex.Message;} }
    private void ClearFields(){ foreach(Control c in formPanel.Controls) if(c is TextBox t) t.Clear(); }
}
