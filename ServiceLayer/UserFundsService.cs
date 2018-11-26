using Autofac;
using DataLayer.Interfaces;
using DataModels;
using ServiceLayer.DI;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ServiceLayer
{
    public class UserFundsService
    {
        private IContainer container;

        public UserFundsService()
        {
            container = SpectreDI.BuildContainer();
        }

        public UserFundsService(IContainer passedContainer)
        {
            container = passedContainer;
        }

        public FixerResponse GetRates()
        {
            string _fixerIOAddress = ConfigurationManager.AppSettings.Get("FixerIOAddress");
            string _fixerIOKey = ConfigurationManager.AppSettings.Get("FixerIOKey").ToString();
            FixerResponse _fr = new FixerResponse();

            if (string.IsNullOrEmpty(_fixerIOKey))
            {
                _fr.Success = false;
                _fr.Error = new Error() { Code = -1, info = "Missing Key in Confifuration" };
            }

            if (string.IsNullOrEmpty(_fixerIOAddress))
            {
                _fr.Success = false;
                _fr.Error = new Error() { Code = -2, info = "Missing web service url" };
            }

            if (_fr.Success)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_fixerIOAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.GetAsync($"latest?access_key={_fixerIOKey}").Result;
                    _fr = response.Content.ReadAsAsync<FixerResponse>().Result;
                }
            }

            return _fr;
        }

        public ReturnValue MakeTransaction(string userID, int fundAmount)
        {
            ReturnValue _retval = new ReturnValue();

            try
            {
                using (var _uow = container.Resolve<IUnitOfWork>())
                {
                    using (var _repo = container.Resolve<IRepository>())
                    {
                        _uow.StartTransaction();

                        var _user = _repo.GetByStringCode<AppUser>(userID);
                        if (_user == null)
                        {
                            _retval.Succeeded = false;
                            _retval.Errors.Add("User not found.");
                        }
                        else
                        {
                            if (_user.CurrentBalance + fundAmount <= 0)
                            {
                                _retval.Succeeded = false;
                                _retval.Errors.Add("Insufficient Funds.");
                            }
                            else
                            {
                                _user.Transactions.Add(new AppUserTransaction() { TransDate = DateTime.Now, Amount = fundAmount });
                                _repo.SaveChanges();
                                _uow.Commit();
                                _retval.AppUser = _user;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _retval.Succeeded = false;
                _retval.Errors.Add($"Error while making transaction : {ex.Message}");
            }
            

            return _retval;
        }

        public ReturnValue GeteBalance(string userID, string requiredRate)
        {
            FixerResponse _fr = GetRates();
            ReturnValue _retval = new ReturnValue();

            if (_fr.Success)
            {
                var _rate = _fr.Rates[requiredRate];

                try
                {
                    using (var _repo = container.Resolve<IRepository>())
                    {
                        var _user = _repo.GetByStringCode<AppUser>(userID);
                        if (_user == null)
                        {
                            _retval.Succeeded = false;
                            _retval.Errors.Add("User not found.");
                        }
                        else
                        {
                            _user.CurrentBalanceForeignCurrency = _user.CurrentBalance * _rate;
                            _retval.AppUser = _user;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _retval.Succeeded = false;
                    _retval.Errors.Add($"Error while retrieving user data : {ex.Message}");
                }
            }
            else
            {
                _retval.Succeeded = false;
                _retval.Errors.Add($"Exchange Rates web service error : {_fr.Error.info} [{ _fr.Error.Code }]");
            }

            return _retval;
        }
    }
}
