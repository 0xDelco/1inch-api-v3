using System.Threading.Tasks;

namespace OneInch.Web
{
    public interface IApiAdapter
    {
        Task<string> SendRequest(string path);        
    }
}