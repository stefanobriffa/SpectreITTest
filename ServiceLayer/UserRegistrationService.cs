using Autofac;
using DataLayer.Interfaces;
using DataModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ServiceLayer.DI;
using System.Data.Entity;
using System.Linq;

namespace ServiceLayer
{
    public class UserRegistrationService
    {
        private IContainer container;

        public UserRegistrationService()
        {
            container = SpectreDI.BuildContainer();
        }

        public UserRegistrationService(IContainer passedContainer)
        {
            container = passedContainer;
        }

        public IdentityResult Register(AppUser userToRegister)
        {
            var manager = new UserManager<AppUser>(new UserStore<AppUser>((DbContext)container.Resolve<IDBContext>() ));
            manager.PasswordValidator = new PasswordValidator() { RequiredLength = 3 };

            return manager.Create(userToRegister, userToRegister.Password); ;
        }

    }
}
