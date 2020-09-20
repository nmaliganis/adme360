using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using adme360.models.DTOs.Employees;
using adme360.models.DTOs.Users;
using adme360.presenter.Exceptions;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls.Base;
using Newtonsoft.Json;
using RestSharp;

namespace adme360.presenter.ServiceAgents.Impls
{
    public class EmployeesService : BaseService<EmployeeUiModel>, IEmployeesService
    {
        private static readonly string _serviceName = "EmployeesService";

        public EmployeesService() : base(_serviceName)
        {
        }

        public async Task<List<EmployeeUiModel>> GetAllActiveEmployeesAsync(string authorizationToken = null)
        {
            UriBuilder builder = CreateUriBuilder();
            builder.Query += "Filter=IsActive&SearchQuery=true";

            List<EmployeeUiModel> result = new List<EmployeeUiModel>();

            var client = new RestClient(builder.Uri.ToString());
            var request = new RestRequest(Method.GET);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"bearer {authorizationToken}");

            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<List<EmployeeUiModel>>(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                AccountErrorModel resultError = JsonConvert.DeserializeObject<AccountErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }

            return result;
        }

        public async Task<IList<EmployeeUiModel>> GetAllActiveEmployeesAsync(bool active)
        {
            UriBuilder builder = CreateUriBuilder();
            builder.Path += active.ToString();
            return await RequestProvider.GetAsync<IList<EmployeeUiModel>>(builder.ToString());
        }
    }
}