using System.Threading.Tasks;
using System.Text.Json;

namespace OneInch.Api
{
public class QuoteClient 
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
            var validator = new QuoteRequestValidator();
            //validator.ValidateAndThrow(request);
            var criteria = request.GetParameters();
            var response = await _api.SendRequest(criteria);
            return JsonSerializer.Deserialize<Quote>(response);
        }

    }
    
}
    