using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Simcards;
using dl.wm.presenter.Exceptions;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls.Base;
using Newtonsoft.Json;
using RestSharp;

namespace dl.wm.presenter.ServiceAgents.Impls
{
    public class SimcardsService : BaseService<SimcardUiModel>, ISimcardsService
    {
        private static readonly string _serviceName = "SimcardsService";

        public SimcardsService() : base(_serviceName)
        {

        }
        
        public async Task<IList<SimcardUiModel>> GetAllActiveSimcardsAsync(bool active)
        {
            UriBuilder builder = CreateUriBuilder();
            builder.Path += $"/{active.ToString()}" ;
            return await RequestProvider.GetAsync<IList<SimcardUiModel>>(builder.ToString());
        }

        public async Task<SimcardUiModel> CreateSimcardAsync(SimcardUiModel viewChangedSimcard, string authorizationToken = null)
        {
            UriBuilder builder = CreateUriBuilder();

            SimcardUiModel result = new SimcardUiModel();

            var client = new RestClient(builder.Uri.ToString());
            var request = new RestRequest("", Method.POST);

            request.AddJsonBody(new SimcardForCreationUiModel()
            {
                SimcardIccid = viewChangedSimcard.SimcardIccid,
                SimcardImsi = viewChangedSimcard.SimcardImsi,
                SimcardCountryIso = viewChangedSimcard.SimcardCountryIso,
                SimcardNumber = viewChangedSimcard.SimcardNumber,
                SimcardPurchaseDate = viewChangedSimcard.SimcardPurchaseDate,
                SimcardCardType = viewChangedSimcard.SimcardCardType,
                SimcardNetworkType = viewChangedSimcard.SimcardNetworkType,
                SimcardIsEnabled = viewChangedSimcard.SimcardIsEnabled,
                SimcardDeviceId = viewChangedSimcard.SimcardDevice.Id,
            });

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"bearer {authorizationToken}");

            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<SimcardUiModel>(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                SimcardErrorModel resultError = JsonConvert.DeserializeObject<SimcardErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                SimcardErrorModel resultError = JsonConvert.DeserializeObject<SimcardErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }

            return result;
        }
    }
}