using BehKhaan.Infrastructure.Interfaces;
using BehKhaanAdo.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Infrastructure.Services
{
    public class BookProcedure : IBookProcedure
    {
        private static string CS = AppSettings.GetDefaultConnectionString();
        public void CreateEditBookProcedure()
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

        public void CreateGetBookByIdProcedure()
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

        public void CreateGetBooksProcedure()
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

        public void CreateInsertBookProcedure()
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

        public void CreateRemoveBookProcedure()
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
    }
}
