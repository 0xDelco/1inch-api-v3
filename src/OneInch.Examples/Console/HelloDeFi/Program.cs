using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using OneInch.Api;

namespace HelloDeFi
{
    class Program
    {
        static OneInchSettings _oneInchSettings = new();
        static IServiceProvider _provider;
        const string APP_SETTINGS_FILE = "appSettings.json";

        static async Task Main(string[] args)
        {
            using (IHost host = CreateHostBuilder(args).Build())
            {
                ConfigureServiceProvider();
                var protocolNamesResult = GetProtocolNames();
                System.Console.WriteLine("Lowest Gas: " + protocolNamesResult.Result.LOWEST_GAS[0].mainRouteParts);
                System.Console.WriteLine("Max Result: " + protocolNamesResult.Result.MAX_RESULT[0].complexityLevel);
                await host.RunAsync(); 
            }
        }
        
        public static Task<PresetList> GetProtocolNames()
        {
            return _provider.GetService<IOneInchClient>()
                            .SwitchBlockchain(BlockchainEnum.OPTIMISM)
                            .Default
                            .GetPresets();
        }

        static void ConfigureServiceProvider()
           {
             var collection = new ServiceCollection();
              AddChainClients(collection);
              AddApiServices(collection);
              _provider = collection.BuildServiceProvider();
        }

        static void AddApiServices(IServiceCollection collection)
        {
              collection.AddSingleton<IApiAdapter, OneInchApiAdapter>();
              collection.AddSingleton<IOneInchClient, OneInchClient>();
        }

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
                    api.BaseAddress = new Uri(_oneInchSettings.Polygon.GetAddress());
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
                    configuration.Sources.Clear();
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
                //.SetBasePath(environment.ContentRootPath + $"/src/{environment.ApplicationName}/")
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
