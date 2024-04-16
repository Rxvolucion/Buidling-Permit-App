using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Capstone.DAO
{
    public class UserSqlDao : IUserDao
    {
        private readonly string connectionString;

        public UserSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

//----------ADDED--------------------------------------------------------
        public string GetUserEmailByUserPermitId(int permitId)
        {
            User user = null;

            string sql = "SELECT users.user_id, users.username, users.password_hash, users.salt, users.user_role, users.employee, users.email, users.active FROM users " + 
            "JOIN customer ON users.user_id = customer.user_id " +
            "JOIN permit ON customer.customer_id = permit.customer_id WHERE permit_id = @permit_id;";
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@permit_id", permitId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        user = MapRowToUser(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return user.Email;
        }
//-------ADDED-----------------------------------------------------------------------
        public IList<User> GetUsers()
        {
            IList<User> users = new List<User>();

            string sql = "SELECT user_id, username, password_hash, salt, user_role, employee, email, active FROM users";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        User user = MapRowToUser(reader);
                        users.Add(user);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return users;
        }

        public IList<int> GetAllCustomerIds()
        {
            IList<Customer> customers = new List<Customer>();
            IList<int> customerIds = new List<int>();

            string sql = "SELECT customer_id, user_id, contractor, address FROM customer";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Customer customer = MapRowToCustomer(reader);
                        customers.Add(customer);
                        
                    }
                    foreach (Customer customer in customers)
                    {
                        customerIds.Add(customer.CustomerId);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return customerIds;
        }



        public User GetUserById(int userId)
        {
            User user = null;

            string sql = "SELECT user_id, username, password_hash, salt, user_role, employee, email, active FROM users WHERE user_id = @user_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) 
                    {
                        user = MapRowToUser(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return user;
        }

        public User GetUserByUsername(string username)
        {
            User user = null;

            string sql = "SELECT user_id, username, password_hash, salt, user_role, employee, email, active FROM users WHERE username = @username";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        user = MapRowToUser(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return user;
        }

        public User CreateUser(string username, string password, string role, bool isEmployee, string email, bool active)
        {
            User newUser = null;

            IPasswordHasher passwordHasher = new PasswordHasher();
            PasswordHash hash = passwordHasher.ComputeHash(password);

            string sql = "INSERT INTO users (username, password_hash, salt, user_role, employee, email, active) " +
                         "OUTPUT INSERTED.user_id " +
                         "VALUES (@username, @password_hash, @salt, @user_role ,@employee, @email, @active)";

            int newUserId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password_hash", hash.Password);
                    cmd.Parameters.AddWithValue("@salt", hash.Salt);
                    cmd.Parameters.AddWithValue("@employee", isEmployee);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@active", active);
                    cmd.Parameters.AddWithValue("@user_role", role);

                    newUserId = Convert.ToInt32(cmd.ExecuteScalar());
                    
                }
                newUser = GetUserById(newUserId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return newUser;
        }

        public Customer GetCustomerById(int customerId)
        {
            Customer customer = null;

            string sql = "SELECT customer_id, user_id, contractor, address FROM customer WHERE customer_id = @customer_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@customer_id", customerId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        customer = MapRowToCustomer(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return customer;
        }


        public Customer CreateCustomer(int userId, bool isContractor, string Address)
        {
            Customer newCustomer = null;

            //IPasswordHasher passwordHasher = new PasswordHasher();
            //PasswordHash hash = passwordHasher.ComputeHash(password);

            string sql = "INSERT INTO customer (user_id, contractor, address) " +
                       "OUTPUT INSERTED.customer_id " +
                       "VALUES (@user_id, @contractor, @address)";

            int newCustomerId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@contractor", isContractor);
                    cmd.Parameters.AddWithValue("@address", Address);

                    newCustomerId = Convert.ToInt32(cmd.ExecuteScalar());

                }
                newCustomer = GetCustomerById(newCustomerId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return newCustomer;
        }

        public Customer GetCustomerByUserId(int userId)
        {
            Customer customer = null;

            string sql = "SELECT customer_id, user_id, contractor, address FROM customer WHERE user_id = @user_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        customer = MapRowToCustomer(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return customer;
        }


        private User MapRowToUser(SqlDataReader reader)
        {
            User user = new User();
            user.UserId = Convert.ToInt32(reader["user_id"]);
            user.Username = Convert.ToString(reader["username"]);
            user.PasswordHash = Convert.ToString(reader["password_hash"]);
            user.Salt = Convert.ToString(reader["salt"]);
            user.IsEmployee = Convert.ToBoolean(reader["employee"]);
            user.Email = Convert.ToString(reader["email"]);
            user.Active = Convert.ToBoolean(reader["active"]);
            user.Role = Convert.ToString(reader["user_role"]);
            return user;
        }
        private Customer MapRowToCustomer(SqlDataReader reader)
        {
            Customer customer = new Customer();
            customer.CustomerId = Convert.ToInt32(reader["customer_id"]);
            customer.UserId = Convert.ToInt32(reader["user_id"]);
            customer.Contractor = Convert.ToBoolean(reader["contractor"]);
            customer.Address = Convert.ToString(reader["address"]);
            return customer;
        }
    }
}
