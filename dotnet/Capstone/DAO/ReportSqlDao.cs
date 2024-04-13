using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Drawing;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;
namespace Capstone.DAO
{
    public class ReportSqlDao : IReportDao
    {
        private readonly string connectionString;
        private string countOpenPermits = "SELECT COUNT(permit_id) AS 'Number of Open Permits' FROM permit WHERE active = 1"; //counts number of active permits.
        private string countClosedPermits = "SELECT COUNT(permit_id) AS 'Number of Closed Permits' FROM permit WHERE active = 0"; //count number of inactive permits.
        private string countPendingInspections = "SELECT Count(permit.permit_id) AS 'Number of Inspections Pending' FROM permit JOIN inspections ON permit.permit_id = inspections.permit_id WHERE inspection_status_type_id = 6001"; //counts number of pending inspections(all customer ids)
        private string countPassedInspectionAll = "SELECT Count(permit.permit_id) AS 'Number of Inspections Passed' FROM permit JOIN inspections ON permit.permit_id = inspections.permit_id WHERE inspection_status_type_id = 6002"; //counts number of passed inspections (all customer ids)
        private string countFailedInspectionAll = "SELECT Count(permit.permit_id) AS 'Number of Inspections Failed' FROM permit JOIN inspections ON permit.permit_id = inspections.permit_id WHERE inspection_status_type_id = 6002"; //counts number of passed inspections


        public ReportSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public int GetAllOpenPermits()
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(countOpenPermits, conn))
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return result;
        }

        public int GetAllClosedPermits()
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(countClosedPermits, conn))
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return result;
        }

        public int GetAllPendingInspections()
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(countPendingInspections, conn))
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return result;
        }

        public int GetAllInspectionsPassed()
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(countPassedInspectionAll, conn))
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return result;
        }

        public int GetAllInspectionsFailed()
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(countFailedInspectionAll, conn))
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return result;
        }

        //private int MapRowToResult(SqlDataReader reader)
        //{
        //    int result = 0;
        //    result = Convert.ToInt32(reader["Number of Open Permits"]);
        //    return result;
        //}
        //private Permit MapRowToPermit(SqlDataReader reader)
        //{
        //    Permit permit = new Permit();
        //    permit.PermitId = Convert.ToInt32(reader["permit_id"]);
        //    permit.Active = Convert.ToBoolean(reader["active"]);
        //    permit.CustomerId = Convert.ToInt32(reader["customer_id"]);
        //    permit.PermitAddress = Convert.ToString(reader["permit_address"]);
        //    permit.PermitType = Convert.ToString(reader["permit_type"]);
        //    permit.Commercial = Convert.ToBoolean(reader["commercial"]);
        //    permit.PermitStatus = Convert.ToString(reader["permit_status"]);
        //    permit.CustomerDetails = Convert.ToString(reader["customer_details"]);
        //    return permit;
        //}

    }
}