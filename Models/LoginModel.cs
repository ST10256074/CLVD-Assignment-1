using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Cloud_Aissgnment_1.Models
{
    public class LoginModel
    {
        public static string con_string = "Server=tcp:st10256074-sql-server.database.windows.net,1433;Initial Catalog=st10256074-sql-db;Persist Security Info=False;User ID=James;Password=qTSJh2lbCrIRs5cSDvW6jhFkyUtyTX64;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        public string username { get; set; }
        public string password { get; set; }

        public int selectUser(LoginModel l)
        {
            Console.WriteLine(username);
            int userId = -1;
            string sql = "SELECT userID FROM userTable WHERE userName = @username and userPassword = @password;";
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                cmd.Parameters.AddWithValue("@username", l.username);
                cmd.Parameters.AddWithValue("@password", l.password);
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    userId = Convert.ToInt32(result);
                }
                con.Close();

            }
            catch (Exception)
            {
                throw;
            }
            return userId;

        }

    }
}
