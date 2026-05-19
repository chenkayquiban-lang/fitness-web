using System.Data;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using MySql.Data.MySqlClient;

namespace FitLifeDesktopApp;

public static class Database
{
    // IMPORTANT: after uploading web/api/desktop_db.php to your hosting,
    // replace this with your real website URL.
    // Example: https://your-site.infinityfreeapp.com/api/desktop_db.php
    public static string DesktopApiUrl = "http://localhost/fitness-web-main/web/api/desktop_db.php";
    public static string ApiToken = "fitlife_desktop_sync_2026";
    private static int LastInsertId = 0;

    private static readonly HttpClient Client = new HttpClient();

    public static DataTable Query(string sql, params MySqlParameter[] parameters)
    {
        var doc = Send("query", sql, parameters);
        var dt = new DataTable();
        var rows = doc.RootElement.GetProperty("rows");

        foreach (var row in rows.EnumerateArray())
        {
            foreach (var prop in row.EnumerateObject())
            {
                if (!dt.Columns.Contains(prop.Name)) dt.Columns.Add(prop.Name);
            }
        }

        foreach (var row in rows.EnumerateArray())
        {
            var dr = dt.NewRow();
            foreach (DataColumn col in dt.Columns)
            {
                if (row.TryGetProperty(col.ColumnName, out var val))
                    dr[col.ColumnName] = val.ValueKind == JsonValueKind.Null ? DBNull.Value : val.ToString();
            }
            dt.Rows.Add(dr);
        }

        return dt;
    }

    public static int Execute(string sql, params MySqlParameter[] parameters)
    {
        var doc = Send("execute", sql, parameters);
        if (doc.RootElement.TryGetProperty("last_insert_id", out var last) && last.TryGetInt32(out var id)) LastInsertId = id;
        if (doc.RootElement.TryGetProperty("affected", out var affected) && affected.TryGetInt32(out var n)) return n;
        return 0;
    }

    public static int Execute(string sql, MySqlParameter[] parameters, params MySqlParameter[] extraParameters)
    {
        var all = parameters.Concat(extraParameters).ToArray();
        return Execute(sql, all);
    }

    public static object? Scalar(string sql, params MySqlParameter[] parameters)
    {
        if (sql.Trim().Equals("SELECT LAST_INSERT_ID()", StringComparison.OrdinalIgnoreCase)) return LastInsertId;
        var doc = Send("scalar", sql, parameters);
        if (!doc.RootElement.TryGetProperty("value", out var value)) return null;
        if (value.ValueKind == JsonValueKind.Null) return null;
        return value.ToString();
    }

    public static MySqlParameter P(string name, object? value)
    {
        var text = Convert.ToString(value);
        return new MySqlParameter(name, string.IsNullOrWhiteSpace(text) ? DBNull.Value : value);
    }

    private static JsonDocument Send(string action, string sql, MySqlParameter[] parameters)
    {
        var paramMap = new Dictionary<string, object?>();
        foreach (var p in parameters)
        {
            paramMap[p.ParameterName] = p.Value == DBNull.Value ? null : p.Value;
        }

        var payload = new Dictionary<string, object?>
        {
            ["token"] = ApiToken,
            ["action"] = action,
            ["sql"] = sql,
            ["params"] = paramMap
        };

        var json = JsonSerializer.Serialize(payload);
        var response = Client.PostAsync(DesktopApiUrl, new StringContent(json, Encoding.UTF8, "application/json")).Result;
        var text = response.Content.ReadAsStringAsync().Result;
        var doc = JsonDocument.Parse(text);

        if (!response.IsSuccessStatusCode || !doc.RootElement.GetProperty("ok").GetBoolean())
        {
            var error = doc.RootElement.TryGetProperty("error", out var e) ? e.ToString() : text;
            throw new Exception("Database connection error: " + error);
        }

        return doc;
    }
}
