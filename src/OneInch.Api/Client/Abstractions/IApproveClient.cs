using System.Threading.Tasks;

namespace OneInch.Api
{
    public interface IApproveClient
    {
        Task<ApproveCallDataResponseDto> GetApprovedCallData(ApproveCalldataRequest request);
        Task<ApproveSpenderResponseDto> GetApprovedSpender();
    }
}