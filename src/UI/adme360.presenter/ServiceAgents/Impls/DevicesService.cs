using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using adme360.models.DTOs.Devices;
using adme360.presenter.Exceptions;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls.Base;
using Newtonsoft.Json;
using RestSharp;

namespace adme360.presenter.ServiceAgents.Impls
{
    public class DevicesService : BaseService<DeviceUiModel>, IDevicesService
    {
        private static readonly string _serviceName = "DevicesService";

        public DevicesService() : base(_serviceName)
        {
        }

        //curl -X GET "http://localhost:6200/api/v1/Devices?Filter=Simcard&SearchQuery=false" -H "accept: application/json"
        public async Task<List<DeviceUiModel>> GetAllActiveDevicesWithoutSimcardAssignedAsync(bool active, string authorizationToken = null)
        {
            UriBuilder builder = CreateUriBuilder();
            builder.Query += "Filter=Simcard&SearchQuery=false";

            List<DeviceUiModel> result = new List<DeviceUiModel>();

            var client = new RestClient(builder.Uri.ToString());
            var request = new RestRequest(Method.GET);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"bearer {authorizationToken}");

            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<List<DeviceUiModel>>(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                DeviceErrorModel resultError = JsonConvert.DeserializeObject<DeviceErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }

            return result;
        }
    }
}