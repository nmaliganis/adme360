 using System;
 using System.Net;
 using System.Threading.Tasks;
using dl.wm.models.DTOs.Users;
 using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls.Base;
using Newtonsoft.Json;
using RestSharp;

namespace dl.wm.presenter.ServiceAgents.Impls
{
    public class UserJwtService : BaseService<AuthUiModel>, IUserJwtService
    {
        private static readonly string _serviceName = "UserjwtService";

        public UserJwtService() : base(_serviceName)
        {

        }

        public async Task<AuthUiModel> PostJwtUserAsync(string login, string password)
        {
            UriBuilder builder = CreateUriBuilder();

            AuthUiModel result = new AuthUiModel();

            var client = new RestClient(builder.Uri.ToString());

            var request = new RestRequest("", Method.POST);
            request.AddJsonBody(new LoginUiModel(){ Login = login, Password = password });
            request.AddHeader("Content-Type", "application/json");

            var response = client.Execute(request);
            if(response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<AuthUiModel>(response.Content);
            }
            else if(response.StatusCode == HttpStatusCode.BadRequest)
            {
                //throw new BadRequestForUserJwtWasCatch(response.Content);
                result.Message = HttpStatusCode.BadRequest.ToString();
            }

            return result;
        }

        public Task<bool> PutUserExpireRefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<AuthUiModel> GetNewTokenByRefreshAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}