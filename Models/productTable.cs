using System.Data.SqlClient;

namespace Cloud_Aissgnment_1.Models
{
    public class productTable
    {
        //public static string con_string = "Server=tcp:clouddev-sql-server.database.windows.net,1433;Initial Catalog=CLDVDatabase;Persist Security Info=False;User ID=Byron;Password=RockeyM12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static string con_string = "Server=tcp:st10256074-sql-server.database.windows.net,1433;Initial Catalog=st10256074-sql-db;Persist Security Info=False;User ID=James;Password=qTSJh2lbCrIRs5cSDvW6jhFkyUtyTX64;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public static SqlConnection con = new SqlConnection(con_string);

        public int ID { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        public string Category { get; set; }

        public bool Availability { get; set; }



        public int insertProduct(productTable p)
        {
            try
            {
                string sql = "INSERT INTO productTable (productName, productPrice, productCategory, productAvailability, productOwnerID) VALUES (@Name, @Price, @Category, @Availability, @ID)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Price", (double)p.Price);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Availability", p.Availability);
                cmd.Parameters.AddWithValue("@ID", p.ID);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, rethrow the exception
                throw ex;
            }

        }

        public static List<productTable> ReturnProducts()
        {
            string sql = "Select * from productTable;";
            SqlCommand cmd = new SqlCommand(sql, con);

            List<productTable> products = new List<productTable>();


            con.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int ID = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    double price = reader.GetDouble(2);
                    string category = reader.GetString(3);
                    bool availability = reader.GetBoolean(4);


                    // ... (add more properties for all columns)

                    products.Add(new productTable { ID = ID, Name = name, Availability = availability, Category = category, Price = price });
                }
            }

            con.Close();
            return (products);
        }

        public int buyProduct(string userID, string productID)
        {
            string sql = "INSERT INTO transcTable ";
            return 0;
        }
    }


}
