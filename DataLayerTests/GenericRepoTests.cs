using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using DataModels;
using DataLayer.Interfaces;
using DataLayer.Concrete;

namespace SpectreUnitTests
{
    [TestClass]
    public class GenericRepoTests
    {
        [TestMethod]
        public void Repository_GetByStringCode()
        {
            var expected = new AppUser { UserName = "usercode",  Address = "address", Country = "country" };

            var _mockRepo = new Mock<IRepository>();
            _mockRepo.Setup(m => m.GetByStringCode<AppUser>("usercode")).Returns(expected).Verifiable();

            var _appUserReturned = _mockRepo.Object.GetByStringCode<AppUser>("usercode");

            Assert.AreEqual("usercode", _appUserReturned.UserName);
        }

        [TestMethod]
        public void Repository_SaveChanges()
        {
            AppUser _newAppUser = new AppUser { UserName = "usercode2", Address = "address2", Country = "country2" };

            List<AppUser> _mockAppUsers = new List<AppUser>()
            {
                new AppUser { UserName = "usercode", Address = "address", Country = "country" }
            };

            var _mockRepo = new Mock<IRepository>();
            _mockRepo.Setup(m => m.GetAll<AppUser>()).Returns(_mockAppUsers).Verifiable();

            var _mockUow = new Mock<IUnitOfWork>();

            var _ctx = new Mock<ApplicationDbContext>();
            var _appUsers = UnitTestingHelper.CreateMockSet<AppUser>(_mockAppUsers);
            _ctx.Setup(c => c.Users).Returns(_appUsers.Object);

            _mockRepo.Setup(m => m.SaveChanges()).Verifiable();

            _mockAppUsers.Add(_newAppUser);
            _mockRepo.Object.SaveChanges();

            _mockRepo.Verify(x =>x.SaveChanges(), Times.Once);
            Assert.IsTrue(_mockRepo.Object.GetAll<AppUser>().Count() == 2);
        }
    }
}
