# **1inch .NET API Client (v3)**

A .NET client library targeting **v3** of the [1inch](https://app.1inch.io) DeFi aggregator [API](https://docs.1inch.io/api/). The intention is to provide a simple wrapper to consume and model each of the available REST end points.

Each of the objects in the domain are meant to provide the inbound and outbound structures needed to interact with the API in a straight forward and object oriented way.

**NOTE:** This project has no affiliation with the 1inch team or protocol and is simply meant as an effort for the .NET community.

## Supported Blockchains

- ✅ Ethereum
- ✅ Binance Smart Chain
- ✅ Polygon
- ✅ Optimism


## Getting Started

The 1inch .NET API is [available on NuGet](https://www.nuget.org/packages/OneInch.Api/):

```

dotnet add package OneInch.Api

```

## Quick Examples

Initial client setup:

```c#

// httpClient as some instance of HttpClient (DI container, self invoked, etc.)
using(var api = new OneInchClient(httpClient))
{
    // ...
}

```

Simple health check:

```c#
var status = await api.HealthCheck.GetStatus();

Console.WriteLine("API Status is: " + status.status)

// API Status is: OK

```

Requesting all supported token information:

```c#
var tokenList = await api.Token.GetAll();

foreach(var token in tokenList.tokens)
{

    Console.WriteLine("Token Symbol: " + token.symbol);

}

// Token Symbol: SNX

// Token Symbol: ETH

// Token Symbol: ZRX

// Token Symbol: MATIC

// ... etc.



```
Chain switching (Ethereum is default target):

```c#
var tokenList = await api
                        .SwitchBlockchain(BlockchainEnum.POLYGON) // switch to Polygon 
                        .Token
                        .GetAll();
```

Request quote -> 1 DAI for 1 USDC:

```c#

// https://etherscan.io/token/0x6b175474e89094c44da98b954eedeac495271d0f
const string DAI_TOKEN_ADDRESS = "0x6b175474e89094c44da98b954eedeac495271d0f";

// https://etherscan.io/token/0xa0b86991c6218b36c1d19d4a2e9eb0ce3606eb48
const string USDC_TOKEN_ADDRESS = "0xa0b86991c6218b36c1d19d4a2e9eb0ce3606eb48";

var request = new QuoteRequest()
{
    fromTokenAddress = DAI_TOKEN_ADDRESS,
    toTokenAddress = USDC_TOKEN_ADDRESS,
    amount = 100000000000000000 // 1 DAI
};

await api
        .Quote
        .GetQuote(request);

```

Request swap:

```c#

var request = new SwapRequest()
{
    fromTokenAddress = DAI_TOKEN_ADDRESS,
    toTokenAddress = USDC_TOKEN_ADDRESS,
    fromAddress = "<wallet_address>",
    amount =  100000000000000000, 
    slippage = 1
};

return await api
              .Swap
              .GetSwap(request);

```


## Supported Frameworks

- [.NET 5.0.0](https://dotnet.microsoft.com/download/dotnet/5.0) (or greater)

## Available Clients

You can find all of the official Swagger documentation for the various chain clients [here](https://docs.1inch.io/api/).

- [Approve Client](/src/OneInch.Api/Client/ApproveClient.cs) 
  - https://docs.1inch.io/api/approve
- [HealthCheck Client](/src/OneInch.Api/Client/HealthCheckClient.cs) 
  - https://docs.1inch.io/api/healthcheck
- [Quote Client](/src/OneInch.Api/Client/QuoteClient.cs) 
  - https://docs.1inch.io/api/quote-swap
- [Swap Client](/src/OneInch.Api/Client/SwapClient.cs) 
  - https://docs.1inch.io/api/quote-swap
- [Protocols Client](/src/OneInch.Api/Client/ProtocolsClient.cs) 
  - https://api.1inch.exchange/v3.0/1/protocols
- [Token Client](/src/OneInch.Api/Client/TokenClient.cs) 
  - https://docs.1inch.io/api/tokens
- [Default Client](/src/OneInch.Api/Client/DefaultClient.cs) 

## Road Map

- [ ] Unit Test Coverage
- [ ] Swapping logic flow diagrams 
- [ ] Advanced API usage examples
- [ ] Examples to sign and send swap transactions via [Nethereum]([https://nethereum.com/](https://nethereum.com/)).


