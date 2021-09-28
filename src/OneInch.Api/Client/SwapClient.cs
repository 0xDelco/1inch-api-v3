using System.Threading.Tasks;
using System.Text.Json;

namespace OneInch.Api
{

    /// <summary> 
    /// Client that manages requests with the "Swap" service.
    /// </summary>
    /// <remarks>Gets call data needed swap scenarios.</remarks>    
    /// <see href="https://docs.1inch.io/api/quote-swap">Swaps documentation</see>  
    public class SwapClient : ISwapClient
    {
        IApiAdapter _api;
        public SwapClient(IApiAdapter apiAdapter)
        {            
            _api = apiAdapter;
        }

        /// <summary>
        /// Get call data needed for a swap.
        /// </summary>
        /// <param name="request">SwapRequest containing swap parameters.</param>
        /// <returns>Swap response with data to submit to the blockchain.</returns>
        public async Task<Swap> GetSwap(SwapRequest request)
        {
            var p = request.GetParameters();
            var response = await _api.SendRequest(p);
            return JsonSerializer.Deserialize<Swap>(response);
        }
    }
}