using System.Data;
using MySql.Data.MySqlClient;

namespace FitLifeDesktopApp;

public static class Database
{
    public static string ConnectionString = "server=localhost;port=3306;database=fitlife_db;uid=root;pwd=;SslMode=none;AllowPublicKeyRetrieval=true;";

    public static DataTable Query(string sql, params MySqlParameter[] parameters)
    {
        using var con = new MySqlConnection(ConnectionString);
        using var cmd = new MySqlCommand(sql, con);
        if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);
        using var da = new MySqlDataAdapter(cmd);
        var dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public static int Execute(string sql, params MySqlParameter[] parameters)
    {
        using var con = new MySqlConnection(ConnectionString);
        con.Open();
        using var cmd = new MySqlCommand(sql, con);
        if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);
        return cmd.ExecuteNonQuery();
    }


    public static int Execute(string sql, MySqlParameter[] parameters, params MySqlParameter[] extraParameters)
    {
        var all = parameters.Concat(extraParameters).ToArray();
        return Execute(sql, all);
    }

    public static object? Scalar(string sql, params MySqlParameter[] parameters)
    {
        using var con = new MySqlConnection(ConnectionString);
        con.Open();
        using var cmd = new MySqlCommand(sql, con);
        if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);
        return cmd.ExecuteScalar();
    }

    public static MySqlParameter P(string name, object? value)
    {
        var text = Convert.ToString(value);
        return new MySqlParameter(name, string.IsNullOrWhiteSpace(text) ? DBNull.Value : value);
    }
}
