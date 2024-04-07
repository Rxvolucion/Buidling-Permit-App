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

        private string CreatePermitSql = "INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial) " +
             "OUTPUT INSERTED.permit_id " +
             "VALUES (@active, @customer_id, @permit_address, @permit_type, @commercial)";

        private string GetPermitByIdSql = "SELECT permit_id, active, customer_id, permit_address, permit_type, commercial " +
            "FROM permit WHERE permit_id = @permit_id"; 
        public PermitSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }


        public Permit GetPermitById(int permitId)
        {
            Permit permit = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(GetPermitByIdSql, conn))
                {
                    cmd.Parameters.AddWithValue("@permit_id", permitId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            permit = MapRowToPermit(reader);
                        }
                    }
                }
            }
            return permit;
        }

        public Permit CreatePermit(Permit permit)
        {
            Permit newPermit = null;

            int newPermitId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(CreatePermitSql, conn);
                    cmd.Parameters.AddWithValue("@active", permit.Active);
                    cmd.Parameters.AddWithValue("@customer_id", permit.CustomerId);
                    cmd.Parameters.AddWithValue("@permit_address", permit.PermitAddress);
                    cmd.Parameters.AddWithValue("@permit_type", permit.PermitType);
                    cmd.Parameters.AddWithValue("@commercial", permit.Commercial);

                    newPermitId = Convert.ToInt32(cmd.ExecuteScalar());

                }
                newPermit = GetPermitById(newPermitId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return newPermit;
        }

        private Permit MapRowToPermit(SqlDataReader reader)
        {
            Permit permit = new Permit();
            permit.PermitId = Convert.ToInt32(reader["permit_id"]);
            permit.Active = Convert.ToBoolean(reader["active"]);
            permit.CustomerId = Convert.ToInt32(reader["customer_id"]);
            permit.PermitAddress = Convert.ToString(reader["permit_address"]);
            permit.PermitType = Convert.ToString(reader["permit_type"]);
            permit.Commercial = Convert.ToBoolean(reader["commercial"]);
            
            return permit;
        }
    }
}


