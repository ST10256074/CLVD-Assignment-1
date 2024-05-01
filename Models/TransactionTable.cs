using System.Data.SqlClient;

namespace Cloud_Aissgnment_1.Models
{
    public class TransactionTable
    {
        public static string con_string = "Server=tcp:st10256074-sql-server.database.windows.net,1433;Initial Catalog=st10256074-sql-db;Persist Security Info=False;User ID=James;Password=qTSJh2lbCrIRs5cSDvW6jhFkyUtyTX64;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        public int transcID { get; set; }
        public int userID { get; set; }
        public int productID { get; set; }
        public DateTime date { get; set; }


        public int buyProduct(TransactionTable t)
        {
            string sql = "INSERT INTO transcTable (userID, productID, transcDate) " +
                "VALUES (@userID, @productID, @date);";
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                cmd.Parameters.AddWithValue("@userID", t.userID);
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


        public List<productTable> getOrders(int ID)
        {
            string sql = "SELECT p.* " +
                "FROM productTable p " +
                "INNER JOIN transcTable t " +
                "ON p.productID = t.productID " +
                "WHERE t.userID = @userID;";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@userID", ID);

            List<productTable> trans = new List<productTable>();


            con.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int pID = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    double price = reader.GetDouble(2);
                    string category = reader.GetString(3);
                    bool availability = reader.GetBoolean(4);
                    int owner = reader.GetInt32(5);

                    trans.Add(new productTable { ID = pID, Name = name, Availability = availability, Category = category, Price = price, OwnerID = owner });

                }
            }

            con.Close();
            return (trans);
        }
        public List<productTable> getOwnedOrders(int ID)
        {
            string sql = "SELECT productTable.* FROM productTable " +
                "JOIN transcTable " +
                "ON transcTable.productID = productTable.productID " +
                "WHERE productTable.productOwnerID = @userID; ";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@userID", ID);

            List<productTable> trans = new List<productTable>();


            con.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int pID = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    double price = reader.GetDouble(2);
                    string category = reader.GetString(3);
                    bool availability = reader.GetBoolean(4);
                    int owner = reader.GetInt32(5);

                    trans.Add(new productTable { ID = pID, Name = name, Availability = availability, Category = category, Price = price, OwnerID = owner });

                }
            }

            con.Close();
            return (trans);
        }
    }
}
