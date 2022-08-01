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

        /*private const string DB_NAME = "BehKhaanLibrary";
        private const string USER_TABLE_NAME = "_User";
        private const string BOOK_TABLE_NAME = "_Book";
        private const string SHELF_TABLE_NAME = "_Shelf";
        private const string INSERT_NEW_BOOK_PROCEDURE_NAME = "";
        private const string GET_BOOKS_PROCEDURE_NAME = "spGetBooks";*/

        private static string CS = AppSettings.GetDefaultConnectionString();

        public DbInitializer(IBookProcedure bookProcedure)
        {
            _bookProcedure = bookProcedure;
        }

        public void Seed()
        {
            CreateDb();
            UseDb();
            CreateTables();
            CreateProcedures();

        }

        private static void CreateDb()
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

        private static void UseDb()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"USE TESTAK";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static void CreateTables()
        {
            CreateUserTable();
            CreateBookTable();
            CreateShelfTable();
            CreateBookShelfTable();
        }

        private static void CreateUserTable()
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

        private static void CreateBookTable()
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

        private static void CreateShelfTable()
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

        private static void CreateBookShelfTable()
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
            // Book 
            _bookProcedure.CreateInsertBookProcedure();
            _bookProcedure.CreateGetBooksProcedure();
            _bookProcedure.CreateEditBookProcedure();
            _bookProcedure.CreateRemoveBookProcedure();
            _bookProcedure.CreateGetBookByIdProcedure();
            /*
            CreateInsertBookProcedure();
            CreateGetBooksProcedure();
            CreateEditBookProcedure();
            CreateRemoveBookProcedure();
            CreateGetBookByIdProcedure();
            */
            // User


        }

        /*
        private static void CreateInsertBookProcedure()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='spInsertBook' and xtype='P')
                                        EXEC(
	                                        'CREATE PROCEDURE spInsertBook 
                                                       (    @ISBN VARCHAR(40), 
									                        @Name VARCHAR(40),
									                        @Rate INTEGER,
									                        @Price INTEGER)
	                                        AS
	                                        INSERT INTO _Book VALUES(NEWID(), @ISBN, @Name, @Rate, @Price)')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static void CreateGetBooksProcedure()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='spGetBooks' and xtype='P')
                                        EXEC(
	                                        'CREATE PROCEDURE spGetBooks
	                                        AS
	                                        SELECT * FROM _Book')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static void CreateEditBookProcedure()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='spEditBook' and xtype='P')
                                        EXEC(
	                                        'CREATE PROCEDURE spEditBook    
						                                (	@Id UNIQUEIDENTIFIER,    
							                                @ISBN VARCHAR(40), 
							                                @Name VARCHAR(40),
							                                @Rate INTEGER,
							                                @Price INTEGER)    
                                            AS    
                                            BEGIN    
                                                UPDATE _Book     
                                                SET ISBN=@ISBN , Name=@Name, Rate=@Rate, Price=@Price    
                                                WHERE Id=@Id    
                                            END')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static void CreateRemoveBookProcedure()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='spRemoveBook' and xtype='P')
                                        EXEC(
	                                        'CREATE PROCEDURE spRemoveBook    
				                                        (@Id UNIQUEIDENTIFIER)    
                                            AS    
                                            BEGIN    
                                                DELETE FROM _Book WHERE Id=@Id    
                                            END ')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static void CreateGetBookByIdProcedure()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='spGetBookById' and xtype='P')
                                        EXEC(
	                                        'CREATE PROCEDURE spGetBookById    
				                                        (@Id UNIQUEIDENTIFIER)    
                                            AS    
                                            BEGIN    
                                                SELECT * FROM _Book WHERE Id=@Id    
                                            END ')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        */


    }
}
