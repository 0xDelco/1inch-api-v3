using System.Threading.Tasks;
using System.Text.Json;

namespace OneInch.Api
{
    public class SwapClient : ISwapClient
    {
        IApiAdapter _api;
        public SwapClient(IApiAdapter apiAdapter)
        {            
            _api = apiAdapter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Swap> GetSwap(IOneInchRequest request)
        {
            var p = request.GetParameters();
            var response = await _api.SendRequest(p);
            return JsonSerializer.Deserialize<Swap>(response);
        }
    }
}