using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DapperProductRepository : IProductRepository
    {
        public void CreateProduct(string name, double price, int categoryID)
        {
            throw new NotImplementedException();
        }

        private readonly IDbConnection _conn;

        public DapperProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products");
        }

        public void DeleteProduct(int id)
        {
            _conn.Execute("DELETE FROM sales WHERE ProductID = @id;", new {id = id});
            _conn.Execute("DELETE FROM reviews WHERE ProductID = @id;", new {id = id});
            _conn.Execute("DELETE FROM products WHERE ProductID = @id;", new {id = id});
        }
    }
}
