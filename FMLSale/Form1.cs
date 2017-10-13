using FMLSale.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMLSale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
        }

        //ServiceReference1.Service1Client serviceclient = new ServiceReference1.Service1Client();
        ServiceReference1.IService1 service = new ServiceReference1.Service1Client();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            int c = service.Multiply(5, 5);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var customer = new Customer();
            customer = service.FindCustomer(1);
            Console.WriteLine(customer.CustomerId);
            Console.WriteLine(customer.Name);
            Console.WriteLine(customer.Commercial);
            Console.WriteLine(customer.Email);
            Console.WriteLine(customer.Address);
        }
    }
}
