using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using OneInch.Api;

namespace HelloDeFi
{
    /// <summary>
    /// Basic program to execute fundamental requests against the 1inch API.
    /// </summary>
    class Program
    {
        static OneInchSettings _oneInchSettings = new();
        static IServiceProvider _provider;
        static IOneInchClient _apiClient;
        const string APP_SETTINGS_FILE = "appSettings.json";

        // https://etherscan.io/token/0x6b175474e89094c44da98b954eedeac495271d0f
        const string DAI_TOKEN_ADDRESS = "0x6b175474e89094c44da98b954eedeac495271d0f";

        // https://etherscan.io/token/0xa0b86991c6218b36c1d19d4a2e9eb0ce3606eb48
        const string USDC_TOKEN_ADDRESS = "0xa0b86991c6218b36c1d19d4a2e9eb0ce3606eb48";

        static async Task Main(string[] args)
        {
            using (IHost host = CreateHostBuilder(args).Build())
            {
                ConfigureServiceProvider();
                
                _apiClient = _provider.GetService<IOneInchClient>();
                
                SwapDAIForUSDC();

                await host.RunAsync(); 
            }
        }
        
        /// <summary>
        /// Executes basic swap of DAI for USDC.
        /// </summary>
        static void SwapDAIForUSDC()
        {
            // Step 1
            var approval = ApproveDaiSpend().Result;
            
            // Step 2
            SignAndSendTransaction(approval.data);

            // Step 3
            var quote = GetQuote().Result;

            // Step 4
            var swap = GetSwap(quote).Result;
            
            // Step 5
            SignAndSendTransaction(swap.tx.data);
        }

        /// <summary>
        /// Signs transaction data with wallet and submits transaction to EVM blockchain to be mined.
        /// </summary>
        /// <param name="data">Transaction data string.</param>
        /// <remarks>NOTE: This is not active until a web3 client is implemented.</remarks>
        static void SignAndSendTransaction(string data)
        {
            // implement web3 client like Nethereum to submit transactions.
        }

        /// <summary>
        /// Gets data from API for swap of 1 DAI for 1 USDC.
        /// </summary>
        /// <returns>Swap response from API</returns>
        static async Task<Swap> GetSwap(Quote quote)
        {
            var request = new SwapRequest()
            {
                fromTokenAddress = quote.fromToken.address,
                toTokenAddress = quote.toToken.address,
                fromAddress = "0xc2d742B37970BD9987FeA0846c20c43bD4150b0d",
                amount =  100000000000000000,
                slippage = 1
            };
            
            return await _apiClient
                            .Swap
                            .GetSwap(request);
        }

        /// <summary>
        /// Gets quote data from API to swap 1 DAI for 1 USDC.
        /// </summary>
        /// <returns>Quote response from API</returns>
        static async Task<Quote> GetQuote()
        {
            var request = new QuoteRequest()
            {
                fromTokenAddress = DAI_TOKEN_ADDRESS,
                toTokenAddress = USDC_TOKEN_ADDRESS,
                amount = 100000000000000000
            };

            return await _apiClient
                            .Quote
                            .GetQuote(request);
        }

        static async Task<ApproveCallDataResponseDto> ApproveDaiSpend()
        {
            var spendRequest = new ApproveCalldataRequest();
            spendRequest.tokenAddress = DAI_TOKEN_ADDRESS;
            spendRequest.infinity = true;

             return await _apiClient
                            .Approve
                            .GetApprovedCallData(spendRequest);

        }

        /// <summary>
        /// Initializes service provider with configured service collection.
        /// </summary>
        static void ConfigureServiceProvider()
           {
             var collection = new ServiceCollection();
              AddChainClients(collection);
              AddApiServices(collection);
              _provider = collection.BuildServiceProvider();
        }

        /// <summary>
        /// Composes API dependencies and adds them to the service collection.
        /// </summary>
        /// <param name="collection">IServiceCollection instance to add dependencies to.</param>
        static void AddApiServices(IServiceCollection collection)
        {
              collection.AddSingleton<IApiAdapter, OneInchApiAdapter>();
              collection.AddSingleton<IOneInchClient, OneInchClient>();
        }

        /// <summary>
        /// Composes Http clients for all supported blockchains.
        /// </summary>
        /// <param name="collection">IServiceCollection instance to add dependencies to.</param>
        static void AddChainClients(IServiceCollection collection)
        {
              collection.AddHttpClient(_oneInchSettings.Ethereum.ChainId, api =>
               {
                  api.BaseAddress = new Uri(_oneInchSettings.Ethereum.GetAddress());
               });
               
               collection.AddHttpClient(_oneInchSettings.BinanceSmartChain.ChainId, api =>
               {
                  api.BaseAddress = new Uri(_oneInchSettings.BinanceSmartChain.GetAddress());
               });

               collection.AddHttpClient(_oneInchSettings.Polygon.ChainId, api =>
               {
                  api.BaseAddress = new Uri(_oneInchSettings.Polygon.GetAddress());
               });

                collection.AddHttpClient(_oneInchSettings.Optimism.ChainId, api =>
                {
                    api.BaseAddress = new Uri(_oneInchSettings.Optimism.GetAddress());
                });

                collection.AddHttpClient(_oneInchSettings.Arbitrum.ChainId, api =>
                {
                    api.BaseAddress = new Uri(_oneInchSettings.Arbitrum.GetAddress());
                });
        }

        /// <summary>
        /// Initiates <see cref="IHostBuilder"/> based on environment configurations.
        /// </summary>
        /// <param name="args">Application start up arguments.</param>
        /// <returns>Configured IHostBuilder.</returns>
        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    IHostEnvironment env = hostingContext.HostingEnvironment;
                    LoadConfiguration(env, configuration);
                    BindOneInchSettings(configuration.Build());
                });

        /// <summary>
        /// Loads configurable settings from host environment.
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="configuration"></param>
        static void LoadConfiguration(IHostEnvironment environment, IConfigurationBuilder configuration) =>
            configuration
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile(APP_SETTINGS_FILE, optional: false, reloadOnChange: true);
        
        /// <summary>
        /// Binds settings for API client from the configuration section
        /// </summary>
        /// <param name="root"></param>
        static void BindOneInchSettings(IConfigurationRoot root) =>
                root.GetSection(nameof(OneInchSettings))
                    .Bind(_oneInchSettings);
        
    }
}
