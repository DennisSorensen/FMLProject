using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using FML.Models;

namespace FML.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
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
            Customer cust = new Customer();
            cust.CustomerId = 1;
            cust.Commercial = false;
            cust.Address = "AAlborg";
            cust.Email = "Mail@mail.dk";
            cust.Name = "Gruppe 3";
            Console.WriteLine(id);
            return cust;
        }
    }
}
