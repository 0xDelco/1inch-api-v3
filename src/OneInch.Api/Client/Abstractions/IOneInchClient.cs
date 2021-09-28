
using System.Threading.Tasks;
using System;

namespace OneInch.Api
{
   public interface IOneInchClient
   {
        IOneInchClient SwitchBlockchain(BlockchainEnum blockchain);
        IApproveClient Approve { get;}
        IDefaultClient Default { get ;}
        IHealthCheckClient HealthCheck { get;}
        IProtocolClient Protocol { get;}
        IQuoteClient Quote {get;}
        ISwapClient Swap {get;}
        ITokenClient Token {get;}
   }
}