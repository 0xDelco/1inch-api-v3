using System.Threading.Tasks;
using System;

namespace OneInch.Api
{
    public interface IApiAdapter
    {
        Task<string> SendRequest(string path); 

        void SwitchBlockchain(BlockchainEnum blockchain);       
    }
}