using BehKhaan.Infrastructure.Interfaces;
using BehKhaanAdo.Domain.AppSettings;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Infrastructure.Services
{
    public class Book_ShelfProcedure : IBook_ShelfProcedure
    {
        private static string CS = AppSettings.GetDefaultConnectionString();
        public void CreateEditBook_ShelfProcedure()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='spEditBook_Shelf' and xtype='P')
                                        EXEC(
	                                        'CREATE PROCEDURE spEditBook_Shelf    
						                                (	@BookId UNIQUEIDENTIFIER,    
							                                @ShelfId UNIQUEIDENTIFIER, 
							                                @StudyState INTEGER,
							                                @PuttingTime DateTime)    
                                            AS    
                                            BEGIN    
                                                UPDATE _Book_Shelf     
                                                SET StudyState=@StudyState , PuttingTime=@PuttingTime    
                                                WHERE BookId=@BookId AND ShelfId=@ShelfId
                                            END')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void CreateGetBook_ShelfByIdProcedure()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='spGetBook_ShelfById' and xtype='P')
                                        EXEC(
	                                        'CREATE PROCEDURE spGetBook_ShelfById    
				                                        (@BookId UNIQUEIDENTIFIER,
                                                         @ShelfId UNIQUEIDENTIFIER)    
                                            AS    
                                            BEGIN    
                                                SELECT * FROM _Book_Shelf WHERE BookId=@BookId AND ShelfId=@ShelfId
                                            END ')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void CreateGetBook_ShelfsProcedure()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='spGetBook_Shelfs' and xtype='P')
                                        EXEC(
	                                        'CREATE PROCEDURE spGetBook_Shelfs
	                                        AS
	                                        SELECT * FROM _Book_Shelf')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void CreateInsertBook_ShelfProcedure()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='spInsertBook_Shelf' and xtype='P')
                                        EXEC(
	                                        'CREATE PROCEDURE spInsertBook_Shelf 
                                                       (    @BookId UNIQUEIDENTIFIER, 
									                        @ShelfId UNIQUEIDENTIFIER,
									                        @StudyState INTEGER,
									                        @PuttingTime DateTime)
	                                        AS
	                                        INSERT INTO _Book_Shelf VALUES(@BookId, @ShelfId, @StudyState, @PuttingTime)')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void CreateRemoveBook_ShelfProcedure()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='spRemoveBook_Shelf' and xtype='P')
                                        EXEC(
	                                        'CREATE PROCEDURE spRemoveBook_Shelf    
				                                        (@BookId UNIQUEIDENTIFIER,
                                                         @ShelfId UNIQUEIDENTIFIER)    
                                            AS    
                                            BEGIN    
                                                DELETE FROM _Book_Shelf WHERE BookId=@BookId AND ShelfId=@ShelfId
                                            END ')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
