﻿using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;


namespace Cloud_Aissgnment_1.Models
{
    public class userTable
    {

        public static string con_string = "Server=tcp:st10256074-sql-server.database.windows.net,1433;Initial Catalog=st10256074-sql-db;Persist Security Info=False;User ID=James;Password=qTSJh2lbCrIRs5cSDvW6jhFkyUtyTX64;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        // No ID as that auto-increments
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public int insertUser(userTable m)
        {
            string sql = "INSERT INTO userTable (userName, userPassword, userEmail) VALUES (@username, @password, @email);";
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                cmd.Parameters.AddWithValue("@username", m.UserName);
                cmd.Parameters.AddWithValue("@password", m.Password);
                cmd.Parameters.AddWithValue("@email", m.Email); ;
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;

            }
            catch (Exception)
            {

                throw;
            }
        }

       
    }
}