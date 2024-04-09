using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;


namespace Capstone.DAO
{
    public class InspectionSqlDao : IInspectionDao
    {
        private readonly string connectionString;

        private string GetInspectionStatuses = "SELECT inspection_status_type_id, inspection_type FROM inspection_status_type;";
        public InspectionSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<InspectionStatusType> GetInspectionStatusTypes()
        {
            List<InspectionStatusType> types = new List<InspectionStatusType>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(GetInspectionStatuses, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            InspectionStatusType type = new InspectionStatusType();
                            type = MapRowToType(reader);
                            types.Add(type);
                        }
                    }
                }
            }
            return types;
        }

        private InspectionStatusType MapRowToType(SqlDataReader reader)
        {
            InspectionStatusType type = new InspectionStatusType();
            type.InspectionStatusTypeId = Convert.ToInt32(reader["inspection_status_type_id"]);
            type.StatusType = Convert.ToString(reader["inspection_type"]);

            return type;
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


