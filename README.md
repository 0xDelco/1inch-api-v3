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

1inch .NET API is [available on NuGet](https://www.nuget.org/packages/<tbd>/):

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

Request Token swap quote:

```c#

var tokenList = await tokenClient.GetAll();

```

## Supported Frameworks

- [.NET 5.0.0](https://dotnet.microsoft.com/download/dotnet/5.0) (or greater)

## Available Clients

- [Approve Client](/src/OneInch.Domain/Services/ApproveService.cs) 
  - https://docs.1inch.io/api/approve
- [HealthCheck Client](/src/OneInch.Domain/Services/HealthCheckService.cs) 
  - https://docs.1inch.io/api/healthcheck
- [Quote Client](/src/OneInch.Domain/Services/QuoteService.cs) 
  - https://docs.1inch.io/api/quote-swap
- [Swap Client](/src/OneInch.Domain/Services/SwapService.cs) 
  - https://docs.1inch.io/api/quote-swap
- [Protocols Client](/src/OneInch.Domain/Services/ProtocolsService.cs) 
  - https://api.1inch.exchange/v3.0/1/protocols
- [Token Client](/src/OneInch.Domain/Services/TokenService.cs) 
  - https://docs.1inch.io/api/tokens

## Road Map

- [ ] Unit Test Coverage
- [ ] Swapping logic flow diagrams 
- [ ] Advanced API usage examples
- [ ] Examples to sign and send swap transactions via [Nethereum]([https://nethereum.com/](https://nethereum.com/)).


