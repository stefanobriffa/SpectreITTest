using Autofac;
using DataLayer.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SpectreUnitTests
{
    public static class UnitTestingHelper
    {
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

        public static IContainer GetMockedContainer(IDBContext ctx, IUnitOfWork uow, IRepository repo)
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(uow).As<IUnitOfWork>();
            builder.RegisterInstance(ctx).As<IDBContext>();
            builder.RegisterInstance(repo).As<IRepository>();

            return builder.Build();
        }
    }
}
