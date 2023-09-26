using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

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

#region Department Section

            var departmentRepo = new DapperDepartmentRepository(conn);

            departmentRepo.InsertDepartment("Xtra Large Electronics");

            var departments = departmentRepo.GetAllDepartments();

            foreach (var item in departments)
            {
                Console.WriteLine(item.DepartmentID);
                Console.WriteLine(item.Name);
                Console.WriteLine();
                Console.WriteLine();
            }
#endregion


#region Product Section

            var productRepo = new DapperProductRepository(conn);    //instantiating the product repository

            productRepo.DeleteProduct(885);                         // this line deleted product with id = 885

            var products = productRepo.GetAllProducts();

            foreach (var item in products)
            {
                Console.WriteLine(item.ProductID);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Price);
                Console.WriteLine(item.CategoryID);
                Console.WriteLine(item.OnSale);
                Console.WriteLine(item.StockLevel);
                Console.WriteLine();
                Console.WriteLine();
            }

#endregion




        }
    }
}
