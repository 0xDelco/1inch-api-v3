
namespace OneInch.Api
{
    /// <summary>
    /// Client that manages consolidated instances of all supported clients.
    /// </summary>
    /// <remarks>While using the OneInchClient class is not required, it is the most convenient way to interface with the API.</remarks>
    public class OneInchClient : IOneInchClient
    {
        IApiAdapter _api;
        
        /// <summary>
        /// Invokes instance of client with IApiAdapter.
        /// </summary>
        /// <param name="apiAdapter">IApiAdapter to manage HTTPS requests.</param>
        public OneInchClient(IApiAdapter apiAdapter)
        {           
            Guard.ArgumentsAreNotNull(apiAdapter); 

            _api = apiAdapter;
            Approve = new ApproveClient(_api);
            Default = new DefaultClient(_api);
            Protocol = new ProtocolClient(_api);
            HealthCheck = new HealthCheckClient(_api);
            Quote = new QuoteClient(_api);
            Swap = new SwapClient(_api);
            Token = new TokenClient(_api);
        }  

        /// <summary>
        /// Sets the target blockchain API the adapter will target.
        /// </summary>
        /// <param name="blockchain">BlockchainEnum value to set chain target.</param>
        public IOneInchClient SwitchBlockchain(BlockchainEnum blockchain)
        { 
            _api.SwitchBlockchain(blockchain);
            return this;
        } 

        /// <summary>
        /// Target chain the client will build requests for.
        /// </summary>
        /// <value>Set BlockchainEnum value.</value>
        public BlockchainEnum TargetChain { get { return _api.TargetChain; }}

        /// <summary>
        /// Instance of IApproveClient that manages requests with the "Approve" service.
        /// </summary>
        public IApproveClient Approve { get;}

        /// <summary>
        /// Instance of IDefaultClient that manages requests with the "Default" service.
        /// </summary>
        public IDefaultClient Default { get ;}

        /// <summary>
        /// Instance of IHealthCheckClient that manages requests with the "Default" service.
        /// </summary>
        public IHealthCheckClient HealthCheck { get;}

        /// <summary>
        /// Instance of IProtocolClient that manages requests with the "Protocol" service.
        /// </summary>
        public IProtocolClient Protocol { get;}

        /// <summary>
        /// Instance of IQuoteClient that manages requests with the "Quote" service.
        /// </summary>
        public IQuoteClient Quote {get;}

        /// <summary>
        /// Instance of ISwapClient that manages requests with the "Swap" service.
        /// </summary>
        public ISwapClient Swap {get;}

        /// <summary>
        /// Instance of ITokenClient that manages requests with the "Token" service.
        /// </summary>
        public ITokenClient Token {get;}
    }
}