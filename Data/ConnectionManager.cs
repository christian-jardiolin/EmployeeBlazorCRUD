using EmployeeBlazorCRUD.DataContext;
using EmployeeBlazorCRUD.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EmployeeBlazorCRUD.Data
{
    public class ConnectionManager
    {
        public static SqlConnection Get_DatabaseConnection()
        {
            // Get the connection string from the configuration file
            string connectionString = "server=(localdb)\\MSSQLLocalDB;database=BLAZORDB;Integrated Security=True";

            // Create a new connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // Open the connection, and return it
            connection.Open();
            return connection;
        }
    }
}

