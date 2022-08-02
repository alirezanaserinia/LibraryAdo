using BehKhaanAdo.Domain.AppSettings;
using BehKhaanAdo.Domain.Entities;
using BehKhaanAdo.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Infrastructure.Repositories
{
    public class Book_ShelfRepository : IBook_ShelfRepository
    {
        private static string CS = AppSettings.GetDefaultConnectionString();
        public void Edit(Book_Shelf entity)
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlCommand command = new SqlCommand("spEditBook_Shelf", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.Parameters.AddWithValue("@BookId", entity.BookId);
                command.Parameters.AddWithValue("@ShelfId", entity.ShelfId);
                command.Parameters.AddWithValue("@StudyState", entity.StudyState);
                command.Parameters.AddWithValue("@PuttingTime", entity.PuttingTime);
                command.ExecuteNonQuery();
            }
        }

        public DataTable GetAll()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("spGetBook_Shelfs", connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable book_ShelfTable = new DataTable("Book_ShelfTable");
                adapter.Fill(book_ShelfTable);

                return book_ShelfTable;
            }
        }

        public DataTable GetById(string bookId, string shelfId)
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("spGetBook_ShelfById", connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@BookId", bookId);
                adapter.SelectCommand.Parameters.AddWithValue("@ShelfId", shelfId);

                DataTable book_ShelfTable = new DataTable("Book_Shelf");
                adapter.Fill(book_ShelfTable);

                return book_ShelfTable;
            }
        }

        public void Insert(Book_Shelf entity)
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlCommand command = new SqlCommand("spInsertBook_Shelf", connection);
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookId", entity.BookId);
                command.Parameters.AddWithValue("@ShelfId", entity.ShelfId);
                command.Parameters.AddWithValue("@StudyState", entity.StudyState);
                command.Parameters.AddWithValue("@PuttingTime", entity.PuttingTime.ToString("MM/dd/yyyy HH:mm:ss"));
                command.ExecuteNonQuery();
            }
        }

        public void Remove(string bookId, string shelfId)
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlCommand command = new SqlCommand("spRemoveBook_Shelf", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.Parameters.AddWithValue("@BookId", bookId);
                command.Parameters.AddWithValue("@ShelfId", shelfId);
                command.ExecuteNonQuery();
            }
        }
    }
}
