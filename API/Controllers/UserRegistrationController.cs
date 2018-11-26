using DataModels;
using ServiceLayer;
using SpectreAPI.Filters;
using SpectreAPI.Models;
using System.Linq;
using System.Web.Http;

namespace SpectreAPI.Controllers
{
    public class UserRegistrationController : ApiController
    {        
        [HttpPost]
        [Route("api/Register")]
        public AppReturnObject Register(UserAccount userRegistration)
        {
            var _user = new AppUser()
            {
                UserName = userRegistration.UserName,
                Email = userRegistration.Email,
                FirstName = userRegistration.FirstName,
                LastName = userRegistration.LastName,
                Country = userRegistration.Country,
                Address = userRegistration.Address,
                Password = userRegistration.Password
            };

            var _serviceResult = new UserRegistrationService().Register(_user);
            AppReturnObject _retval = new AppReturnObject() { Succeeded = _serviceResult.Succeeded, Errors = _serviceResult.Errors.ToList() };

            if (_serviceResult.Succeeded)
            {
                userRegistration.Id = _user.Id;
                userRegistration.CurrentBalance = _user.CurrentBalance;
                _retval.UserAccount = userRegistration;
            }

            return _retval;
        }
    }
}
