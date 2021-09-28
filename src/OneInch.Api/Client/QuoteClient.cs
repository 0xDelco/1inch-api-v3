using System.Threading.Tasks;
using System.Text.Json;

namespace OneInch.Api
{
public class QuoteClient : IQuoteClient
    {
        IApiAdapter _api;
        public QuoteClient(IApiAdapter apiAdapter)
        {            
            _api = apiAdapter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Quote> GetQuote(IOneInchRequest request)
        {
            var criteria = request.GetParameters();
            var response = await _api.SendRequest(criteria);
            return JsonSerializer.Deserialize<Quote>(response);
        }

    }
    
}
    