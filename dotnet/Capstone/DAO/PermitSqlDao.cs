using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;


namespace Capstone.DAO
{
    public class PermitSqlDao : IPermitDao
    {
        private readonly string connectionString;
        //private string CreatePermitSql = "INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status) " +
        //     "OUTPUT INSERTED.permit_id " +
        //     "VALUES (@active, @customer_id, @permit_address, @permit_type, @commercial, @permit_status)";
        private string CreatePermitSql = "INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) " +
     "OUTPUT INSERTED.permit_id " +
     "VALUES (@active, @customer_id, @permit_address, @permit_type, @commercial, @permit_status, @customer_details)";
        private string GetPermitByIdSql = "SELECT permit_id, active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details " +
            "FROM permit WHERE permit_id = @permit_id";
        private string GetAllPermits = "SELECT permit_id, active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details FROM permit;";
        private string permitsByUserId = "SELECT permit.permit_id, permit.active, customer.customer_id, permit.permit_address, permit.permit_type, permit.commercial, permit.permit_status, permit.customer_details FROM customer " +
        "JOIN permit ON customer.customer_id = permit.customer_id " + "WHERE permit.customer_id = @customer_id;";
        private string UpdatePermitByPermitIdSql = "UPDATE permit SET permit_status=@permit_status WHERE permit_id = @permit_id";
        private string OpenClosePermitSql = "UPDATE permit SET active= ~active WHERE permit_id = @permit_id;";
        private string GetAllInspectionsAndPermitsSql = "SELECT permit.permit_id, inspections.inspection_id FROM permit " +
        "JOIN inspections ON permit.permit_id = inspections.permit_id;";

        //private string GetAllInactivePermitsSql = "SELECT permit_id, permit_address, permit_type, commercial, permit.permit_status, permit.customer_details, inspection_status_type.inspection_type " +
        //        "FROM permit JOIN inspections ON permit.permit_id = inspections.permit_id JOIN inspection_status_type ON inspections.inspection_status_type_id = inspection_status_type.inspection_status_type_id " +
        //        "WHERE permit.active = 0;";
        private string GetAllInactivePermitsSql = "SELECT permit_id, permit_address, permit_type, commercial, permit_status, customer_details FROM permit WHERE active = 0;";
        private string EditPermitByIdSql = "UPDATE permit SET permit_type= @permit_type, permit_address = @permit_address, commercial = @commercial, customer_details = @customer_details WHERE permit_id = @permit_id;";


        public PermitSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }


