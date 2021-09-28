

using System.Threading.Tasks;

namespace OneInch.Api
{
   public interface IQuoteClient
   {
       Task<Quote> GetQuote(QuoteRequest request);
   }
}