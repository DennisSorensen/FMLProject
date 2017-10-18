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
        ServiceReference1.IService1 service = new ServiceReference1.Service1Client(); //Vires service reference, sådan vi kan kalde 

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

        private void button4_Click(object sender, EventArgs e) //Søg kanppen på customer
        {
            var customer = new Customer(); //Grunden til vi kan se Customer er pga vores service reference til FML.Service
            int customerIdInt = Int32.Parse(textBox2.Text); //Laver vores input om til en int.
            customer = service.FindCustomer(customerIdInt); //Kalder vores service med customerId, og ligger returværdien i customer.
            
            if (customer != null) { //Tjekker om der er kommet en customer
                //Indsætter customer i listbox
                listBox2.Items.Add(customer.CustomerId);
                listBox2.Items.Add(customer.Name);
                listBox2.Items.Add(customer.Commercial);
                listBox2.Items.Add(customer.Email);
                listBox2.Items.Add(customer.Address);
            } else
            {
                listBox2.Items.Add("Not Valid");
            }
            
        }

        private void label3_Click(object sender, EventArgs e) 
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) //ListBox til output på customer
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) //Textbox med customerId
        {

        }
    }
}
