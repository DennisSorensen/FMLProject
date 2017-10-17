using FML.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Transactions;
using System.Data.SqlClient;

namespace FML.DBLayer
{
    public class DbProduct : IDbCRUD<Product>
    {
        private readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public void Create(Product product)
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
                            cmd.CommandText = "INSERT INTO Product (ProductId, Stock, Name, Price) VALUES(@ProductId, @Stock, @Name, @Price)";
                            cmd.Parameters.AddWithValue("CustomerId", product.ProductId);
                            cmd.Parameters.AddWithValue("Stock", product.Stock);
                            cmd.Parameters.AddWithValue("Name", product.Name);
                            cmd.Parameters.AddWithValue("Price", product.Price);
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
                    cmd.CommandText = "DELETE FROM Product WHERE Id=@id";
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Product Get(int productId)
        {
            Product product = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Product WHERE Id=@productId";
                    cmd.Parameters.AddWithValue("CustomerId", productId);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        product = new Product
                        {

                            ProductId = (int)reader["ProductId"],
                            Stock = (int)reader["Stock"],
                            Name = (String)reader["Name"],
                            Price = (double)reader["Price"]

                        };
                    }
                }

            }
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Product";
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Product p = new Product
                        {
                            ProductId = (int)reader["ProductId"],
                            Stock = (int)reader["Stock"],
                            Name = (String)reader["Name"],
                            Price = (double)reader["Price"]

                        };
                        products.Add(p);
                    }
                }

            }
            return products;
        }

        public void Update(Product product)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Product SET ProductId=@ProdId, Stock=@stock, Name=@name, Price=@price WHERE ID=@ProductId";
                    cmd.Parameters.AddWithValue("ProdId", product.ProductId);
                    cmd.Parameters.AddWithValue("stock", product.Stock);
                    cmd.Parameters.AddWithValue("name", product.Name);
                    cmd.Parameters.AddWithValue("price", product.Price);
                    cmd.Parameters.AddWithValue("ProductId", product.ProductId);
                    cmd.ExecuteNonQuery();

                }

            }
        }
    }
}
