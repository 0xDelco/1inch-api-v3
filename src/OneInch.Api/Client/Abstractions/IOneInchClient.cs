
using System.Threading.Tasks;
using System;

namespace OneInch.Api
{
   public interface IOneInchClient
   {
        IOneInchClient SwitchBlockchain(BlockchainEnum blockchain);
        IApproveClient Approve { get;}
        DefaultClient Default { get ;}
        HealthCheckClient HealthCheck { get;}
        ProtocolClient Protocol { get;}
        QuoteClient Quote {get;}
        SwapClient Swap {get;}
        TokenClient Token {get;}
   }
}