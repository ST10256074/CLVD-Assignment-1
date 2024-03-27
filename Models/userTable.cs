using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;


namespace Cloud_Aissgnment_1.Models
{
    public class userTable : Controller
    {

        public static string con_string = "Server=tcp:st10256074-sql-server.database.windows.net,1433;Initial Catalog=st10256074-sql-db;Persist Security Info=False;User ID=James;Password=qTSJh2lbCrIRs5cSDvW6jhFkyUtyTX64;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);
        public IActionResult Index()
        {
            return View();
        }
    }
}
