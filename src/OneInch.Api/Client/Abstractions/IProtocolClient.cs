
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OneInch.Api
{
    public interface IProtocolClient
    {
        Task<ProtocolList>  GetNameListings();
        Task<List<Protocol>> GetAll();
    }
}