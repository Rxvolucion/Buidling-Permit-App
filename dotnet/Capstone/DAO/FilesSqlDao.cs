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
    public class FilesSqlDao : IFilesDao
    {
        private string connectionString;

        private string InsertUrlSql = "INSERT INTO inspection_files (inspection_URLs) " +
            "OUTPUT INSERTED.inspection_files_id VALUES (@inspection_URLs);";

        private string GetInspectionFilesById = "SELECT inspection_files_id, inspection_URLs FROM inspection_files WHERE inspection_files_id = @inspection_files_id;";

        public FilesSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Files InsertFileURLs(string URL)
        {
            Files newFile = null;
            int newFileId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(InsertUrlSql, conn);
                    cmd.Parameters.AddWithValue("@inspection_URLs", URL);
                    newFileId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                newFile = GetFileById(newFileId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }
            return newFile;
        }

        public Files GetFileById(int fileId)
        {
            Files file = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(GetInspectionFilesById, conn))
                {
                    cmd.Parameters.AddWithValue("@inspection_files_id", fileId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            file = MapRowToFile(reader);
                        }
                    }
                }
            }
            return file;
        }

        private Files MapRowToFile(SqlDataReader reader)
        {
            Files file = new Files();
            file.InspectionFilesId = Convert.ToInt32(reader["inspection_files_id"]);
            file.InspectionURLs = Convert.ToString(reader["inspection_URLs"]);

            return file;
        }
    }
}