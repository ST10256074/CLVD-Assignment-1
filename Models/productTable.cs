using System.Data.SqlClient;
using System.Drawing;

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

        public Image pImage { get; set; }

        // Receive Image from form
        public IFormFile ImageFile { get; set; }

        public string ImageSrcString { get; set; }

        public string Category { get; set; }

        public bool Availability { get; set; }

        public int OwnerID { get; set; }



        public int insertProduct(productTable p)
        {
            try
            {
                string sql = "INSERT INTO productTable (productName, productPrice, productCategory, productAvailability, productOwnerID, productImage) " +
                    "VALUES (@Name, @Price, @Category, @Availability, @ID, @productImage)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Price", (double)p.Price);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Availability", p.Availability);
                cmd.Parameters.AddWithValue("@ID", p.ID);

                // Convert HttpFormFile to Image plus null check
                if (p.ImageFile != null)
                {
                    Image img = Image.FromStream(p.ImageFile.OpenReadStream());

                    // Convert Image to Byte Array
                    byte[] imgData = ConvertImageToBytes(img);


                    cmd.Parameters.AddWithValue("@productImage", imgData);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@productImage", null);
                }

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

                    // Byte Conversion from database to image
                    Image img = null;
                    string imgsrcstring = "";
                    //var imgData = reader.GetSqlBytes(6);
                    byte[] b = new byte[2146435071];
                    if (!reader.IsDBNull(6))
                    {
                        var numberofbytesread = reader.GetBytes(6, 0, b, 0, int.MaxValue);

                        byte[] buffer = (byte[])b;

                        //img = productTable.ConvertByteArrayToImage(buffer);
                        string s = Convert.ToBase64String(buffer);
                        imgsrcstring = String.Format("\"data:image/Bmp;base64,{0}\">", s);
                    }

                    string category = reader.GetString(3);
                    bool availability = reader.GetBoolean(4);
                    int owner = reader.GetInt32(5);

                    // Product Table init

                    products.Add(new productTable { ID = ID, Name = name, Availability = availability, Category = category, Price = price, OwnerID = owner, pImage = img, ImageSrcString = imgsrcstring });
                }
            }

            con.Close();
            return (products);
        }

        // Helper Methods for image conversion
        public static byte[] ConvertImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                return ms.ToArray();
            }
        }

        // Create image from byte array

        public static Image ConvertByteArrayToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                //var r = Image.FromStream(ms);
                var r = Bitmap.FromStream(ms);
                return r;
            }
        }


    }


}
