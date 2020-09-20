using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using adme360.models.DTOs.Employees.EmployeeRoles;
using adme360.models.DTOs.Trackables;
using adme360.presenter.Exceptions;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls.Base;
using adme360.suite.common.dtos.Vms.Trackables;
using Newtonsoft.Json;
using RestSharp;

namespace adme360.presenter.ServiceAgents.Impls
{
    public class TrackablesService : BaseService<TrackableUiModel>, ITrackablesService
    {
        private static readonly string _serviceName = "TrackablesService";

        public TrackablesService() : base(_serviceName)
        {

        }
        
        public async Task<IList<TrackableUiModel>> GetAllActiveTrackablesAsync(bool active)
        {
            UriBuilder builder = CreateUriBuilder();
            builder.Path += $"/{active.ToString()}" ;
            return await RequestProvider.GetAsync<IList<TrackableUiModel>>(builder.ToString());
        }

        public async Task<TrackableUiModel> CreateTrackableAsync(TrackableUiModel newTrackable, string authorizationToken = null)
        {
            UriBuilder builder = CreateUriBuilder();

            TrackableUiModel result = new TrackableUiModel();

            var client = new RestClient(builder.Uri.ToString());
            var request = new RestRequest("", Method.POST);

            request.AddJsonBody(new TrackableForCreationUiModel()
            {
                TrackableName = newTrackable.TrackableName,
                TrackableModel = newTrackable.TrackableModel,
                TrackableVendorId = newTrackable.TrackableVendorId,
                TrackableVersion = newTrackable.TrackableVersion,
                TrackableOs = newTrackable.TrackableOs,
                TrackablePhone = newTrackable.TrackablePhone,
                TrackableNotes = newTrackable.TrackableNotes,
            });

            return RestCallExecutor(authorizationToken, request, client, result);
        }

        public async Task<TrackableUiModel> UpdateTrackableAsync(TrackableUiModel newTrackable, string authorizationToken = null)
        {
            UriBuilder builder = CreateUriBuilder();

            TrackableUiModel result = new TrackableUiModel();

            var client = new RestClient(builder.Uri.ToString());
            var request = new RestRequest("", Method.PUT);

            request.AddJsonBody(new TrackableForModificationUiModel()
            {
                Id = newTrackable.Id,
                TrackableName = newTrackable.TrackableName,
                TrackableModel = newTrackable.TrackableModel,
                TrackableVendorId = newTrackable.TrackableVendorId,
                TrackableVersion = newTrackable.TrackableVersion,
                TrackableOs = newTrackable.TrackableOs,
                TrackablePhone = newTrackable.TrackablePhone,
                TrackableNotes = newTrackable.TrackableNotes,
            });

            return RestCallExecutor(authorizationToken, request, client, result);
        }

        private static TrackableUiModel RestCallExecutor(string authorizationToken, RestRequest request, RestClient client,
            TrackableUiModel result)
        {
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"bearer {authorizationToken}");

            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<TrackableUiModel>(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                TrackableErrorModel resultError =
                    JsonConvert.DeserializeObject<TrackableErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                TrackableErrorModel resultError =
                    JsonConvert.DeserializeObject<TrackableErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }

            return result;
        }
    }
}