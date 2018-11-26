using SpectreAPI.Models;
using System.Net.Http;
using System.Web.Http.Filters;

namespace SpectreAPI.Filters
{
    public class SpectreAPIExceptionFilter : ExceptionFilterAttribute
    {        
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var _reponse = new HttpResponseMessage();

            if (actionExecutedContext.Exception != null)
            {
                if ((actionExecutedContext.Exception is SpectreAPIHandledException))
                {
                    _reponse = new HttpResponseMessage()
                    {
                        //Content = new StringContent(POYCJSONError.CreateJSONErrorMessage("An error occured within the services of the application, Please try again later. In the meantime we apologize for any inconvenience", "POYCUnhandledException"),
                        //                    System.Text.Encoding.UTF8, "text/plain"),
                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                    };
                }
                else
                {
                    _reponse = new HttpResponseMessage()
                    {
                        Content = new StringContent("An error occured within the services of the application, Please try again later. In the meantime we apologize for any inconvenience", 
                                            System.Text.Encoding.UTF8, "text/plain"),
                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                    };
                }

            }

            actionExecutedContext.Response = _reponse;
        }
    }
}
        
    
