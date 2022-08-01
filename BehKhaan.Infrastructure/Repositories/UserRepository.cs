using BehKhaanAdo.Domain.Entities;
using BehKhaanAdo.Domain.IRepositories;
using BehKhaanAdo.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static string CS = AppSettings.GetDefaultConnectionString();

        public void Edit(User entity)
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlCommand command = new SqlCommand("spEditUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.Parameters.AddWithValue("@Id", entity.Id);
                command.Parameters.AddWithValue("@UserName", entity.UserName);
                command.Parameters.AddWithValue("@FullName", entity.FullName);
                command.ExecuteNonQuery();
            }
        }

        public DataTable GetAll()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("spGetUsers", connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable bookTable = new DataTable("UserTable");
                adapter.Fill(bookTable);

                return bookTable;
            }
        }

        public DataTable GetById(string id)
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("spGetUserById", connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@Id", id);

                DataTable userTable = new DataTable("User");
                adapter.Fill(userTable);

                return userTable;
            }
        }

        public void Insert(User entity)
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlCommand command = new SqlCommand("spInsertUser", connection);
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", entity.UserName);
                command.Parameters.AddWithValue("@FullName", entity.FullName);
                command.ExecuteNonQuery();
            }
        }

        public void Remove(string id)
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlCommand command = new SqlCommand("spRemoveUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
