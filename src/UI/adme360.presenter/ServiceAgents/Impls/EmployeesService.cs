using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Employees;
using dl.wm.models.DTOs.Users;
using dl.wm.presenter.Exceptions;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls.Base;
using Newtonsoft.Json;
using RestSharp;

namespace dl.wm.presenter.ServiceAgents.Impls
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