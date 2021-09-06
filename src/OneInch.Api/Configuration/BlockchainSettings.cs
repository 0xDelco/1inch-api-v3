

namespace OneInch.Api
{
    public class BlockchainSettings
    {
        public string ApiUrl {get;set;}

        public string ChainId {get;set;}

        public string GetAddress()
        {
            return this.ApiUrl + ChainId + "/";
        }
    }
}