using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FML.Models;
using FML.DBLayer;

namespace FML.BusinessLayer
{
    public class CustomerController : ICustomerController<Customer>
    {
        private IDbCRUD<Customer> DbCRUD;
        public CustomerController()
        {
            DbCRUD = new DbCustomer();
        }
        
        public void Create(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void FindByCustomerId(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
