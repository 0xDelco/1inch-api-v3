
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OneInch.Api
{
    /// <summary>
    /// Client that manages requests with the "Approve" service.
    /// </summary>
    /// <remarks>Get calldata for approve transaction and spender address.</remarks>
    /// <see href="https://docs.1inch.io/api/approve">Approve documentation</see>
    public class ApproveClient : IApproveClient
    {
        IApiAdapter _api;
        
        /// <summary>
        /// Invokes instance of client with IApiAdapter.
        /// </summary>
        /// <param name="apiAdapter">IApiAdapter to manage HTTPS requests.</param>
        public ApproveClient(IApiAdapter apiAdapter)
        {            
            _api = apiAdapter;
        }   

        /// <summary>
        /// Get the address to which you need to approve before the swap transaction.
        /// </summary>
        /// <returns></returns>
        public async Task<ApproveSpenderResponseDto> GetApprovedSpender()
        {
            var response = await _api.SendRequest(Paths.API.ApproveSpender); 
            return JsonSerializer.Deserialize<ApproveSpenderResponseDto>(response);
        }

        /// <summary>
        /// Get a calldata for an approve transaction.
        /// </summary>
        /// <remarks>This interaction is required first for any tokens you wish to swap through the protocol. Otherwise, the api
        /// will return an error when requesting a swap. Once spend is approved for a wallet you do not need to do this again.
        /// </remarks>
        /// <param name="request">ApproveCalldataRequest containing approval information.</param>
        /// <returns>ApproveCallDataResponseDto response.</returns>
        public async Task<ApproveCallDataResponseDto> GetApprovedCallData(ApproveCalldataRequest request)
        {
            var criteria = request.GetParameters();
            var response = await _api.SendRequest(criteria); 
            return JsonSerializer.Deserialize<ApproveCallDataResponseDto>(response);
        }
    }
}