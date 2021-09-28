
using System.Threading.Tasks;
using System.Text.Json;

namespace OneInch.Api
{
    public class HealthCheckClient
    {
        IApiAdapter _api;
        public HealthCheckClient(IApiAdapter apiAdapter)
        {            
            _api = apiAdapter;
        }
        
        public async Task<HealthCheck> GetStatus()
        {
            var response = await _api.SendRequest(Paths.API.HealthCheck);
            return JsonSerializer.Deserialize<HealthCheck>(response);
        }
    }

}