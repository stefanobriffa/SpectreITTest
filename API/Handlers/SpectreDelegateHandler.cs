using NLog;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SpectreAPI.Handlers
{
    public class SpectreDelegateHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var _invokationTimestamp = DateTime.Now;
            var _requestBody = await request.Content.ReadAsStringAsync();
            var _requestURI = request.RequestUri.ToString();
            var _response = await base.SendAsync(request, cancellationToken);
            var _resposeBody = await _response.Content.ReadAsStringAsync();
            var _responseStatus = _response.StatusCode.ToString();
            var _responseTimestamp = DateTime.Now;

            LogToDatabase(_requestURI, _requestBody, _resposeBody, _responseStatus, _invokationTimestamp, _responseTimestamp);

            return _response;
        }

        public void LogToDatabase(string endPoint, string requestBody, string responseBody, string responseStatus, DateTime invokationTime, DateTime responseTime)
        {
            try
            {
                GlobalDiagnosticsContext.Set("endPoint", endPoint);
                GlobalDiagnosticsContext.Set("requestBody", requestBody);
                GlobalDiagnosticsContext.Set("responseCode", responseStatus);
                GlobalDiagnosticsContext.Set("responseBody", responseBody);
                GlobalDiagnosticsContext.Set("invokationTimeStamp", invokationTime);
                GlobalDiagnosticsContext.Set("responseTimeStamp", responseTime);

                Logger logger;

                logger = LogManager.GetLogger("DatabaseLogger");
                logger.Log(LogLevel.Info, "");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}