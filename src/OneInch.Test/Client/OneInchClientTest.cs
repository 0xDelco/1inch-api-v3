using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net.Http;
using System;

using OneInch.Api;

namespace OneInch.Test
{
    [TestClass]
    public class OneInchClientTest
    {
        [TestMethod]
        public void ArgumentsNotNull()
        {
            var mockFactory = new Mock<IApiAdapter>();
            IApiAdapter factory = mockFactory.Object;
            var api = new OneInchClient(factory);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentsNull_IApiAdapter()
        {
            var api = new OneInchClient(null);
        }

        /// <summary>
        /// Verifies default target chain is Ethereum when the client is initially invoked.
        /// </summary>
        [TestMethod]
        public void Verify_Chain_Switching()
        {
            var adapter = new Mock<IApiAdapter>();
            adapter.Setup(_ => _.TargetChain)
                   .Returns(BlockchainEnum.POLYGON);   
            IApiAdapter api = adapter.Object;

            var client  = new OneInchClient(api);
            client.SwitchBlockchain(BlockchainEnum.POLYGON);

            adapter.Verify(_ => _.SwitchBlockchain(BlockchainEnum.POLYGON), Times.AtLeastOnce());
            Assert.IsTrue(client.TargetChain == BlockchainEnum.POLYGON);
        }
    }
}
