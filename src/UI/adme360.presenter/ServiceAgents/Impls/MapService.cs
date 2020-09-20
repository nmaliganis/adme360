using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Dashboards;
using dl.wm.models.DTOs.Maps;
using dl.wm.models.DTOs.Users;

using dl.wm.presenter.Exceptions;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls.Base;
using Newtonsoft.Json;
using RestSharp;

namespace dl.wm.presenter.ServiceAgents.Impls
{
    public class MapService : BaseService<MapUiModel>, IMapService
    {
        private static readonly string _serviceName = "MapService";

        public MapService() : base(_serviceName)
        {

        }

        public async Task<string> GetAddressFromPoint(double lat, double lon, string authorizationToken = null)
        {
            UriBuilder builder = CreateUriBuilder();
            builder.Path += $"/address/{lat}/{lon}";

            string result = String.Empty;

            var client = new RestClient(builder.Uri.ToString());
            var request = new RestRequest(Method.GET);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"bearer {authorizationToken}");

            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<string>(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                AccountErrorModel resultError = JsonConvert.DeserializeObject<AccountErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }

            return result;
        }

        public async Task<List<MapUiModel>> GetGeofencePoints(string geofenceId, string authorizationToken = null)
        {
            //curl -X GET "http://localhost:6200/api/v1/Maps/geofence/52ddb6a7-396d-4193-8664-2b90b27bb19f" -H "accept: application/json"

            UriBuilder builder = CreateUriBuilder();
            //builder.Path += "geofence/52ddb6a7-396d-4193-8664-2b90b27bb19f";
            //builder.Path += "geofence/geofencemap-52ddb6a7-396d-4193-8664-2b90b27bb19f";
            //builder.Path += "geofenceMaps/52ddb6a7-396d-4193-8664-2b90b27bb190";   // Neo-Irakleio
            //builder.Path += "geofence/32ddb6a7-396d-4193-8664-2b90b27bb19f";   // Filothei
            //builder.Path += "geofence/42ddb6a7-396d-4193-8664-2b90b27bb19f";   // Menemeni


            // Menemeni Center 40.6562959, 22.9092506

            builder.Path += "/geofenceMaps/42ddb6a7-396d-4193-8664-2b90b27bb190";   // Menemeni

            List<MapUiModel> result = new List<MapUiModel>();

            var client = new RestClient(builder.Uri.ToString());
            var request = new RestRequest(Method.GET);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"bearer {authorizationToken}");

            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<List<MapUiModel>>(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                AccountErrorModel resultError = JsonConvert.DeserializeObject<AccountErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }

            return result;
        }

        public async Task<bool> UpdateGeofenceEntitiesAsync(List<MapUiModel> changedGeofence, string geofenceId, string authorizationToken = null)
        {
            //curl -X PUT "http://localhost:6200/api/v1/Maps/geofence/geofence-52ddb6a7-396d-4193-8664-2b90b27bb19f" -H "accept: application/json"

            geofenceId = "52ddb6a7-396d-4193-8664-2b90b27bb19f";

            UriBuilder builder = CreateUriBuilder();
            builder.Path += $"/geofence/geofencemap-1-{geofenceId}";

            bool result = false;

            var client = new RestClient(builder.Uri.ToString());
            var request = new RestRequest("", Method.PUT);
            
            request.AddJsonBody(new GeofenceForModification()
            {
                GeofenceMapPointForModification = changedGeofence
            });

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"bearer {authorizationToken}");

            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<bool>(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                AccountErrorModel resultError = JsonConvert.DeserializeObject<AccountErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }

            return result;
        }
    }
}
