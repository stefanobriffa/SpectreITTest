using DataModels;
using ServiceLayer;
using SpectreAPI.Models;
using System.Linq;
using System.Web.Http;

namespace SpectreAPI.Controllers
{
    [Authorize]
    public class UserFundsController : ApiController
    {
        [HttpPost]
        [Route("api/MakeTransaction")]
        public AppReturnObject MakeTransaction(UserFunds userFunds)
        {
            var _serviceResult = new UserFundsService().MakeTransaction(userFunds.UserID, userFunds.Amount);
            AppReturnObject _retval = new AppReturnObject() { Succeeded = _serviceResult.Succeeded, Errors = _serviceResult.Errors.ToList() };
            if (_serviceResult.Succeeded)
                _retval.UserAccount = new UserAccount() { Id = userFunds.UserID, CurrentBalance = _serviceResult.AppUser.CurrentBalance };

            return _retval;
        }

        [HttpPost]
        [Route("api/GetBalance")]
        public AppReturnObject GetBalance(UserGetBalance userGetBalance)
        {
            var _serviceResult = new UserFundsService().GeteBalance(userGetBalance.UserID, userGetBalance.ExchangeRate);
            AppReturnObject _retval = new AppReturnObject() { Succeeded = _serviceResult.Succeeded, Errors = _serviceResult.Errors.ToList() };
            if (_serviceResult.Succeeded)
                _retval.UserAccount = new UserAccount() { Id = userGetBalance.UserID, CurrentBalanceForeignCurrency = _serviceResult.AppUser.CurrentBalanceForeignCurrency, CurrentBalance = _serviceResult.AppUser.CurrentBalance };

            return _retval;
        }
    }
}
