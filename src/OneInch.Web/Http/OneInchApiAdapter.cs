using System.Threading.Tasks;
using System.Net.Http;

namespace OneInch.Web
{
    public class OneInchApiAdapter : IApiAdapter
    {
        readonly IHttpClientFactory _httpClient;
        //IRequestBuilder _pathBuilder;

        const string CLIENT_API_LOOKUP_KEY = "OneInchApi";
        public OneInchApiAdapter(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;   
        }
        public async Task<string> SendRequest(string path)        
        { 
            // TODO: Change this from a dynamic string to config or default.
            var client = _httpClient.CreateClient(CLIENT_API_LOOKUP_KEY);

            var response = await client.GetAsync(client.BaseAddress + path); 
            return await response.Content.ReadAsStringAsync();              
        }      
    }
}    
    
