using System;
using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

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

            var repo = new DapperDepartmentRepository(conn);

            //Console.Write("type a new department name:");
            //var newDepartment = Console.ReadLine();

            //repo.InsertDepartment(newDepartment);

            var departments = repo.GetAllDepartments();

            foreach (var dept in departments)
            {
                Console.WriteLine($"Department Name: {dept.Name}");
                Console.WriteLine($"DepartmentID: {dept.DepartmentID}");
            }

            //var repo1 = new DapperProductRepository(conn);


            ////repo1.CreateProduct("TestMobile",699,2);

            //var products=repo1.GetAllProducts();
            //repo1.UpdateProduct(942,"TestMobile");
            //repo1.Delete(942);
            //foreach (var product in products)
            //{
            //    Console.WriteLine($"Product Name: {product.Name}\nPrice: {product.Price}\nCategoryID: {product.CategoryID}\nProductID: {product.ProductID}");

            //}


        }
    }
}
