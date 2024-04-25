using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Cloud_Aissgnment_1.Models
{
    public class TransactionTable 
    {
        public static string con_string = "Server=tcp:st10256074-sql-server.database.windows.net,1433;Initial Catalog=st10256074-sql-db;Persist Security Info=False;User ID=James;Password=qTSJh2lbCrIRs5cSDvW6jhFkyUtyTX64;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        int transcID { get; set; }
        int userID { get; set; }
        int productID { get; set; }
        DateOnly date { get; set; }


        public int insertTransc(TransactionTable t)
        {
            string sql = "INSERT INTO transcTable (userID, productID, date) VALUES (@userID, @productID, @date);";
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                cmd.Parameters.AddWithValue("@userID",t.userID);
                cmd.Parameters.AddWithValue("@productID", t.productID);
                cmd.Parameters.AddWithValue("@date", t.date); ;
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
