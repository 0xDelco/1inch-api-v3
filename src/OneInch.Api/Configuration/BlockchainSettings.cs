

namespace OneInch.Api
{
    /// <summary>
    /// Model for information required to configure a blockchain request client.
    /// </summary>
    /// <remarks>This structure is used to deserialize JSON settings in a consumer config file.</remarks>
    public class BlockchainSettings
    {
        /// <summary>
        /// Base address for the API.
        /// </summary>
        public string ApiUrl {get;set;}

        /// <summary>
        /// Chain identifying value. 
        /// </summary>
        /// <remarks>For smooth lookups, this should match a BlockchainEnum value.</remarks>
        public string ChainId {get;set;}

        /// <summary>
        /// Aggregates blockchain address settings into a formatted URL.
        /// </summary>
        /// <returns>Formatted address string</returns>
        public string GetAddress()
        {
            return this.ApiUrl + ChainId + "/";
        }
    }
}