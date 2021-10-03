
using System.Threading.Tasks;
using System.Text.Json;

namespace OneInch.Api
{
    /// <summary> 
    /// Client that manages requests with the "Token" service.
    /// </summary>
    /// <remarks>Gets data for supported tokens.</remarks>    
    /// <see href="https://docs.1inch.io/api/tokens">Token documentation</see>  
    public class TokenClient : ITokenClient
    {
        IApiAdapter _api;
        public TokenClient(IApiAdapter apiAdapter)
        {          
            Guard.ArgumentsAreNotNull(apiAdapter);
              
            _api = apiAdapter;
        }

        /// <summary>
        /// Get array of all supported tokens (any erc20 token can be used in a quote and swap).
        /// </summary>
        /// <returns>TokenList response containing token data.</returns>
        public async Task<TokenList> GetAll()
        {
            var response = await _api.SendRequest(Paths.API.Tokens); 
            return JsonSerializer.Deserialize<TokenList>(response);
        }
    }

}