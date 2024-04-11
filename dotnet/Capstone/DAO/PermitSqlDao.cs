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

        private string CreatePermitSql = "INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status) " +
             "OUTPUT INSERTED.permit_id " +
             "VALUES (@active, @customer_id, @permit_address, @permit_type, @commercial, @permit_status)";

        private string GetPermitByIdSql = "SELECT permit_id, active, customer_id, permit_address, permit_type, commercial, permit_status " +
            "FROM permit WHERE permit_id = @permit_id";

        private string GetAllPermits = "SELECT permit_id, active, customer_id, permit_address, permit_type, commercial, permit_status FROM permit;";

        private string permitsByUserId = "SELECT permit.permit_id, permit.active, customer.customer_id, permit.permit_address, permit.permit_type, permit.commercial, permit.permit_status FROM customer " +
        "JOIN permit ON customer.customer_id = permit.customer_id " + "WHERE permit.customer_id = @customer_id;";

        private string UpdatePermitByPermitIdSql = "UPDATE permit SET permit_status_id=@permit_status WHERE permit_id = @permit_id";

        //private string GetPermitStatusTypes = "SELECT permit_id, active, customer_id, permit_address, permit_type, commercial, permit_status FROM permit;";

        public PermitSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        //public Permit UpdatePermit(PermitStatusDTO permitStatusDTO)
        //{
        //    Permit updatedPermit = new Permit();
        //    updatedInspection.InspectionId = inspectionDTO.InspectionId;
        //    updatedInspection.PermitId = inspectionDTO.PermitId;
        //    updatedInspection.DateVariable = inspectionDTO.DateVariable;
        //    //updatedInspection.InspectionTypeId = GetInspectionIdByType(inspectionDTO.InspectionType).InspectionTypeId;//get id by type
        //    updatedInspection.InspectionStatusTypeId = GetStatusTypeIdByType(inspectionDTO.InspectionStatus); //get id by status

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand(UpdateInspectionStatusSql, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@inspection_status_type_id", updatedInspection.InspectionStatusTypeId);
        //            cmd.Parameters.AddWithValue("@inspection_id", updatedInspection.InspectionId);
        //            int count = cmd.ExecuteNonQuery();
        //            if (count == 1)
        //            {
        //                return updatedInspection;
        //            }
        //            else
        //            {
        //                return null;
        //            }
        //        }
        //    }
        //}

        //public List<string> GetPermitStatuses()
        //{
        //    List<string> permitStatuses = new List<string>();
        //    List<Permit> permits = new List<Permit>();
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand(GetAllPermits, conn))
        //        {
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    //string permitStatus = "";
        //                    Permit permit = new Permit();
        //                    permit = MapRowToPermit(reader);
        //                    permits.Add(permit);
        //                    permitStatuses.Add(permit.PermitStatus);

        //                }
        //            }
        //        }
        //    }
        //    return permitStatuses;
        //}

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
                    cmd.Parameters.AddWithValue("@permit_status", permit.PermitStatus);

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
        public List<Permit> ListPermits()
        {
            List<Permit> permits = new List<Permit>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(GetAllPermits, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Permit permit = new Permit();
                            permit = MapRowToPermit(reader);
                            permits.Add(permit);
                        }
                    }
                }
            }
            return permits;
        }

        public List<Permit> GetPermitsByCustomerId(int customerId)
        {
            List<Permit> permits = new List<Permit>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(permitsByUserId, conn))
                {
                    cmd.Parameters.AddWithValue("@customer_id", customerId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Permit permit = new Permit();
                            permit = MapRowToPermit(reader);
                            permits.Add(permit);
                        }
                    }
                }
            }
            return permits;
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
            permit.PermitStatus = Convert.ToString(reader["permit_status"]);

            return permit;
        }

    }
}


