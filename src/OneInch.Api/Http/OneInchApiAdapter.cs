using System.Threading.Tasks;
using System.Net.Http;

namespace OneInch.Api
{
    public class OneInchApiAdapter : IApiAdapter
    {
        readonly IHttpClientFactory _httpClient;

        BlockchainEnum _targetChain;

        public OneInchApiAdapter(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;   

            this.SetDefaultChain();
        }
        
        /// <summary>
        /// 
        /// </summary>
        void SetDefaultChain() => _targetChain = BlockchainEnum.ETHEREUM;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blockchain"></param>
        public void SwitchBlockchain(BlockchainEnum blockchain) => _targetChain = blockchain;        
        
        public async Task<string> SendRequest(string path)        
        { 
            var client = _httpClient.CreateClient(((int)_targetChain).ToString());
            
            var response = await client.GetAsync(client.BaseAddress + path); 
            return await response.Content.ReadAsStringAsync();              
        }      
    }
}    
    
