using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace PetrolOtomasyon
{
    public static class DatabaseHelper
    {
        private static readonly string connectionString = "Server=CAVA;Database=PetrolOtomasyonDB;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

    }
}
