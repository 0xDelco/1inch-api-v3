using System.Threading.Tasks;

namespace OneInch.Http
{
    public class OneInchApiAdapter : IApiAdapter
    {
        readonly IHttpClientFactory _httpClient;
        IRequestPathBuilder _pathBuilder;

        const string CLIENT_API_LOOKUP_KEY = "OneInchApi";
        public OneInchClient(IHttpClientFactory httpClient)
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
    
