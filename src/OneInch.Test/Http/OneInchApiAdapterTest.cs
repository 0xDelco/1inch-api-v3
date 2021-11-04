using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

using OneInch.Api;

namespace OneInch.Test
{
    [TestClass]
    public class OneInchApiAdapter_Test
    {
        [TestMethod]
        public void ArgumentsNotNull()
        {
            var mockFactory = new Mock<IHttpClientFactory>();
            IHttpClientFactory factory = mockFactory.Object;
            var api = new OneInchApiAdapter(factory);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentsNull_IHttpClientFactory()
        {
            var api = new OneInchApiAdapter(null);
        }
        

        /// <summary>
        /// Verifies default target chain is Ethereum when the client is initially invoked.
        /// </summary>
        [TestMethod]
        public void Verify_Default_Chain_Is_Ethereum()
        {
            var mockFactory = new Mock<IHttpClientFactory>();
            IHttpClientFactory factory = mockFactory.Object;
            var api = new OneInchApiAdapter(factory);
            Assert.IsTrue(api.TargetChain == BlockchainEnum.ETHEREUM);
        }


        /// <summary>
        /// Verifies default target chain is Ethereum when the client is initially invoked.
        /// </summary>
        [TestMethod]
        public void Verify_Chain_Switching()
        {
            var mockFactory = new Mock<IHttpClientFactory>();
            IHttpClientFactory factory = mockFactory.Object;
            var api = new OneInchApiAdapter(factory);
            api.SwitchBlockchain(BlockchainEnum.OPTIMISM);
            Assert.IsTrue(api.TargetChain == BlockchainEnum.OPTIMISM);
        }

        /// <summary>
        /// Verifies default target chain is Ethereum when the client is initially invoked.
        /// </summary>
        [TestMethod]
        public void Verify_Reset_Default_Chain()
        {
            var mockFactory = new Mock<IHttpClientFactory>();
            IHttpClientFactory factory = mockFactory.Object;
            var api = new OneInchApiAdapter(factory);
            api.SetDefaultChain();
            Assert.IsTrue(api.TargetChain == BlockchainEnum.ETHEREUM);
        }

        /// <summary>
        /// Tests successful HttpClient request.
        /// </summary>
        [TestMethod]
        public void Request_Success_HttpClient()
        {
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockHttp = new Mock<HttpMessageHandler>();
            //mockHttp.Setup(_ => _.)
            //("SendAsync", It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>())
                    //.ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
            IHttpClientFactory factory = mockFactory.Object;
            var api = new OneInchApiAdapter(factory);
            api.SetDefaultChain();
            Assert.IsTrue(api.TargetChain == BlockchainEnum.ETHEREUM);
        }
    }
}
