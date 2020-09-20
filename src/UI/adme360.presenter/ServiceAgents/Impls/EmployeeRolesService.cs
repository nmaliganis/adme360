using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using adme360.models.DTOs.Employees.EmployeeRoles;
using adme360.presenter.Exceptions;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls.Base;
using Newtonsoft.Json;
using RestSharp;

namespace adme360.presenter.ServiceAgents.Impls
{
    public class EmployeeRolesService : BaseService<EmployeeRoleUiModel>, IEmployeeRolesService
    {
        private static readonly string _serviceName = "EmployeeRolesService";

        public EmployeeRolesService() : base(_serviceName)
        {
        }

        public async Task<IList<EmployeeRoleUiModel>> GetAllActiveEmployeeRolesAsync(bool active)
        {
            UriBuilder builder = CreateUriBuilder();
            builder.Path += $"/{active.ToString()}";
            return await RequestProvider.GetAsync<IList<EmployeeRoleUiModel>>(builder.ToString());
        }

        public async Task<EmployeeRoleUiModel> CreateEmployeeRoleAsync(EmployeeRoleUiModel newEmployeeRole,
            string authorizationToken = null)
        {
            UriBuilder builder = CreateUriBuilder();

            EmployeeRoleUiModel result = new EmployeeRoleUiModel();

            var client = new RestClient(builder.Uri.ToString());
            var request = new RestRequest("", Method.POST);

            request.AddJsonBody(new EmployeeRoleForCreationUiModel()
            {
                EmployeeRoleName = newEmployeeRole.Name,
                EmployeeRoleNotes = $"{newEmployeeRole.Notes}",
                EmployeeRoleType = (int)EmployeeRoleType.Other
            });

            return RestCallExecutor(authorizationToken, request, client, result);
        }

        public async Task<EmployeeRoleUiModel> UpdateEmployeeRoleAsync(EmployeeRoleUiModel changedEmployeeRole, string authorizationToken = null)
        {
            UriBuilder builder = CreateUriBuilder();
            builder.Path += $"/{changedEmployeeRole.Id}";

            EmployeeRoleUiModel result = new EmployeeRoleUiModel();

            var client = new RestClient(builder.Uri.ToString());
            var request = new RestRequest("", Method.PUT);

            request.AddJsonBody(new EmployeeRoleForModificationUiModel()
            {
                Id = changedEmployeeRole.Id,
                EmployeeRoleName = changedEmployeeRole.Name,
                EmployeeRoleNotes = changedEmployeeRole.Notes,
                EmployeeRoleType = (int)EmployeeRoleType.Other,
            });

            return RestCallExecutor(authorizationToken, request, client, result);
        }

        private static EmployeeRoleUiModel RestCallExecutor(string authorizationToken, RestRequest request, RestClient client,
            EmployeeRoleUiModel result)
        {
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"bearer {authorizationToken}");

            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<EmployeeRoleUiModel>(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                EmployeeRoleErrorModel resultError =
                    JsonConvert.DeserializeObject<EmployeeRoleErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                EmployeeRoleErrorModel resultError =
                    JsonConvert.DeserializeObject<EmployeeRoleErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }

            return result;
        }
    }
}