using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

//^^^^MUST HAVE USING DIRECTIVES^^^^

namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            // DEPARTMENTS SECTION
                // instantiate new DapperDepartmentsRepository
            var departmentsRepo = new DapperDepartmentsRepository(conn);

            Console.WriteLine("Type a new Department name: ");

            var newDepartment = Console.ReadLine();
            Console.WriteLine();

            departmentsRepo.InsertDepartment(newDepartment);

                // calls the method and returns dept info from database in the form of an IEnumerable
            var departments = departmentsRepo.GetAllDepartments();

            foreach (var dept in departments)
            {
                Console.WriteLine($"{dept.DepartmentID} {dept.Name}");
            }

            Console.WriteLine();

            // PRODUCTS SECTION
            var productsRepo = new DapperProductRepository(conn);

            productsRepo.CreateProduct("Newish Laptop", 1999.99, 1);

            var products = productsRepo.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductID} {product.Name} {product.Price} {product.CategoryID} {product.OnSale} {product.StockLevel}");
                Console.WriteLine();
            }
        }
    }
}
