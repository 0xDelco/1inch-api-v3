namespace OneInch.Api
{
    public interface IOneInchSettings
    {
        BlockchainSettings Ethereum {get;set;}
        BlockchainSettings BinanceSmartChain {get;set;}
        BlockchainSettings Polygon {get;set;}
        BlockchainSettings Optimism {get;set;}
    }
}