using BehKhaanAdo.Domain.AppSettings;
using BehKhaanAdo.Domain.Entities;
using BehKhaanAdo.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private static string CS = AppSettings.GetDefaultConnectionString();
        public void Edit(Book entity)
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlCommand command = new SqlCommand("spEditBook", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.Parameters.AddWithValue("@Id", entity.Id);
                command.Parameters.AddWithValue("@ISBN", entity.ISBN);
                command.Parameters.AddWithValue("@Name", entity.Name);
                command.Parameters.AddWithValue("@Rate", entity.Rate);
                command.Parameters.AddWithValue("@Price", entity.Price);
                command.ExecuteNonQuery();
            }
        }
        public DataTable GetAll()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("spGetBooks", connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                
                DataTable bookTable = new DataTable("BookTable");
                adapter.Fill(bookTable);
                
                return bookTable;
            }
        }

        public DataTable GetById(string id)
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("spGetBookById", connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@Id", id);

                DataTable bookTable = new DataTable("Book");
                adapter.Fill(bookTable);

                return bookTable;
            }
        }

        public void Insert(Book entity)
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlCommand command = new SqlCommand("spInsertBook", connection);
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ISBN", entity.ISBN);
                command.Parameters.AddWithValue("@Name", entity.Name);
                command.Parameters.AddWithValue("@Rate", entity.Rate);
                command.Parameters.AddWithValue("@Price", entity.Price);
                command.ExecuteNonQuery();
            }
        }

        public void Remove(string id)
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlCommand command = new SqlCommand("spRemoveBook", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
