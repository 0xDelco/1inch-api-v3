
using System.Threading.Tasks;

namespace OneInch.Api
{
    public interface ITokenClient
    {
        Task<TokenList> GetAll();
    }
}