
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OneInch.Api
{
    public class DefaultClient : IDefaultClient
    {
        IApiAdapter _api;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiAdapter"></param>
        public DefaultClient(IApiAdapter apiAdapter)
        {            
            _api = apiAdapter;
        }   

        public async Task<PresetList> GetPresets()
        {
            var response = await _api.SendRequest(Paths.API.DefaultPresets); 
            return JsonSerializer.Deserialize<PresetList>(response);
        }

    }
}