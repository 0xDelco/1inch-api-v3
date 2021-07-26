
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;

namespace OneInch.Web
{
    public interface IProtocolService
    {
        ProtocolList  GetNames();
        List<Protocol>  GetAll();
    }

    public class ProtocolClient
    {
        IApiAdapter _api;
        public ProtocolClient(IApiAdapter apiAdapter)
        {
            _api = apiAdapter;
        }
        public async Task<ProtocolList> GetNameListings()
        {
            var response = await _api.SendRequest(Paths.API.ProtocolNames); 
            return JsonSerializer.Deserialize<ProtocolList>(response);
        }

        public async Task<List<Protocol>> GetAll()
        {
            var response = await _api.SendRequest(Paths.API.Protocols); 
            return JsonSerializer.Deserialize<List<Protocol>>(response);
        }

    }
}