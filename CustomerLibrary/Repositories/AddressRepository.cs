using CustomerLibrary.Interfaces;
using CustomerInformation;
using System.Data.SqlClient;
using System.Data;

namespace CustomerLibrary.Repositories
{
    public class AddressRepository : BaseRepository, IRepository<Address>
    {
            public void Create(Address entity)
            {
                using var connection = GetConnection();
                connection.Open();
                var command = new SqlCommand(
                 "INSERT INTO [Address] (AddressLine, AddressLine2, AddressType, City,PostalCode, State,Country,CustomerId) VALUES (@AddressLine, @AddressLine2, @AddressType, @City,@PostalCode, @State,@Country,@CustomerId) ", connection);

                var AddressLineParam = new SqlParameter("@AddressLine", SqlDbType.VarChar, 100)
                {
                    Value = entity.FirstLine
                };

                var AddressLine2Param = new SqlParameter("@AddressLine2", SqlDbType.VarChar, 100)
                {
                    Value = entity.SecondLine
                };

                var AddressTypeParam = new SqlParameter("@AddressType", SqlDbType.VarChar, 50)
                {
                    Value = entity.Type
                };

                var CityParam = new SqlParameter("@City", SqlDbType.VarChar, 50)
                {
                    Value = entity.City
                };

                var PostalCodeParam = new SqlParameter("@PostalCode", SqlDbType.VarChar, 6)
                {
                    Value = entity.PostalCode
                };

                var StateParam = new SqlParameter("@State", SqlDbType.VarChar, 20)
                {
                    Value = entity.State
                };

                var CountryParam = new SqlParameter("@Country", SqlDbType.VarChar, 50)
                {
                    Value = entity.Country
                };
                var CustomerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = entity.CustomerId
                };


                command.Parameters.Add(AddressLineParam);
                command.Parameters.Add(AddressLine2Param);
                command.Parameters.Add(AddressTypeParam);
                command.Parameters.Add(CityParam);
                command.Parameters.Add(PostalCodeParam);
                command.Parameters.Add(StateParam);
                command.Parameters.Add(CountryParam);
                command.Parameters.Add(CustomerIdParam);

            command.ExecuteNonQuery();

            }

            public Address Read(int EntityCode)
            {
                using var connection = GetConnection();
                connection.Open();
                var command = new SqlCommand(
                 "SELECT * FROM [Address] WHERE CustomerId= @CustomerId", connection);

                var CustomerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = EntityCode
                };
                command.Parameters.Add(CustomerIdParam);

                using var reader = command.ExecuteReader();
                AddressType resultType;
                AvailableCountries resultCountry;

                if (reader.Read())
                {
                    Enum.TryParse<AddressType>(reader["AddressType"].ToString(), out resultType);
                    Enum.TryParse<AvailableCountries>(reader["Country"].ToString(), out resultCountry);
                    return new Address
                      {
                         FirstLine = reader["AddressLine"].ToString(),
                         SecondLine = reader["AddressLine2"].ToString(),
                         Type = resultType,
                         City = reader["City"].ToString(),
                         PostalCode = reader["PostalCode"].ToString(),
                         State = reader["State"].ToString(),
                         Country = resultCountry,
                         CustomerId = Convert.ToInt16(reader["CustomerId"])
                       };
                }
                return null;
            }


            public void Update(Address entity)
            {
                using var connection = GetConnection();
                connection.Open();
                var command = new SqlCommand(
                 @"UPDATE [Address] SET 
                 AddressLine= @AddressLine, 
                 AddressLine2 = @AddressLine2, 
                 AddressType = @AddressType,  
                 City = @City,
                 PostalCode = @PostalCode,
                 State = @State,
                 Country = @Country,
                 CustomerId = @CustomerId
                 WHERE CustomerId=@CustomerId", connection);

            var AddressLineParam = new SqlParameter("@AddressLine", SqlDbType.VarChar, 100)
            {
                Value = entity.FirstLine
            };

            var AddressLine2Param = new SqlParameter("@AddressLine2", SqlDbType.VarChar, 100)
            {
                Value = entity.SecondLine
            };

            var AddressTypeParam = new SqlParameter("@AddressType", SqlDbType.VarChar, 50)
            {
                Value = entity.Type
            };

            var CityParam = new SqlParameter("@City", SqlDbType.VarChar, 50)
            {
                Value = entity.City
            };

            var PostalCodeParam = new SqlParameter("@PostalCode", SqlDbType.VarChar, 6)
            {
                Value = entity.PostalCode
            };

            var StateParam = new SqlParameter("@State", SqlDbType.VarChar, 20)
            {
                Value = entity.State
            };

            var CountryParam = new SqlParameter("@Country", SqlDbType.VarChar, 50)
            {
                Value = entity.Country
            };
            var CustomerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
            {
                Value = entity.CustomerId
            };


            command.Parameters.Add(AddressLineParam);
            command.Parameters.Add(AddressLine2Param);
            command.Parameters.Add(AddressTypeParam);
            command.Parameters.Add(CityParam);
            command.Parameters.Add(PostalCodeParam);
            command.Parameters.Add(StateParam);
            command.Parameters.Add(CountryParam);
            command.Parameters.Add(CustomerIdParam);

            command.ExecuteNonQuery();

            }

            public void Delete(Address entity)
            {
                using var connection = GetConnection();
                connection.Open();
                var command = new SqlCommand(
                 "DELETE FROM [Address] WHERE CustomerId= @CustomerId", connection);

            var CustomerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
            {
                Value = entity.CustomerId
            };
            command.Parameters.Add(CustomerIdParam);

            command.ExecuteNonQuery();
            }
    }
}

