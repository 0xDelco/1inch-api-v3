
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OneInch.Web
{
    public class ApproveClient
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

        public async Task<ApproveCallDataResponseDto> GetApprovedCallData(ApproveCalldataRequest request)
        {
            var criteria = OneInchRequestBuilder.GetCriteria(request);
            var response = await _api.SendRequest(criteria); 
            return JsonSerializer.Deserialize<ApproveCallDataResponseDto>(response);
        }
    }
}