using CustomerInformation;
using CustomerLibrary.Entities;
using CustomerLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLibrary.Repositories
{
    public class NoteRepository : BaseRepository, IRepository<Note>
    {
        public void Create(Note entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                 "INSERT INTO [Notes] (Note, CustomerId) VALUES (@Note,@CustomerId) ", connection);

                var NoteParam = new SqlParameter("@Note", SqlDbType.VarChar, 50)
                {
                    Value = entity.NoteLine
                };
                var CustomerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = entity.CustomerId
                };

                command.Parameters.Add(NoteParam);
                command.Parameters.Add(CustomerIdParam);

                command.ExecuteNonQuery();
            }


        }


        public Note Read(int EntityCode)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                 "SELECT * FROM [Notes] WHERE NoteId= @NoteId", connection);

                var NoteIdParam = new SqlParameter("@NoteId", SqlDbType.Int)
                {
                    Value = EntityCode
                };
                command.Parameters.Add(NoteIdParam);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Note
                        {
                            NoteLine = reader["Note"].ToString(),
                            CustomerId = (int)reader["CustomerId"]
                        };
                    }
                    return null;

                }

            }


        }


        public void Update(Note entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                 @"UPDATE [Notes] SET 
                 Note= @Note, 
                 CustomerId = @CustomerId
                 WHERE NoteId=@NoteId", connection);

                var NoteParam = new SqlParameter("@Note", SqlDbType.VarChar, 50)
                {
                    Value = entity.NoteLine
                };
                var CustomerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = entity.CustomerId
                };

                var NoteIdParam = new SqlParameter("@NoteId", SqlDbType.Int)
                {
                    Value = entity.NoteId
                };

                command.Parameters.Add(NoteParam);
                command.Parameters.Add(CustomerIdParam);
                command.Parameters.Add(NoteIdParam);

                command.ExecuteNonQuery();
            }


        }

        public bool Delete(int entityCode)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                 "DELETE FROM [Notes] WHERE NoteId=@NoteId", connection);

                var NoteIdParam = new SqlParameter("@NoteId", SqlDbType.Int)
                {
                    Value = entityCode
                };
                command.Parameters.Add(NoteIdParam);

                command.ExecuteNonQuery();
                return true;

            }

        }

        public List<Note> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Note> GetAllCustomerNotes(int EntityCode)
        {
            var notes = new List<Note>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                 "SELECT * FROM [Notes] WHERE CustomerId= @CustomerId", connection);

                var CustomerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = EntityCode
                };
                command.Parameters.Add(CustomerIdParam);

                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {

                        notes.Add(new Note
                        {
                            NoteId = (int)reader["NoteId"],
                            NoteLine = reader["Note"].ToString(),
                            CustomerId = Convert.ToInt16(reader["CustomerId"])
                        });
                    }
                    return notes;
                }

            }
        }

    }
}

