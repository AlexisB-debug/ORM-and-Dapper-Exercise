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

            DapperProductRepository productRepository = new DapperProductRepository(conn);

            // string productName = "Alexis' Miscellaneous Product";
            // double price = 700.00;
            // int categoryID = 10;
            //
            // try
            // {
            //     productRepository.CreateProduct(productName, price, categoryID);
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine(ex.Message);
            // }
            
            // Product productToUpdate = productRepository.GetProductByProductID(941);
            //
            // productToUpdate.Name = "Alexis Successfully Updated";
            // productToUpdate.Price = 700.00;
            // productToUpdate.CategoryID = 10;
            // productToUpdate.OnSale = false;
            // productToUpdate.StockLevel = 339;
            //
            // productRepository.UpdateProduct(productToUpdate);
            
            // productRepository.DeleteProduct(941);

            IEnumerable<Product> products = productRepository.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID + " " + product.Name + " $" + product.Price + " " + product.CategoryID + " " + product.OnSale + " " + product.StockLevel);
            }
        }
    }
}
