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

                // instantiate new DapperDepartmentsRepository
            var repo = new DapperDepartmentsRepository(conn);

            Console.WriteLine("Type a new Department name: ");

            var newDepartment = Console.ReadLine();
            Console.WriteLine("");

            repo.InsertDepartment(newDepartment);

                // calls the method and returns dept info from database in the form of an IEnumerable
            var departments = repo.GetAllDepartments();

            foreach (var dept in departments)
            {
                Console.WriteLine($"{dept.DepartmentID} {dept.Name}");
            }



            var repo = new DapperProductRepository(connection);
        }
    }
}
