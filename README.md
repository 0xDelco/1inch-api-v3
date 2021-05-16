# 1inch .NET API Client (v3)

A .NET client library targeting **v3** of the [1inch](https://app.1inch.io) defi aggregator [API](https://docs.1inch.io/api/). The intention is to provide a simple wrapper to consume/model each of the available REST end points. 

Each of the objects in the domain are meant to provide the inbound and outbound structures needed to interact with the API in an unopinionated way. 

# Supported Frameworks

* [.NET 5.0.0](https://dotnet.microsoft.com/download/dotnet/5.0) (or greater)

# Getting Started

1inch .NET API is [available on NuGet](https://www.nuget.org/packages/<tbd>/):

```
dotnet add package OneInchApi
```
# Usage Examples

Each service requires an underlying [HttpClient](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-5.0) dependency. This can be invoked manually or using your preferred DI container library.

```c#
var client = new OneInchClient(new HttpClient());
```
*NOTE: A container set up example is included in the OneInch.Console*


Simple health check:
```c#
var healthService = new HealthCheckService(client);
var status = await healthService.GetStatus();
Console.WriteLine("API Status is: " + status.status)

// API Status is: OK
```

Requesting all support token information:
```c#
var tokenService = new TokenService(client);
var tokenList = await tokenService.GetAll();

foreach(var token in tokenList.tokens)
{
    Console.WriteLine("Token Symbol: " + token.symbol);
}
// Token Symbol: STX
// Token Symbol: BTC++
// Token Symbol: LID
// Token Symbol: UMA
// ... etc.
```

# Available Services

* [Approve Service](/src/OneInch.Domain/Services/ApproveService.cs) - https://docs.1inch.io/api/approve
* [HealthCheck Service](/src/OneInch.Domain/Services/HealthCheckService.cs) - https://docs.1inch.io/api/healthcheck
* [Quote Service](/src/OneInch.Domain/Services/QuoteService.cs) - https://docs.1inch.io/api/quote-swap
* [Swap Service](/src/OneInch.Domain/Services/SwapService.cs) - https://docs.1inch.io/api/quote-swap
* [Protocols Service](/src/OneInch.Domain/Services/ProtocolsService.cs) - https://api.1inch.exchange/v3.0/1/protocols
* [Token Service](/src/OneInch.Domain/Services/TokenService.cs) - https://docs.1inch.io/api/tokens 



