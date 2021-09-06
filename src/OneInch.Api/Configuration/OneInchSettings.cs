
namespace OneInch.Api
{
    public interface IOneInchSettings
    {
        BlockchainSettings Ethereum {get;set;}
        BlockchainSettings BinanceSmartChain {get;set;}
        BlockchainSettings Polygon {get;set;}
        BlockchainSettings Optimism {get;set;}

    }

    public class OneInchSettings : IOneInchSettings
    {
        public BlockchainSettings Ethereum {get;set;}

        public BlockchainSettings BinanceSmartChain{get;set;}

        public BlockchainSettings Polygon {get;set;}

        public BlockchainSettings Optimism {get;set;}

    }

}