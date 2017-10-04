using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FML.Models;

namespace FML.BusinessLayer
{
    class ProductController : IProductController<Product>
    {
        public void Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product FindProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
