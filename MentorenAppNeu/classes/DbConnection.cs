using System;
using System.Data.SqlClient;

public abstract class DbConnection
{
    public string ConnectionString = @"C:\\Users\\Silke\\Documents\\Schule\\Ittp\\Mentoren\\Mentoren-App\\Datenbank\\Mentor.db";
    /*
    public void CreateData(string query, SqlParameter[] parameters)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                cmd.ExecuteNonQuery();
            }
        }
    }

    public SqlDataReader ReadData(string query, SqlParameter[] parameters)
    {
        SqlConnection connection = new SqlConnection(ConnectionString);
        connection.Open();
        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
    }

    public void UpdateData(string query, SqlParameter[] parameters)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void DeleteData(string query, SqlParameter[] parameters)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                cmd.ExecuteNonQuery();
            }
        }
    }*/
}
