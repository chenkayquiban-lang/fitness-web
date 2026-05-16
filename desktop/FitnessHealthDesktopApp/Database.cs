using System.Data;
using MySql.Data.MySqlClient;

namespace FitnessHealthDesktopApp;

public static class Database
{
    private const string ConnectionString = "server=localhost;port=3306;database=fitness_health_system;user=root;password=;SslMode=none;AllowPublicKeyRetrieval=True;";

    public static MySqlConnection GetConnection() => new(ConnectionString);

    public static DataTable Query(string sql, params MySqlParameter[] parameters)
    {
        using var conn = GetConnection();
        using var cmd = new MySqlCommand(sql, conn);
        if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);
        using var adapter = new MySqlDataAdapter(cmd);
        var table = new DataTable();
        adapter.Fill(table);
        return table;
    }

    public static int Execute(string sql, params MySqlParameter[] parameters)
    {
        using var conn = GetConnection();
        conn.Open();
        using var cmd = new MySqlCommand(sql, conn);
        if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);
        return cmd.ExecuteNonQuery();
    }

    public static bool Test(out string message)
    {
        try
        {
            using var conn = GetConnection();
            conn.Open();
            message = "Connected to XAMPP MySQL database: fitness_health_system";
            return true;
        }
        catch (Exception ex)
        {
            message = ex.Message;
            return false;
        }
    }
}
