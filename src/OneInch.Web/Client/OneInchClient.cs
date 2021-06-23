
namespace OneInch.Web.Client
{
    public class OneInchClient
    {
        IApiAdapter _api;
        ApproveClient _approveClient;
        DefaultClient _defaultClient;
        HealthCheckClient _healthCheckClient;
        ProtocolClient _protocolClient;
        QuoteClient _quoteClient;
        SwapClient _swapClient;
        TokenClient _tokenClient;
        public OneInchClient(IApiAdapter apiAdapter)
        {            
            _api = apiAdapter;
            _approveClient = new ApproveClient(_api);
            _defaultClient = new DefaultClient(_api);
            _protocolClient = new ProtocolClient(_api);
            _healthCheckClient = new HealthCheckClient(_api);
            _quoteClient = new QuoteClient(_api);
            _swapClient = new SwapClient(_api);
            _tokenClient = new TokenClient(_api);
        }   

        public ApproveClient Approve { get{return _approveClient;}}
        public DefaultClient Default { get {return _defaultClient;}}
        public HealthCheckClient HealthCheck { get {return _healthCheckClient;}}
        public ProtocolClient Protocol { get {return _protocolClient;}}
        public QuoteClient Quote {get{return _quoteClient;}}
        public SwapClient Swap {get{return _swapClient;}}
        public TokenClient Token {get{return _tokenClient;}}
    }
}