        public List<Permit> FilterPermits(PermitSearchDTO permitSearchDTO)
        {
            string sql = BuildSqlSearchString(permitSearchDTO);

            List<Permit> permits = new List<Permit>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (permitSearchDTO.PermitId != 0)
                    {
                        cmd.Parameters.AddWithValue("@permit_id", permitSearchDTO.PermitId);
                    }
                    if (!string.IsNullOrEmpty(permitSearchDTO.PermitAddress))
                    {
                        cmd.Parameters.AddWithValue("@permit_address", permitSearchDTO.PermitAddress);
                    }
                    if (permitSearchDTO.CustomerId != 0)
                    {
                        cmd.Parameters.AddWithValue("@customer_id", permitSearchDTO.CustomerId);
                    }
                    if (!string.IsNullOrEmpty(permitSearchDTO.PermitType))
                    {
                        cmd.Parameters.AddWithValue("@permit_type", permitSearchDTO.PermitType);
                    }

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



        public Permit UpdatePermitCustomer(PermitCustomerEditDTO updatedPermitDTO)
        {
            Permit updatedPermit = new Permit();
            updatedPermit.PermitId = updatedPermitDTO.PermitId;
            updatedPermit.PermitType = updatedPermitDTO.PermitType;
            updatedPermit.PermitAddress = updatedPermitDTO.PermitAddress;
            updatedPermit.Commercial = updatedPermitDTO.Commercial;
            updatedPermit.CustomerDetails = updatedPermitDTO.CustomerDetails;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(EditPermitByIdSql, conn))
                {
                    cmd.Parameters.AddWithValue("@permit_id", updatedPermit.PermitId);
                    cmd.Parameters.AddWithValue("@permit_type", updatedPermit.PermitType);
                    cmd.Parameters.AddWithValue("@permit_address", updatedPermit.PermitAddress);
                    cmd.Parameters.AddWithValue("@commercial", updatedPermit.Commercial);
                    cmd.Parameters.AddWithValue("@customer_details", updatedPermit.CustomerDetails);

                    int count = cmd.ExecuteNonQuery();
                    if (count == 1)
                    {
                        return updatedPermit;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        public List<PermitIdInspectionIdDTO> GetAllInspectionsAndPermits()
        {
            List<PermitIdInspectionIdDTO> permits = new List<PermitIdInspectionIdDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(GetAllInspectionsAndPermitsSql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PermitIdInspectionIdDTO permit = new PermitIdInspectionIdDTO();
                            permit = MapRowToInspectionAndPermit(reader);
                            permits.Add(permit);
                        }
                    }
                }
            }
            return permits;
        }
        public int OpenClosePermit(int permitId)
        {
            //Permit updatedPermit = new Permit();
            //updatedPermit.PermitId = permitId;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(OpenClosePermitSql, conn))
                {
                    cmd.Parameters.AddWithValue("@permit_id", permitId);
                    int count = cmd.ExecuteNonQuery();
                    if (count == 1)
                    {
                        return permitId;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
        public Permit UpdatePermit(PermitStatusDTO permitStatusDTO)
        {
            Permit updatedPermit = new Permit();
            updatedPermit.PermitId = permitStatusDTO.PermitId;
            updatedPermit.PermitStatus = permitStatusDTO.PermitStatus;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(UpdatePermitByPermitIdSql, conn))
                {
                    cmd.Parameters.AddWithValue("@permit_status", updatedPermit.PermitStatus);
                    cmd.Parameters.AddWithValue("@permit_id", updatedPermit.PermitId);
                    int count = cmd.ExecuteNonQuery();
                    if (count == 1)
                    {
                        return updatedPermit;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
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
                    cmd.Parameters.AddWithValue("@customer_details", permit.CustomerDetails);
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
        public List<PermitArchiveDTO> GetAllInactivePermitsAndInspections()
        {
            List<PermitArchiveDTO> permits = new List<PermitArchiveDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(GetAllInactivePermitsSql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PermitArchiveDTO permit = new PermitArchiveDTO();
                            permit = MapRowToPermitArchive(reader);
                            permits.Add(permit);
                        }
                    }
                }
            }
            return permits;
        }

        public string BuildSqlSearchString(PermitSearchDTO permitSearchDTO)
        {
            string perId = "";
            string perAdd = "";
            string custId = "";
            string perType = "";
            string searchPermitSql = "SELECT permit_id, active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details FROM permit";

            if (permitSearchDTO.PermitId != 0 || !string.IsNullOrEmpty(permitSearchDTO.PermitAddress) || permitSearchDTO.CustomerId != 0 || !string.IsNullOrEmpty(permitSearchDTO.PermitType))
            {
                if (permitSearchDTO.PermitId != 0)
                {
                    if (!string.IsNullOrEmpty(permitSearchDTO.PermitAddress) || permitSearchDTO.CustomerId != 0 || !string.IsNullOrEmpty(permitSearchDTO.PermitType))
                    {
                        perId = "permit_id = @permit_id AND ";
                    }
                    else
                    {
                        perId = "permit_id = @permit_id ";
                    }
                }

                if (!string.IsNullOrEmpty(permitSearchDTO.PermitAddress))
                {
                    if (permitSearchDTO.CustomerId != 0 || !string.IsNullOrEmpty(permitSearchDTO.PermitType))
                    {
                        perAdd = "permit_address LIKE '%'+@permit_address+'%' AND ";
                    }
                    else
                    {
                        perAdd = "permit_address LIKE '%'+@permit_address+'%' ";
                    }

                }

                if (permitSearchDTO.CustomerId != 0)
                {
                    if (!string.IsNullOrEmpty(permitSearchDTO.PermitType))
                    {
                        custId = "customer_id = @customer_id AND ";
                    }
                    else
                    {
                        custId = "customer_id = @customer_id ";
                    }
                }

                if (!string.IsNullOrEmpty(permitSearchDTO.PermitType))
                {
                    perType = "permit_type LIKE '%'+@permit_type+'%' ";
                }

                searchPermitSql = "SELECT permit_id, active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details FROM permit WHERE " +
                perId + perAdd + custId + perType + ";";
            } 
            
            return searchPermitSql;

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
            permit.CustomerDetails = Convert.ToString(reader["customer_details"]);
            return permit;
        }
        private PermitIdInspectionIdDTO MapRowToInspectionAndPermit(SqlDataReader reader)
        {
            PermitIdInspectionIdDTO permit = new PermitIdInspectionIdDTO();
            permit.PermitId = Convert.ToInt32(reader["permit_id"]);
            permit.InspectionId = Convert.ToInt32(reader["inspection_id"]);
            return permit;
        }
        private PermitArchiveDTO MapRowToPermitArchive(SqlDataReader reader)
        {
            PermitArchiveDTO permit = new PermitArchiveDTO();
            permit.PermitId = Convert.ToInt32(reader["permit_id"]);
            permit.PermitAddress = Convert.ToString(reader["permit_address"]);
            permit.PermitType = Convert.ToString(reader["permit_type"]);
            permit.Commercial = Convert.ToBoolean(reader["commercial"]);
            permit.PermitStatus = Convert.ToString(reader["permit_status"]);
            permit.CustomerDetails = Convert.ToString(reader["customer_details"]);
            //permit.InspectionType = Convert.ToString(reader["inspection_type"]);
            return permit;
        }
    }
}