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
            DbCRUD.Create(customer);
        }

        public void Delete(int id)
        {
            DbCRUD.Delete(id);
        }

        public Customer Get(int id)
        {
            return DbCRUD.Get(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return DbCRUD.GetAll();
        }

        public void Update(Customer customer)
        {
            DbCRUD.Update(customer);
        }
    }
}
