

namespace OneInch.Api
{
    /// <summary>
    /// Model for information required to configure a blockchain request client.
    /// </summary>
    /// <remarks>This structure is used to deserialize JSON settings in a consumer config file.</remarks>
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