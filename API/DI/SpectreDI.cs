using Autofac;
using DataLayer.Concrete;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpectreAPI.DI
{
    public class SpectreDI
    {
        public static IContainer BuildContainer(string ProjectName)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<ApplicationDbContext>().As<IDBContext>();
            builder.RegisterType<GenericRepo>().As<IRepository>();
            return builder.Build();
        }
    }
}