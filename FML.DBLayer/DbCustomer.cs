using FML.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Transactions;
using System.Data.SqlClient;


namespace FML.DBLayer
{
    public class DbCustomer : IDbCRUD<Customer>
    {
        private readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void Create(Customer customer)
        {
            TransactionOptions to = new TransactionOptions { IsolationLevel = IsolationLevel.RepeatableRead };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, to))
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();


                    try
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "INSERT INTO Customer (CustomerId, Commercial, Name, Address, Email) VALUES(@CustomerId, @Commercial, @Name, @Address, @Email)";
                            cmd.Parameters.AddWithValue("CustomerId", customer.CustomerId);
                            cmd.Parameters.AddWithValue("Commercial", customer.Commercial);
                            cmd.Parameters.AddWithValue("Name", customer.Name);
                            cmd.Parameters.AddWithValue("Adress", customer.Address);
                            cmd.Parameters.AddWithValue("Email", customer.Email);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                }
                scope.Complete();
            }
        }
    

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Customer WHERE Id=@id";
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    

        public Customer Get(int CustomerId)
        {
            Customer customer = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Customer WHERE Id=@CustomerId";
                    cmd.Parameters.AddWithValue("CustomerId", CustomerId);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        customer = new Customer
                        {

                            CustomerId = (int)reader["CustomerId"],
                            Commercial = (bool)reader["Commercial"],
                            Name = (String)reader["Name"],
                            Address = (String)reader["Adress"],
                            Email = (String)reader["Email"]

                        };
                    }
                }

            }
            return customer; 
        }

        public IEnumerable<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Customer";
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Customer c = new Customer
                        {
                            CustomerId = (int)reader["CustomerId"],
                            Commercial = (bool)reader["Commercial"],
                            Name = (String)reader["Name"],
                            Address = (String)reader["Adress"],
                            Email = (String)reader["Email"]
                         
                        };
                        customers.Add(c);
                    }
                }

            }
            return customers;
        }

        public void Update(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Customer SET CustomerId=@cusId, Commercial=@comId, Name=@name, Address=@address, Email=@email WHERE ID=@CustomerId";
                    cmd.Parameters.AddWithValue("cusId", customer.CustomerId);
                    cmd.Parameters.AddWithValue("comId", customer.Commercial);
                    cmd.Parameters.AddWithValue("name", customer.Name);
                    cmd.Parameters.AddWithValue("address", customer.Address);
                    cmd.Parameters.AddWithValue("email", customer.Email);
                    cmd.Parameters.AddWithValue("CustomerId", customer.CustomerId);
                    cmd.ExecuteNonQuery();

                }

            }
        }
    }
}
