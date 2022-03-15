using System;
using System.Collections.Generic;
using System.Data;

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

        public void CreateProduct(string name, double price, int categoryID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<products> GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}
