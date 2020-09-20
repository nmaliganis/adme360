using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Firmwares;
using dl.wm.presenter.Exceptions;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls.Base;
using Newtonsoft.Json;
using RestSharp;

namespace dl.wm.presenter.ServiceAgents.Impls
{
    public class FirmwaresService : BaseService<FirmwareUiModel>, IFirmwaresService
    {
        private static readonly string _serviceName = "FirmwaresService";

        public FirmwaresService() : base(_serviceName)
        {
        }
        
        public async Task<IList<FirmwareUiModel>> GetAllActiveFirmwaresAsync(bool active)
        {
            UriBuilder builder = CreateUriBuilder();
            builder.Path += $"/{active.ToString()}" ;
            return await RequestProvider.GetAsync<IList<FirmwareUiModel>>(builder.ToString());
        }

        public async Task<FirmwareUiModel> CreateFirmwareAsync(FirmwareUiModel viewChangedFirmware, string authorizationToken = null)
        {
            UriBuilder builder = CreateUriBuilder();

            FirmwareUiModel result = new FirmwareUiModel();

            var client = new RestClient(builder.Uri.ToString());
            var request = new RestRequest("", Method.POST);

            request.AddJsonBody(new FirmwareForCreationUiModel()
            {

            });

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"bearer {authorizationToken}");

            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<FirmwareUiModel>(response.Content);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                FirmwareErrorModel resultError = JsonConvert.DeserializeObject<FirmwareErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                FirmwareErrorModel resultError = JsonConvert.DeserializeObject<FirmwareErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }

            return result;
        }
    }
}