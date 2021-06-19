using System.Threading.Tasks;

namespace OneInch.Http
{
    public interface IApiAdapter
    {
        Task<string> SendRequest();        
    }
}