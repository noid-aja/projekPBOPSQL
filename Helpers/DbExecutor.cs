internal static class DbExecutor
{
    public static int ExecuteCall(string sql, params NpgsqlParameter[] parameters)
    {
        using var conn = ConnectDB.GetConnection();
        conn.Open();

        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddRange(parameters);
        return cmd.ExecuteNonQuery();
    }

    public static DataTable QueryTable(string sql, params NpgsqlParameter[] parameters)
    {
        using var conn = ConnectDB.GetConnection();
        conn.Open();

        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddRange(parameters);

        using var adapter = new NpgsqlDataAdapter(cmd);
        var table = new DataTable();
        adapter.Fill(table);
        return table;
    }
}