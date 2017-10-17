using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FML.Models;
using FML.DBLayer;

namespace FML.BusinessLayer
{
    public class ProductController : IProductController<Product>
    {
        private IDbCRUD<Product> DbCRUD;
        public ProductController()
        {
            DbCRUD = new DbProduct();
        }
        public void Create(Product product)
        {
            DbCRUD.Create(product);
        }

        public void Delete(int id)
        {
            DbCRUD.Delete(id);
        }

        public Product Get(int id)
        {
            return DbCRUD.Get(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return DbCRUD.GetAll();
        }

        public void Update(Product product)
        {
            DbCRUD.Update(product);
        }
    }
}
