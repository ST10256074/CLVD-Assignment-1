using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Cloud_Aissgnment_1.Models
{
    public class productTable 
    {
        //public static string con_string = "Server=tcp:clouddev-sql-server.database.windows.net,1433;Initial Catalog=CLDVDatabase;Persist Security Info=False;User ID=Byron;Password=RockeyM12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static string con_string = "Server=tcp:st10256074-sql-server.database.windows.net,1433;Initial Catalog=st10256074-sql-db;Persist Security Info=False;User ID=James;Password=qTSJh2lbCrIRs5cSDvW6jhFkyUtyTX64;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public static SqlConnection con = new SqlConnection(con_string);

        public string Name { get; set; }

        public float Price { get; set; }

        public string Category { get; set; }

        public bool Availability { get; set; }



        public int insertProduct(productTable p)
        {
            try
            {
                string sql = "INSERT INTO productTable (productName, productPrice, productCategory, productAvailability) VALUES (@Name, @Price, @Category, @Availability)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Availability", p.Availability);
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
                    string name = reader.GetString(0);
                    float price = reader.GetFloat(1);
                    string category = reader.GetString(2);
                    bool availability = reader.GetBoolean(3);


                    // ... (add more properties for all columns)

                    products.Add(new productTable { Name = name, Availability = availability, Category = category, Price = price });
                }
            }

            con.Close();
            return (products);
        }
    }

}
