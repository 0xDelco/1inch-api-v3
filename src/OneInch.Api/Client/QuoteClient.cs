using System.Threading.Tasks;
using System.Text.Json;

namespace OneInch.Api
{
    /// <summary> 
    /// Client that manages requests with the "Quote" service.
    /// </summary>
    /// <remarks>Get quote and call data for an aggregated swap.</remarks>  
    /// <see href="https://docs.1inch.io/api/quote-swap">Quotes documentation</see>  
    public class QuoteClient : IQuoteClient
    {
        IApiAdapter _api;

        /// <summary>
        /// Invokes instance of client with IApiAdapter.
        /// </summary>
        /// <param name="apiAdapter">IApiAdapter to manage HTTPS requests.</param>
        public QuoteClient(IApiAdapter apiAdapter)
        {       
            Guard.ArgumentsAreNotNull(apiAdapter);     
            _api = apiAdapter;
        }

        /// <summary>
        /// Get quote on prospective swap.
        /// </summary>
        /// <param name="request">QuoteRequest containing prospective swap parameters.</param>
        /// <returns>Quote response with current swap conditions.</returns>
        public async Task<Quote> GetQuote(QuoteRequest request)
        {
            var criteria = request.GetParameters();
            var response = await _api.SendRequest(criteria);
            return JsonSerializer.Deserialize<Quote>(response);
        }

    }
    
}
    