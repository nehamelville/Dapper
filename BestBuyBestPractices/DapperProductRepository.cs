using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace BestBuyBestPractices
{
    public class DapperProductRepository:IProductRepository
    {
        private readonly IDbConnection _connection;
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO Products(Name,Price,CategoryID) values(@name, @price,@categoryID);",
                new { name = name, price = price, categoryID = categoryID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products;");
        }

        public void UpdateProduct(int productID, string name)
        {
            _connection.Execute("UPDATE Products set Name=@name where ProductID=@productID;",new { productID = productID, name = name });
        }

        public void Delete(int productID)
        {
            _connection.Execute("DELETE FROM Sales where ProductID=@productID;", new { productID = productID });
            _connection.Execute("DELETE FROM Reviews where ProductID=@productID;", new { productID = productID });
            _connection.Execute("DELETE FROM Products where ProductID=@productID;", new { productID = productID });
          
           
        }
    }
}
