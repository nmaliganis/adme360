using System.Threading.Tasks;

namespace magic.button.collector.api.Helpers.Contracts
{
  public interface IAwsIoTProcessor
  {
    Task<bool> OnDemandMessageAsync(string certPath, string message);
  }
}