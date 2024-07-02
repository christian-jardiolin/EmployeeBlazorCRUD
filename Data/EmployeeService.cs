using EmployeeBlazorCRUD.DataContext;
using EmployeeBlazorCRUD.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EmployeeBlazorCRUD.Data
{
    public class EmployeeService
    {
        //public class memberdetails
        //{
        //    public string role { get; set; }
        //    public string globalid { get; set; }
        //    public string countrylist_name { get; set; }
        //    public string countrylist_id { get; set; }
        //    public string member_id { get; set; }
        //}
        private readonly ApplicationDbContext _applicationDbContext;
        public EmployeeService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //List of Employees
        public async Task<List<Employee>> GetAllEmployees()
        {
            //return await _applicationDbContext.Employees.ToListAsync();

            //var connectionValue = SqlConnection connection = ConnectionManager.Get_DatabaseConnection();
            //SqlConnection connection1 = new SqlConnection(connectionValue);
            //SqlConnection connection1 = ConnectionManager.Get_DatabaseConnection();
            SqlDataReader reader;
            using (SqlConnection connection1 = ConnectionManager.Get_DatabaseConnection())
            {
                var sql = "SELECT * FROM Employees";
                var command = new SqlCommand(sql, connection1);
                //connection1.Open();
                command.ExecuteReader();
                //if (reader.Read())
                //{

                //}
                //reader.Close();
                return await _applicationDbContext.Employees.ToListAsync();
            }
            
        }

        //public async Task<List<Employee>> Get_MemberDetails()
        //{
        //    SqlDataReader reader;
        //    List<Employee> list = new List<Employee>();

        //    string sql = "SELECT * FROM Employees";

        //    using (SqlConnection connection = ConnectionManager.Get_DatabaseConnection())
        //    {
        //        SqlCommand com = new SqlCommand(sql, connection);
        //        com.CommandType = CommandType.Text;
        //        reader = com.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            Employee emp = new Employee();
        //            emp.Id = Convert.ToInt32(reader["Id"]);
        //            emp.FirstName = Convert.ToString(reader["FirstName"]);
        //            emp.MiddleName = Convert.ToString(reader["MiddleName"]);
        //            emp.LastName = Convert.ToString(reader["LastName"]);
        //            emp.Gender = Convert.ToString(reader["Gender"]);
        //            emp.City = Convert.ToString(reader["City"]);
        //            emp.Designation = Convert.ToString(reader["Designation"]);
        //            list.Add(emp);
        //        }
        //        reader.Close();
        //    }
        //    //return await list;
        //    return await _applicationDbContext.Employees.ToListAsync();
        //}


        //Add  Employees
        public async Task<bool> InsertEmployee(Employee employee)
        {
            await _applicationDbContext.Employees.AddAsync(employee);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        //Get Employee By Id  
        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee employee = await _applicationDbContext.Employees.FirstOrDefaultAsync(c => c.Id.Equals(id));
            return employee;
        }

        //Update Employee
        public async Task<bool> UpdateEmployee(Employee employee)
        {
            _applicationDbContext.Employees.Update(employee);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        //Delete Employee
        public async Task<bool> DeleteEmployee(Employee employee)
        {
            _applicationDbContext.Employees.Remove(employee);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
    }
}
