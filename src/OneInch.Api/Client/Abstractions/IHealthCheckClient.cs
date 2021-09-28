

using System.Threading.Tasks;

namespace OneInch.Api
{
   public interface IHealthCheckClient
   {
       Task<HealthCheck> GetStatus();
   }
}