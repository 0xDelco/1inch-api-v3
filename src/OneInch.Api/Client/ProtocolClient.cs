
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;

namespace OneInch.Api
{
    /// <summary> 
    /// Client that manages requests with the "Protocol" service.
    /// </summary>
    /// <remarks>All supported liquidity protocols.</remarks>    
    /// <see href="https://docs.1inch.io/api/protocols">Protocols documentation</see>
    public class ProtocolClient : IProtocolClient
    {
        IApiAdapter _api;

        /// <summary>
        /// Invokes instance of client with IApiAdapter.
        /// </summary>
        /// <param name="apiAdapter">IApiAdapter to manage HTTPS requests.</param>
        public ProtocolClient(IApiAdapter apiAdapter)
        {
            Guard.ArgumentsAreNotNull(apiAdapter);
            _api = apiAdapter;
        }

        /// <summary>
        /// Get array of all supported liquidity protocols.
        /// </summary>
        /// <returns>ProtocolList response.</returns>
        public async Task<ProtocolList> GetNameListings()
        {
            var response = await _api.SendRequest(Paths.API.ProtocolNames); 
            return JsonSerializer.Deserialize<ProtocolList>(response);
        }

        /// <summary>
        /// Get names and images of all supported protocols.
        /// </summary>
        /// <returns>Response with List of Protocols.</returns>
        public async Task<List<Protocol>> GetAll()
        {
            var response = await _api.SendRequest(Paths.API.Protocols); 
            return JsonSerializer.Deserialize<List<Protocol>>(response);
        }

    }
}