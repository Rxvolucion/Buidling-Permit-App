using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Capstone.DAO;
using Capstone.Models;

namespace Tutorial.Tests.DAO
{
    [TestClass]
    public class UserSqlDaoTest : BaseDaoTests
    {

        private UserSqlDao userSqlDao;

        [TestInitialize]
        public override void Setup()
        {
            // Arrange - new instance of UserSqlDao before each and every test
            userSqlDao = new UserSqlDao(ConnectionString);
            base.Setup();
        }

        [TestMethod]
        public void GetUsers_ShouldReturnAllUsers()
        {
            // Arrange
            UserSqlDao dao = new UserSqlDao(ConnectionString);

            // Act
            IList<User> users = dao.GetUsers();

            // Assert
            Assert.IsNotNull(users);
            Assert.AreEqual(2, users.Count);
        }

        [TestMethod]
        public void GetUserById_ShouldReturnUser()
        {
            // Arrange
            UserSqlDao dao = new UserSqlDao(ConnectionString);
            int userId = 1001;

            // Act
            User user = dao.GetUserById(userId);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(userId, user.UserId);
        }

        [TestMethod]
        public void GetUserByUsername_ShouldReturnUser()
        {
            // Arrange
            UserSqlDao dao = new UserSqlDao(ConnectionString);
            string username = "testuser";

            // Act
            User user = dao.GetUserByUsername(username);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(username, user.Username);
        }

        [TestMethod]
        public void CreateUser_ShouldCreateUser()
        {
            // Arrange
            UserSqlDao dao = new UserSqlDao(ConnectionString);
            string username = "testuser";
            string password = "password";
            string role = "user";
            bool isEmployee = false;
            string email = "testuser@gmail.com";
            bool active = true;

            // Act
            User newUser = dao.CreateUser(username, password, role, isEmployee, email, active);

            // Assert
            Assert.IsNotNull(newUser);
            Assert.AreEqual(username, newUser.Username);
            Assert.AreEqual(role, newUser.Role);
            Assert.AreEqual(email, newUser.Email);
            Assert.AreEqual(active, newUser.Active);
        }

        [TestMethod]
        public void GetCustomerById_ShouldReturnCustomer()
        {
            // Arrange
            UserSqlDao dao = new UserSqlDao(ConnectionString);
            int customerId = 1001;

            // Act
            Customer customer = dao.GetCustomerById(customerId);

            // Assert
            Assert.IsNotNull(customer);
            Assert.AreEqual(customerId, customer.CustomerId);
        }

        [TestMethod]
        public void CreateCustomer_ShouldCreateCustomer()
        {
            // Arrange
            UserSqlDao dao = new UserSqlDao(ConnectionString);
            int userId = 1003;
            bool isContractor = true;
            string address = "1063 Oak St Columbus, OH";

            // Act
            Customer newCustomer = dao.CreateCustomer(userId, isContractor, address);

            // Assert
            Assert.IsNotNull(newCustomer);
            Assert.AreEqual(userId, newCustomer.UserId);
            //Assert.AreEqual(isContractor, newCustomer.IsContractor);
            Assert.AreEqual(address, newCustomer.Address);
        }

    }
}
