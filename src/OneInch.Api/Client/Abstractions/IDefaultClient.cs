
using System.Threading.Tasks;

namespace OneInch.Api
{
    public interface IDefaultClient
    {
        Task<PresetList> GetPresets();
    }
}