using BehKhaan.Infrastructure.Interfaces;
using BehKhaanAdo.Domain.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Infrastructure
{
    public class DbInitializer
    {
        private readonly IBookProcedure _bookProcedure;
        private readonly IUserProcedure _userProcedure;

        private static string CS = AppSettings.GetDefaultConnectionString();

        public DbInitializer(IBookProcedure bookProcedure, IUserProcedure userProcedure)
        {
            _bookProcedure = bookProcedure;
            _userProcedure = userProcedure;
        }

        public void Seed()
        {
            CreateDb();
            UseDb();
            CreateTables();
            CreateProcedures();

        }

        private void CreateDb()
        {
            string serverCS = AppSettings.GetServerConnectionString();
            using (SqlConnection connection = new SqlConnection(serverCS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'TESTAK')
                                        CREATE DATABASE TESTAK ";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void UseDb()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"USE TESTAK";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void CreateTables()
        {
            CreateUserTable();
            CreateBookTable();
            CreateShelfTable();
            CreateBookShelfTable();
        }

        private void CreateUserTable()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='_User' and xtype='U')
                                        CREATE TABLE _User (
	                                        Id UNIQUEIDENTIFIER NOT NULL,
	                                        UserName VARCHAR(40) NOT NULL,
	                                        FullName VARCHAR(40) NOT NULL,
	                                        CONSTRAINT pk_User PRIMARY KEY(Id)
	                                    )";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void CreateBookTable()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='_Book' and xtype='U')
                                        CREATE TABLE _Book (
	                                        Id UNIQUEIDENTIFIER NOT NULL,
                                            ISBN VARCHAR(40) NOT NULL,
                                            Name VARCHAR(40) NOT NULL,
                                            Rate INTEGER NOT NULL,
                                            Price INTEGER NOT NULL,
                                            CONSTRAINT pk_Book PRIMARY KEY(Id)
                                        )";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void CreateShelfTable()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='_Shelf' and xtype='U')
                                        CREATE TABLE _Shelf (
		                                    Id UNIQUEIDENTIFIER NOT NULL,
		                                    ShelfName VARCHAR(40) NOT NULL,
		                                    UserId UNIQUEIDENTIFIER NOT NULL,
		                                    CONSTRAINT fk_Shelf_User FOREIGN KEY(UserId) REFERENCES _User(Id),
		                                    CONSTRAINT pk_Shelf PRIMARY KEY(Id)
	                                    )";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void CreateBookShelfTable()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='_Book_Shelf' and xtype='U')
                                        CREATE TABLE _Book_Shelf (
		                                    BookId UNIQUEIDENTIFIER NOT NULL,
	                                        ShelfId UNIQUEIDENTIFIER NOT NULL,
	                                        StudyState INTEGER NOT NULL,
	                                        PuttingTime DateTime NOT NULL,
	                                        CONSTRAINT fk_Book_Shelf_Book FOREIGN KEY(BookId) REFERENCES _Book(Id),
	                                        CONSTRAINT fk_Book_Shelf_Shelf FOREIGN KEY(ShelfId) REFERENCES _Shelf(Id),
	                                        CONSTRAINT pk_Book_Shelf PRIMARY KEY(BookId, ShelfId)
	                                    )";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void CreateProcedures()
        {
            // BookProcedure 
            _bookProcedure.CreateEditBookProcedure();
            _bookProcedure.CreateGetBookByIdProcedure();
            _bookProcedure.CreateGetBooksProcedure();
            _bookProcedure.CreateInsertBookProcedure();
            _bookProcedure.CreateRemoveBookProcedure();

            // UserProcedure 
            _userProcedure.CreateEditUserProcedure();
            _userProcedure.CreateGetUserByIdProcedure();
            _userProcedure.CreateGetUsersProcedure();
            _userProcedure.CreateInsertUserProcedure();
            _userProcedure.CreateRemoveUserProcedure();

            // ShelfProcedure 
            
            
            // Book_ShelfProcedure 


        }


    }
}
