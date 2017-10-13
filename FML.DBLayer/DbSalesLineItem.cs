using FML.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Transactions;
using System.Data.SqlClient;

namespace FML.DBLayer
{
    class DbSalesLineItem : IDbCRUD<SalesLineItem>
    {
        private readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public void Create(SalesLineItem salesLineItem)
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
                            cmd.CommandText = "INSERT INTO SalesLineItem (Count, Product) VALUES(@Count, @Product)";
                            cmd.Parameters.AddWithValue("Count", salesLineItem.Count);
                            cmd.Parameters.AddWithValue("Product", salesLineItem.Product);

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

        public void Delete(int SLIid)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM SalesLineItem WHERE Id=@SLIid";
                    cmd.Parameters.AddWithValue("id", SLIid);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public SalesLineItem Get(int SLIId)
        {
            SalesLineItem salesLineItem = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM SalesLineItem WHERE Id=@SLIId";
                    cmd.Parameters.AddWithValue("SalesLineItemId", SLIId);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        salesLineItem = new SalesLineItem
                        {


                            Count = (int)reader["Count"],
                            Product = (Product)reader["Product"],


                        };
                    }
                }

            }
            return salesLineItem;
        }

        public IEnumerable<SalesLineItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(SalesLineItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
