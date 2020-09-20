using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using adme360.models.DTOs.Tours;
using adme360.presenter.Exceptions;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls.Base;
using Newtonsoft.Json;
using RestSharp;

namespace adme360.presenter.ServiceAgents.Impls
{
    public class ToursService : BaseService<TourUiModel>, IToursService
    {
        private static readonly string _serviceName = "ToursService";

        public ToursService() : base(_serviceName)
        {

        }
        
        public async Task<IList<TourUiModel>> GetAllActiveToursAsync(bool active)
        {
            UriBuilder builder = CreateUriBuilder();
            builder.Path += $"/{active.ToString()}" ;
            return await RequestProvider.GetAsync<IList<TourUiModel>>(builder.ToString());
        }

        public async Task<TourUiModel> CreateTourAsync(TourUiModel newTour, string authorizationToken = null)
        {
            UriBuilder builder = CreateUriBuilder();

            TourUiModel result = new TourUiModel();

            var client = new RestClient(builder.Uri.ToString());
            var request = new RestRequest("", Method.POST);

            request.AddJsonBody(new TourForCreationUiModel()
            {
                TourName = newTour.TourName,
            });

            return RestCallExecutor(authorizationToken, request, client, result);
        }

        public async Task<TourUiModel> UpdateTourAsync(TourUiModel newTour, string authorizationToken = null)
        {
            UriBuilder builder = CreateUriBuilder();

            TourUiModel result = new TourUiModel();

            var client = new RestClient(builder.Uri.ToString());
            var request = new RestRequest("", Method.PUT);

            request.AddJsonBody(new TourForModificationUiModel()
            {
                Id = newTour.Id,
            });

            return RestCallExecutor(authorizationToken, request, client, result);
        }

        private static TourUiModel RestCallExecutor(string authorizationToken, RestRequest request, RestClient client,
            TourUiModel result)
        {
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"bearer {authorizationToken}");

            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<TourUiModel>(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                TourErrorModel resultError =
                    JsonConvert.DeserializeObject<TourErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                TourErrorModel resultError =
                    JsonConvert.DeserializeObject<TourErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }

            return result;
        }
    }
}