using System.Threading.Tasks;

namespace OneInch.Api
{
    public interface IApproveClient
    {
        Task<ApproveCallDataResponseDto> GetApprovedCallData(IOneInchRequest request);
        Task<ApproveSpenderResponseDto> GetApprovedSpender();
    }
}