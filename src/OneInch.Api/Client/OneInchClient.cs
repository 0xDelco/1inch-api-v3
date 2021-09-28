
namespace OneInch.Api
{
    public class OneInchClient : IOneInchClient
    {
        IApiAdapter _api;
        
        public OneInchClient(IApiAdapter apiAdapter)
        {            
            _api = apiAdapter;
            Approve = new ApproveClient(_api);
            Default = new DefaultClient(_api);
            Protocol = new ProtocolClient(_api);
            HealthCheck = new HealthCheckClient(_api);
            Quote = new QuoteClient(_api);
            Swap = new SwapClient(_api);
            Token = new TokenClient(_api);
        }  

        public IOneInchClient SwitchBlockchain(BlockchainEnum blockchain)
        { 
            _api.SwitchBlockchain(blockchain);
            return this;
        } 


        public IApproveClient Approve { get;}
        public DefaultClient Default { get ;}
        public HealthCheckClient HealthCheck { get;}
        public ProtocolClient Protocol { get;}
        public QuoteClient Quote {get;}
        public SwapClient Swap {get;}
        public TokenClient Token {get;}

    }
}