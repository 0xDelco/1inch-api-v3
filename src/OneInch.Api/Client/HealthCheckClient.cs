
using System.Threading.Tasks;
using System.Text.Json;

namespace OneInch.Api
{
    /// <summary>
    /// Client that manages requests with the "HealthCheck" service.
    /// </summary>
    /// <remarks>Check if service is able to handle requests.</remarks>    
    /// <see href="https://docs.1inch.io/api/healthcheck">HealthCheck documentation</see>
    public class HealthCheckClient : IHealthCheckClient
    {
        IApiAdapter _api;

        /// <summary>
        /// Invokes instance of client with IApiAdapter.
        /// </summary>
        /// <param name="apiAdapter">IApiAdapter to manage HTTPS requests.</param>
        public HealthCheckClient(IApiAdapter apiAdapter)
        {            
            _api = apiAdapter;
        }
        
        /// <summary>
        /// Check if service is able to handle requests.
        /// </summary>
        /// <returns>HealthCheck status response.</returns>
        public async Task<HealthCheck> GetStatus()
        {
            var response = await _api.SendRequest(Paths.API.HealthCheck);
            return JsonSerializer.Deserialize<HealthCheck>(response);
        }
    }

}