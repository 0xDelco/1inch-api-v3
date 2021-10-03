using System.Threading.Tasks;
using System.Net.Http;
using System;

namespace OneInch.Api
{
    /// <summary>
    /// Adapter class to manage iteractions with the API via the provided Http Client.
    /// </summary>
    public class OneInchApiAdapter : IApiAdapter
    {
        readonly IHttpClientFactory _httpClient;

        BlockchainEnum _targetChain;

        public OneInchApiAdapter(IHttpClientFactory httpClient)
        {
            Guard.ArgumentsAreNotNull(httpClient);

            _httpClient = httpClient;   

            this.SetDefaultChain();
        }
        
        /// <summary>
        /// Sets default blockchain API the adapter should initialize with as the target.
        /// </summary>
        public void SetDefaultChain() => _targetChain = BlockchainEnum.ETHEREUM;
        
        /// <summary>
        /// Sets the target blockchain API the adapter will target.
        /// </summary>
        /// <param name="blockchain">BlockchainEnum value to set chain target.</param>
        public void SwitchBlockchain(BlockchainEnum blockchain) => _targetChain = blockchain;        
        
        /// <summary>
        /// Submits request to OneInch API. 
        /// </summary>
        /// <param name="path">Path to specified end point.</param>
        /// <returns>Raw request response as a JSON string.</returns>
        public async Task<string> SendRequest(string path)        
        { 
            var client = _httpClient.CreateClient(((int)_targetChain).ToString());
            var requestAddress = client.BaseAddress + path;
            
            Console.WriteLine("Outgoing Request: " + requestAddress);

            var response = await client.GetAsync(requestAddress); 
            return await response.Content.ReadAsStringAsync();              
        } 

        /// <summary>
        /// Target chain the client will build requests for.
        /// </summary>
        /// <value>Set BlockchainEnum value.</value>
        public BlockchainEnum TargetChain { get { return _targetChain; }}
    }
}    
    
