using CustomerLibrary.Interfaces;
using CustomerInformation;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using CustomerLibrary.Entities;

namespace CustomerLibrary.Repositories
{
    public class CustomerRepository : BaseRepository,IRepository<CustomerClass>
    {
        public void Create(CustomerClass entity)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand(
             "INSERT INTO [Customer] (FirstName, LastName, PhoneNumber, Email, TotalPurchasesAmount) VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @TotalPurchasesAmount) ", connection);
            
            var FirstNameParam = new SqlParameter("@FirstName", SqlDbType.VarChar, 50)
            {
                Value = entity.FirstName
            };

            var LastNameParam = new SqlParameter("@LastName", SqlDbType.VarChar, 50)
            {
                Value = entity.LastName
            };

            var PhoneNumberParam = new SqlParameter("@PhoneNumber", SqlDbType.VarChar, 13)
            {
                Value = entity.PhoneNumber
            };

            var EmailParam = new SqlParameter("@Email", SqlDbType.VarChar, 50)
            {
                Value = entity.Email
            };

            var TotalPurchasesAmountParam = new SqlParameter("@TotalPurchasesAmount", SqlDbType.Money)
            {
                Value = entity.TotalPurchasesAmount
            };
            command.Parameters.Add(FirstNameParam);
            command.Parameters.Add(LastNameParam);
            command.Parameters.Add(PhoneNumberParam);
            command.Parameters.Add(EmailParam);
            command.Parameters.Add(TotalPurchasesAmountParam);

                command.ExecuteNonQuery();

        }

        public CustomerClass Read(int EntityCode)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand(
             "SELECT * FROM [Customer] WHERE CustomerId= @Id", connection);

            var IdParam = new SqlParameter("@Id", SqlDbType.VarChar, 50)
            {
                Value = EntityCode
            };
            command.Parameters.Add(IdParam);

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new CustomerClass
                {
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    Email = reader["Email"].ToString(),
                    TotalPurchasesAmount = Convert.ToDecimal(reader["TotalPurchasesAmount"].ToString())
                };
            }
            return null;
        }


        public void Update(CustomerClass entity)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand(
             @"UPDATE [Customer] SET 
             FirstName= @FirstName, 
             LastName = @LastName, 
             Email = @Email,  
             PhoneNumber = @PhoneNumber,
             TotalPurchasesAmount = @TotalPurchasesAmount
             WHERE CustomerId=@Id", connection);

            var EmailParam = new SqlParameter("@Email", SqlDbType.VarChar, 50)
            {
                Value = entity.Email,
            };
            var FirstNameParam = new SqlParameter("@FirstName", SqlDbType.VarChar, 50)
            {
                Value = entity.FirstName,
            };
            var LastNameParam = new SqlParameter("@LastName", SqlDbType.VarChar, 50)
            {
                Value = entity.LastName
            };

            var PhoneNumberParam = new SqlParameter("@PhoneNumber", SqlDbType.VarChar, 13)
            {
                Value = entity.PhoneNumber
            };
            var TotalPurchasesAmountParam = new SqlParameter("@TotalPurchasesAmount", SqlDbType.Money)
            {
                Value = entity.TotalPurchasesAmount
            };
            var IdParam = new SqlParameter("@Id", SqlDbType.VarChar, 50)
            {
                Value = entity.ID,
            };
           
            command.Parameters.Add(EmailParam);
            command.Parameters.Add(FirstNameParam);
            command.Parameters.Add(LastNameParam);
            command.Parameters.Add(PhoneNumberParam);
            command.Parameters.Add(TotalPurchasesAmountParam);
            command.Parameters.Add(IdParam);

            command.ExecuteNonQuery();

        }

        public bool Delete(int EntityCode)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand(
             "DELETE FROM [Customer] WHERE CustomerID= @Id", connection);

            var IdParam = new SqlParameter("@Id", SqlDbType.VarChar, 50)
            {
                Value = EntityCode,
            };
            command.Parameters.Add(IdParam);
            command.ExecuteNonQuery();
            return true;
        }

        public List<CustomerClass> GetAll()
        {
            var customers = new List<CustomerClass>();
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand(
             "SELECT * FROM [Customer] ", connection);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                customers.Add(new CustomerClass
                {   ID = (int)reader["CustomerId"],
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    Email = reader["Email"].ToString(),
                    TotalPurchasesAmount = Convert.ToDecimal(reader["TotalPurchasesAmount"].ToString())
                });  
      
            }
            return customers;
        }

    }
}
