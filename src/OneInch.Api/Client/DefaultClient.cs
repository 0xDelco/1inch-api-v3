
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OneInch.Api
{

    /// <summary>
    /// Client that manages requests with the "Default" service.
    /// </summary>
    /// <remarks>Gets API defaults and preset configurations.</remarks>    
    public class DefaultClient : IDefaultClient
    {
        IApiAdapter _api;
        
        /// <summary>
        /// Invokes instance of client with IApiAdapter.
        /// </summary>
        /// <param name="apiAdapter">IApiAdapter to manage HTTPS requests.</param>
        public DefaultClient(IApiAdapter apiAdapter)
        {            
            _api = apiAdapter;
        }   

        /// <summary>
        /// Gets default and preset configurations.
        /// </summary>
        /// <returns>PresetList response.</returns>
        public async Task<PresetList> GetPresets()
        {
            var response = await _api.SendRequest(Paths.API.DefaultPresets); 
            return JsonSerializer.Deserialize<PresetList>(response);
        }

    }
}