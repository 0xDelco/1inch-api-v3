
namespace OneInch.Web.Client
{
    public class ApproveClient
    {
        IApiAdapter _api;
        public ApproveService(IApiAdapter apiAdapter)
        {            
            _api = apiAdapter;
        }   

        public async Task<ApproveSpenderResponseDto> GetApprovedSpender(ApproveSpenderRequest request)
        {
            // TODO: This seems like it can be refactored into a generic process
            var criteria = OneInchPathBuilder.GetParameters(request);
            var response = await _api.SendRequest(criteria); 
            return JsonSerializer.Deserialize<ApproveSpenderResponseDto>(response);
        }

        public async Task<ApproveCallDataResponseDto> GetApprovedCallData(ApproveCalldataRequest request)
        {
            var criteria = OneInchPathBuilder.GetParameters(request);
            var response = await _api.SendRequest(criteria); 
            return JsonSerializer.Deserialize<ApproveCallDataResponseDto>(response);
        }
    }
}