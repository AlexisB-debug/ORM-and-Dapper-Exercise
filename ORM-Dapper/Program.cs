using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
            
            DapperDepartmentRepository departmentRepo = new DapperDepartmentRepository(conn);
            
            // departmentRepo.InsertDepartment("Alexis' Miscellaneous Department");
            
            IEnumerable<Department> departments = departmentRepo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine($"Department ID: {department.DepartmentID} Department Name: {department.Name}\n");
            }
        }
    }
}
