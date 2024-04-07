using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;
namespace Capstone.DAO
{
    public class PermitSqlDao : IPermitDao
    {
        private readonly string connectionString;
        public PermitSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        //public Permit CreatePermit(bool active, int customerId, string permitAddress, string permit_type, bool commerical)
        //{
        //    //User newUser = null;
        //    //IPasswordHasher passwordHasher = new PasswordHasher();
        //    //PasswordHash hash = passwordHasher.ComputeHash(password);
        //    //string sql = "INSERT INTO users (username, password_hash, salt, user_role) " +
        //    //             "OUTPUT INSERTED.user_id " +
        //    //             "VALUES (@username, @password_hash, @salt, @user_role)";
        //    //int newUserId = 0;
        //    //try
        //    //{
        //    //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    //    {
        //    //        conn.Open();
        //    //        SqlCommand cmd = new SqlCommand(sql, conn);
        //    //        cmd.Parameters.AddWithValue("@username", username);
        //    //        cmd.Parameters.AddWithValue("@password_hash", hash.Password);
        //    //        cmd.Parameters.AddWithValue("@salt", hash.Salt);
        //    //        cmd.Parameters.AddWithValue("@user_role", role);
        //    //        newUserId = Convert.ToInt32(cmd.ExecuteScalar());
        //    //    }
        //    //    newUser = GetUserById(newUserId);
        //    //}
        //    //catch (SqlException ex)
        //    //{
        //    //    throw new DaoException("SQL exception occurred", ex);
        //    //}
        //    //return newUser;
        //}
    }
}