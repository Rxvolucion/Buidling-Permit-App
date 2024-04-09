using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Capstone.DAO;
using Capstone.Models;

namespace Tutorial.Tests.DAO
{
    [TestClass]
    public class PermitSqlDaoTest : BaseDaoTests
    {

        private PermitSqlDao permitSqlDao;

        [TestInitialize]
        public override void Setup()
        {
            // Arrange - new instance of UserSqlDao before each and every test
            permitSqlDao = new PermitSqlDao(ConnectionString);
            base.Setup();

            Permit permit = new Permit
            {
                Active = true,
                CustomerId = 1001,
                PermitAddress = "49 N Merkle st",
                PermitType = "Residential",
                Commercial = false,
                PermitStatus = "Approved"
            };
            permitSqlDao.CreatePermit(permit);
        }
    

        [TestMethod]
        public void CreatePermit_ShouldCreatePermit()
        {
            // Arrange
            Permit permit = new Permit
            {
                Active = true,
                CustomerId = 1002,
                PermitAddress = "123 Sesame St",
                PermitType = "Residential",
                Commercial = false,
                PermitStatus = "Pending"

            };

            // Act
            Permit createdPermit = permitSqlDao.CreatePermit(permit);

            // Assert
            Assert.IsNotNull(createdPermit);
            Assert.AreEqual(permit.Active, createdPermit.Active);
            Assert.AreEqual(permit.CustomerId, createdPermit.CustomerId);
            Assert.AreEqual(permit.PermitAddress, createdPermit.PermitAddress);
            Assert.AreEqual(permit.PermitType, createdPermit.PermitType);
            Assert.AreEqual(permit.Commercial, createdPermit.Commercial);
            Assert.AreEqual(permit.PermitStatus, createdPermit.PermitStatus);
            Assert.IsTrue(createdPermit.PermitId > 0);
        }

        [TestMethod]
        public void GetPermitById_ShouldReturnPermit()
        {
            // Arrange
            Permit permit = new Permit
            {
                Active = true,
                CustomerId = 1002,
                PermitAddress = "123 Sesame St",
                PermitType = "Residential",
                Commercial = false,
                PermitStatus = "Approved",
            };

            Permit newPermit = permitSqlDao.CreatePermit(permit);

            // Act
            Permit retrievedPermit = permitSqlDao.GetPermitById(newPermit.PermitId);

            // Assert
            Assert.IsNotNull(retrievedPermit);
            Assert.AreEqual(newPermit.PermitId, retrievedPermit.PermitId);
            Assert.AreEqual(newPermit.Active, retrievedPermit.Active);
            Assert.AreEqual(newPermit.CustomerId, retrievedPermit.CustomerId);
            Assert.AreEqual(newPermit.PermitAddress, retrievedPermit.PermitAddress);
            Assert.AreEqual(newPermit.PermitType, retrievedPermit.PermitType);
            Assert.AreEqual(newPermit.Commercial, retrievedPermit.Commercial);
            Assert.AreEqual(newPermit.PermitStatus, retrievedPermit.PermitStatus);
        }

        [TestMethod]
        public void ListPermits_ShouldReturnAllPermits()
        {
            // Arrange
            Permit permit1 = new Permit
            {
                Active = true,
                CustomerId = 1002,
                PermitAddress = "123 Sesame St",
                PermitType = "Residential",
                Commercial = false,
                PermitStatus = "Approved"
            };

            Permit permit2 = new Permit
            {
                Active = true,
                CustomerId = 1003,
                PermitAddress = "1063 Oak st",
                PermitType = "Commercial",
                Commercial = true,
                PermitStatus = "Pending"
            };

            permitSqlDao.CreatePermit(permit1);
            permitSqlDao.CreatePermit(permit2);

            // Act
            List<Permit> permits = permitSqlDao.ListPermits();

            // Assert
            Assert.IsNotNull(permits);
            Assert.AreEqual(2, permits.Count);

        }
    }
}
