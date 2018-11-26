using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using DataModels;
using DataLayer.Interfaces;
using DataLayer.Concrete;
using System.Data.Entity;
using Autofac;
using ServiceLayer;

namespace SpectreUnitTests
{
    [TestClass]
    public class UserFundsTests
    {
        Mock<IRepository> _repo;
        List<AppUser> _mockAppUserData;
        Mock<IUnitOfWork> _uow;
        Mock<ApplicationDbContext> _ctx;
        IContainer _container;

        public static Mock<DbSet<T>> CreateMockSet<T>(List<T> data)
            where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.AsQueryable().GetEnumerator());
            mockSet.Setup(m => m.AsNoTracking()).Returns(mockSet.Object);
            mockSet.Setup(m => m.Add(It.IsAny<T>())).Callback<T>((s) => data.Add(s));
            mockSet.Setup(m => m.Remove(It.IsAny<T>())).Callback<T>((s) => data.Remove(s));

            return mockSet;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _mockAppUserData = new List<AppUser>()
            {
                 new AppUser
                 {
                     UserName = "usercode2",
                     Address = "address2",
                     Country = "country2",
                     Transactions = new List<AppUserTransaction>() { new AppUserTransaction() {  TransDate = DateTime.Today, Amount = 100 } }
                 }
            };

            _repo = new Mock<IRepository>();
            _repo.Setup(m => m.GetAll<AppUser>()).Returns(_mockAppUserData).Verifiable();
            _repo.Setup(x => x.GetByStringCode<AppUser>("usercode2")).Returns(new AppUser
            {
                UserName = "usercode2",
                Address = "address2",
                Country = "country2",
                Transactions = new List<AppUserTransaction>() { new AppUserTransaction() { TransDate = DateTime.Today, Amount = 100 } }
            });

            _uow = new Mock<IUnitOfWork>();

            _ctx = new Mock<ApplicationDbContext>();
            var _users = UnitTestingHelper.CreateMockSet<AppUser>(_mockAppUserData);
            _ctx.Setup(c => c.Users).Returns(_users.Object);

            _container = UnitTestingHelper.GetMockedContainer(_ctx.Object, _uow.Object, _repo.Object);
        }

        [TestMethod]
        public void UserFundsService_MakeTransfer_NoFunds()
        {
            UserFundsService _fundService = new UserFundsService(_container);
            var _retVal = _fundService.MakeTransaction("usercode2", -300);

            Assert.IsTrue(!_retVal.Succeeded && _retVal.Errors.Contains("Insufficient Funds."));
        }

        [TestMethod]
        public void UserFundsService_MakeTransfer_HasFunds()
        {
            UserFundsService _fundService = new UserFundsService(_container);
            var _retVal = _fundService.MakeTransaction("usercode2", -10);

            Assert.IsTrue(_retVal.Succeeded);
        }
    }
}
