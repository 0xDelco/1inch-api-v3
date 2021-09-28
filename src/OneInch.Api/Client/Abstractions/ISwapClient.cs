
using System.Threading.Tasks;

namespace OneInch.Api
{
    public interface ISwapClient
    {
        Task<Swap> GetSwap(IOneInchRequest request);
    }
}