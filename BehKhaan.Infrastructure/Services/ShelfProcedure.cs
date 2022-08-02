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
    public class ShelfProcedure : IShelfProcedure
    {
        private static string CS = AppSettings.GetDefaultConnectionString();
        public void CreateEditShelfProcedure()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='spEditShelf' and xtype='P')
                                        EXEC(
	                                        'CREATE PROCEDURE spEditShelf    
						                                (	@Id UNIQUEIDENTIFIER,    
							                                @Name VARCHAR(40),
							                                @UserId UNIQUEIDENTIFIER)    
                                            AS    
                                            BEGIN    
                                                UPDATE _Shelf     
                                                SET Name=@Name , UserId=@UserId    
                                                WHERE Id=@Id    
                                            END')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void CreateGetShelfByIdProcedure()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='spGetShelfById' and xtype='P')
                                        EXEC(
	                                        'CREATE PROCEDURE spGetShelfById    
				                                        (@Id UNIQUEIDENTIFIER)    
                                            AS    
                                            BEGIN    
                                                SELECT * FROM _Shelf WHERE Id=@Id    
                                            END ')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void CreateGetShelfsProcedure()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='spGetShelfs' and xtype='P')
                                        EXEC(
	                                        'CREATE PROCEDURE spGetShelfs
	                                        AS
	                                        SELECT * FROM _Shelf')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void CreateInsertShelfProcedure()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='spInsertShelf' and xtype='P')
                                        EXEC(
	                                        'CREATE PROCEDURE spInsertShelf 
                                                       (    @Name VARCHAR(40), 
									                        @UserId UNIQUEIDENTIFIER)
	                                        AS
	                                        INSERT INTO _Shelf VALUES(NEWID(), @Name, @UserId)')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void CreateRemoveShelfProcedure()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='spRemoveShelf' and xtype='P')
                                        EXEC(
	                                        'CREATE PROCEDURE spRemoveShelf    
				                                        (@Id UNIQUEIDENTIFIER)    
                                            AS    
                                            BEGIN    
                                                DELETE FROM _Shelf WHERE Id=@Id    
                                            END ')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
