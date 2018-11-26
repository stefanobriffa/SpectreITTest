
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SpectreAPI.Filters
{
    public class SpectreValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var _modelState = actionContext.ModelState;
            var _errMsg = "";
            if (!_modelState.IsValid)
            {
                foreach (var val in _modelState.Values)
                {
                    foreach (var err in val.Errors)
                        _errMsg += " " + err.ErrorMessage;
                }

                actionContext.Response = actionContext.Request
                     .CreateErrorResponse(HttpStatusCode.BadRequest, _errMsg);
            }
        }
    }
}
        
    
