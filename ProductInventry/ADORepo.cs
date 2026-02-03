using System.Data.SqlClient;
namespace ProductInventry
{
    public class ADORepo
    {

        private readonly string _connectionString;

        public ADORepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

     
        public int GetTotalProducts()
        {
            using SqlConnection con = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Products", con);

            con.Open();
            return (int)cmd.ExecuteScalar();
        }
    }
}

 
 