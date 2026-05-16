namespace FitLifeDesktopApp;

public static class ModernTheme
{
    public static readonly Color Bg = Color.FromArgb(248, 250, 252);
    public static readonly Color Card = Color.White;
    public static readonly Color Primary = Color.FromArgb(37, 99, 235);
    public static readonly Color PrimaryDark = Color.FromArgb(29, 78, 216);
    public static readonly Color Danger = Color.FromArgb(220, 38, 38);
    public static readonly Color Dark = Color.FromArgb(15, 23, 42);
    public static readonly Color Side = Color.FromArgb(30, 41, 59);
    public static readonly Color Muted = Color.FromArgb(100, 116, 139);
    public static readonly Color Border = Color.FromArgb(226, 232, 240);

    public static void Apply(Form form)
    {
        form.BackColor = Bg;
        form.Font = new Font("Segoe UI", 10F);
        foreach (Control c in form.Controls) ApplyControl(c);
    }

    public static void ApplyControl(Control c)
    {
        if (c is Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            if (b.Text.Equals("Delete", StringComparison.OrdinalIgnoreCase) || b.Text.Equals("Logout", StringComparison.OrdinalIgnoreCase))
                b.BackColor = Danger;
            else if (b.Text.Equals("Clear", StringComparison.OrdinalIgnoreCase))
                b.BackColor = Muted;
            else
                b.BackColor = Primary;
            b.ForeColor = Color.White;
            b.Height = Math.Max(b.Height, 40);
            b.Cursor = Cursors.Hand;
            b.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }
        else if (c is DataGridView g)
        {
            g.BackgroundColor = Card;
            g.BorderStyle = BorderStyle.FixedSingle;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.MultiSelect = false;
            g.ReadOnly = true;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.RowHeadersVisible = false;
            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersDefaultCellStyle.BackColor = Side;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            g.DefaultCellStyle.SelectionForeColor = Dark;
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            g.ColumnHeadersHeight = 42;
            g.RowTemplate.Height = 34;
        }
        else if (c is TextBox t)
        {
            t.BorderStyle = BorderStyle.FixedSingle;
            t.Font = new Font("Segoe UI", 10F);
            t.Height = 34;
        }
        else if (c is DateTimePicker d)
        {
            d.Font = new Font("Segoe UI", 10F);
            d.Height = 34;
        }
        else if (c is Panel p)
        {
            p.BackColor = p.BackColor == Color.Empty ? Card : p.BackColor;
        }

        foreach (Control child in c.Controls) ApplyControl(child);
    }
}
