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
    public class UserService
    {
        private IContainer container;

        public UserService()
        {
            container = SpectreDI.BuildContainer();
        }

        public UserService(IContainer passedContainer)
        {
            container = passedContainer;
        }

    public ReturnValue BlockOrUnBlock(string userID, bool blockUnBlock)
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
                            if (blockUnBlock == _user.IsBlocked)
                            {
                                _retval.Succeeded = false;
                                if (blockUnBlock)
                                    _retval.Errors.Add("User already blocked.");
                                else
                                    _retval.Errors.Add("User already unblocked.");
                            }
                            else
                            {
                                _user.IsBlocked = blockUnBlock;
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
    }
}
