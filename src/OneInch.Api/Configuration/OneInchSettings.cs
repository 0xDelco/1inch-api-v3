
namespace OneInch.Api
{
    /// <summary>
    /// Model for OneInch API configuration settings.
    /// </summary>
    public class OneInchSettings : IOneInchSettings
    {
        public BlockchainSettings Ethereum {get;set;}

        public BlockchainSettings BinanceSmartChain{get;set;}

        public BlockchainSettings Polygon {get;set;}

        public BlockchainSettings Optimism {get;set;}
    }

}