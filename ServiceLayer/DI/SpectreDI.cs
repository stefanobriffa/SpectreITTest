using Autofac;
using DataLayer.Concrete;
using DataLayer.Interfaces;

namespace ServiceLayer.DI
{
    public class SpectreDI
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<ApplicationDbContext>().As<IDBContext>();
            builder.RegisterType<GenericRepo>().As<IRepository>();
            return builder.Build();
        }
    }
}