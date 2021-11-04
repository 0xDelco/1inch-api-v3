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
        /// <summary>
        /// Tests that no exception is thrown if the required dependencies are provided.
        /// </summary>
        [TestMethod]
        public void ArgumentsNotNull()
        {
            var mockFactory = new Mock<IApiAdapter>();
            IApiAdapter factory = mockFactory.Object;
            var api = new OneInchClient(factory);
        }

        /// <summary>
        /// Tests that an argument null exception is thrown if IApiAdapter is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentsNull_IApiAdapter()
        {
            var api = new OneInchClient(null);
        }

        /// <summary>
        /// Verifies underlying chain switch method has been called.
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
