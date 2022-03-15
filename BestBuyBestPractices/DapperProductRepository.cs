using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        // constructor
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        // Writes to the database
        public void CreateProduct(string newName, double newPrice, int newCategoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@productName, @price, @categoryID);",
                new { productName = newName, price = newPrice, categoryID = newCategoryID });
        }

        // Reads from the database
        public IEnumerable<products> GetAllProducts()
        {
            return _connection.Query<products>("SELECT * FROM products;");
        }

        // Updates database
        public void UpdateProductName(int productID, string updatedName)
        {
            _connection.Execute("UPDATE products SET Name = @updatedName WHERE ProductID = @productID;",
                new { updatedName = updatedName, productID = productID });
        }

        // Deletes from database
        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID;",
                new { productID = productID });

            _connection.Execute("DELETE FROM sales WHERE ProductID = @productID;",
                new { productID = productID });

            _connection.Execute("DELETE FROM products WHERE ProductID = @productID;",
                new { productID = productID });
        }
    }
}
