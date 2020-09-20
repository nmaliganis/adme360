using System.Threading.Tasks;

namespace dl.wm.presenter.ServiceAgents.BaseProvider
{
    public interface IRequestProvider
    {
        Task<TResult> DeleteAsync<TResult>(string url, string authorizationToken = null, string authorizationMethod = "Bearer");

        Task<TResult> GetAsync<TResult>(string uri, string authorizationToken = null, string authorizationMethod = "Bearer");

        Task<TResult> PostAsync<TResult>(string uri, TResult data, string authorizationToken = null, string authorizationMethod = "Bearer");

        Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data, string authorizationToken = null, string authorizationMethod = "Bearer");

        Task<TResult> PutAsync<TResult>(string uri, TResult data, string authorizationToken = null, string authorizationMethod = "Bearer");

        Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data, string authorizationToken = null, string authorizationMethod = "Bearer");
    }
}