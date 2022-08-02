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
    public class ShelfRepository : IShelfRepository
    {
        private static string CS = AppSettings.GetDefaultConnectionString();
        public void Edit(Shelf entity)
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlCommand command = new SqlCommand("spEditShelf", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.Parameters.AddWithValue("@Id", entity.Id);
                command.Parameters.AddWithValue("@Name", entity.Name);
                command.Parameters.AddWithValue("@UserId", entity.UserId);
                command.ExecuteNonQuery();
            }
        }

        public DataTable GetAll()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("spGetShelfs", connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable shelfTable = new DataTable("ShelfTable");
                adapter.Fill(shelfTable);

                return shelfTable;
            }
        }

        public DataTable GetById(string id)
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("spGetShelfById", connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@Id", id);

                DataTable ShelfTable = new DataTable("Shelf");
                adapter.Fill(ShelfTable);

                return ShelfTable;
            }
        }

        public void Insert(Shelf entity)
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlCommand command = new SqlCommand("spInsertShelf", connection);
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", entity.Name);
                command.Parameters.AddWithValue("@UserId", entity.UserId);
                command.ExecuteNonQuery();
            }
        }

        public void Remove(string id)
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                SqlCommand command = new SqlCommand("spRemoveShelf", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
