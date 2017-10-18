using System;
using FML.Models;
using FML.BusinessLayer;

namespace FML.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        
        private ICustomerController<Customer> customerController;

        public Service1()
        {
            customerController = new CustomerController();  //<-hvis dette udkommenteres virker den
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public int Multiply(int a, int b) {
            return a * b;
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public Customer FindCustomer(int id)
        {
            Customer customer = new Customer(); //Kunde som data kan blive indlæst i

            //Klader metode i Business layer, som henter en customer fra id
            customer = customerController.Get(id); //<-hvis dette udkommenteres virker den

            //Test Data
            /*
            customer.CustomerId = 1;
            customer.Name = "Gærtrud";
            customer.Commercial = false;
            customer.Email = "Mail@mail.dk";
            customer.Address = "AAlborgvej 1";
            */

            return customer;
        }
    }
}
