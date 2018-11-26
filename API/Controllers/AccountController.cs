using DataModels;
using ServiceLayer;
using SpectreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace SpectreAPI.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet]
        [Route("api/GetUserClaims")]
        public UserAccount GetUserClaims()
        {
            var _identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = _identityClaims.Claims;
            UserAccount _model = new UserAccount()
            {
                UserName = _identityClaims.FindFirst("Username").Value,
                Email = _identityClaims.FindFirst("Email").Value,
                FirstName = _identityClaims.FindFirst("FirstName").Value,
                LastName = _identityClaims.FindFirst("LastName").Value,
                LoggedOn = _identityClaims.FindFirst("LoggedOn").Value
            };
            return _model;
        }

        //[Authorize]
        [HttpGet]
        [Route("api/User/Block")]
        public AppReturnObject Block(string userID)
        {
            var _serviceResult = new UserService().BlockOrUnBlock(userID, true);
            AppReturnObject _retval = new AppReturnObject() { Succeeded = _serviceResult.Succeeded, Errors = _serviceResult.Errors.ToList() };
            if (_serviceResult.Succeeded)
                _retval.UserAccount = new UserAccount() { Id = userID };

            return _retval;

        }

        [HttpGet]
        [Route("api/User/UnBlock")]
        public AppReturnObject UnBlock(string userID)
        {
            var _serviceResult = new UserService().BlockOrUnBlock(userID, false);
            AppReturnObject _retval = new AppReturnObject() { Succeeded = _serviceResult.Succeeded, Errors = _serviceResult.Errors.ToList() };
            if (_serviceResult.Succeeded)
                _retval.UserAccount = new UserAccount() { Id = userID };

            return _retval;
        }
    }
}
