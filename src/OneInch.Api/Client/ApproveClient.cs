
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OneInch.Api
{
    public class ApproveClient : IApproveClient
    {
        IApiAdapter _api;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiAdapter"></param>
        public ApproveClient(IApiAdapter apiAdapter)
        {            
            _api = apiAdapter;
        }   

        public async Task<ApproveSpenderResponseDto> GetApprovedSpender()
        {
            var response = await _api.SendRequest(Paths.API.ApproveSpender); 
            return JsonSerializer.Deserialize<ApproveSpenderResponseDto>(response);
        }

        public async Task<ApproveCallDataResponseDto> GetApprovedCallData(IOneInchRequest request)
        {
            var criteria = request.GetParameters();
            var response = await _api.SendRequest(criteria); 
            return JsonSerializer.Deserialize<ApproveCallDataResponseDto>(response);
        }
    }
}