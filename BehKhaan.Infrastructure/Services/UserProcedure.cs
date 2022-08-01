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
    public class UserProcedure : IUserProcedure
    {
        private static string CS = AppSettings.GetDefaultConnectionString();

        public void CreateEditUserProcedure()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='spEditUser' and xtype='P')
                                        EXEC(
	                                        'CREATE PROCEDURE spEditUser    
						                                (	@Id UNIQUEIDENTIFIER,    
							                                @UserName VARCHAR(40), 
							                                @FullName VARCHAR(40))    
                                            AS    
                                            BEGIN    
                                                UPDATE _User     
                                                SET UserName=@UserName , FullName=@FullName   
                                                WHERE Id=@Id    
                                            END')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void CreateGetUserByIdProcedure()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='spGetUserById' and xtype='P')
                                        EXEC(
	                                        'CREATE PROCEDURE spGetUserById    
				                                        (@Id UNIQUEIDENTIFIER)    
                                            AS    
                                            BEGIN    
                                                SELECT * FROM _User WHERE Id=@Id    
                                            END ')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void CreateGetUsersProcedure()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='spGetUsers' and xtype='P')
                                        EXEC(
	                                        'CREATE PROCEDURE spGetUsers
	                                        AS
	                                        SELECT * FROM _User')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void CreateInsertUserProcedure()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='spInsertUser' and xtype='P')
                                        EXEC(
	                                        'CREATE PROCEDURE spInsertUser 
                                                       (    @UserName VARCHAR(40),
                                                            @FullName VARCHAR(40))
	                                        AS
	                                        INSERT INTO _User VALUES(NEWID(), @UserName, @FullName)')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void CreateRemoveUserProcedure()
        {
            using (SqlConnection connection = new SqlConnection(CS))
            {
                string queryString = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='spRemoveUser' and xtype='P')
                                        EXEC(
	                                        'CREATE PROCEDURE spRemoveUser    
				                                        (@Id UNIQUEIDENTIFIER)    
                                            AS    
                                            BEGIN    
                                                DELETE FROM _User WHERE Id=@Id    
                                            END ')";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
