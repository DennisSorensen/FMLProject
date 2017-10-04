using FML.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Transactions;
using System.Data.SqlClient;

namespace FML.DBLayer
{
    class DbCustomer : IDbCRUD<Customer>
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
                    int amountOfBookings;
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Count(*) FROM Booking WHERE StartTime <= @startTime AND EndTime>=@endTime AND RoomId=@roomId";
                        cmd.Parameters.AddWithValue("roomId", entity.RoomId);
                        cmd.Parameters.AddWithValue("startTime", entity.StartTime);
                        cmd.Parameters.AddWithValue("endTime", entity.EndTime);
                        amountOfBookings = (int)cmd.ExecuteScalar();
                    }
                    if (amountOfBookings == 0)
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "INSERT INTO Booking (RoomId, UserId, StartTime,EndTime) VALUES(@roomId, @userId,@startTime,@endTime)";
                            cmd.Parameters.AddWithValue("roomId", entity.RoomId);
                            cmd.Parameters.AddWithValue("userId", entity.UserId);
                            cmd.Parameters.AddWithValue("startTime", entity.StartTime);
                            cmd.Parameters.AddWithValue("endTime", entity.EndTime);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        throw new FaultException<Exception>(new Exception("Der er allerede en booking"));
                    }
                }
                scope.Complete();
            }
        }
    }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
