using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net.Http;
using System;

using OneInch.Api;

namespace OneInch.Test
{
    [TestClass]
    public class BlockchainSettingsTest
    {
        /// <summary>
        /// Verify the GetAddress method concatenates the address as expected from the specified settings.
        /// </summary>
        [TestMethod]
        public void Verify_GetAddress()
        {
            var apiUrl = "https://api.1inch.exchange/v3.0/";
            var chainId = "1";
            var settings = new BlockchainSettings()
            {
                ApiUrl = apiUrl,
                ChainId = chainId
            };

            Assert.IsTrue(apiUrl+ chainId + "/" == settings.GetAddress());
        }
    }
}