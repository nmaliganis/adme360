using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using dl.wm.presenter.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace dl.wm.presenter.ServiceAgents.BaseProvider
{
    public sealed class RequestProvider : IRequestProvider
    {
        private readonly JsonSerializerSettings _serializerSettings;

        private RequestProvider()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };

            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public static RequestProvider Provider { get; } = new RequestProvider();

        public async Task<TResult> DeleteAsync<TResult>(string url, string authorizationToken = null,
            string authorizationMethod = "Bearer")
        {
            HttpClient httpClient = CreateHttpClient();
            var response = await httpClient.DeleteAsync(url);

            TResult result = await HandleResponse<TResult>(response);
            return result;
        }

        public async Task<TResult> GetAsync<TResult>(string uri, string authorizationToken = null,
            string authorizationMethod = "Bearer")
        {
            HttpClient httpClient = CreateHttpClient();

            if(!String.IsNullOrEmpty(authorizationToken))
                httpClient.DefaultRequestHeaders.Add("Authorization", authorizationMethod + " " + authorizationToken);

            HttpResponseMessage response = await httpClient.GetAsync(uri);

            TResult result = await HandleResponse<TResult>(response);
            return result;
        }

        public Task<TResult> PostAsync<TResult>(string uri, TResult data, string authorizationToken = null,
            string authorizationMethod = "Bearer")
        {
            return PostAsync<TResult, TResult>(uri, data);
        }

        public async Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data,
            string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            var httpClient = CreateHttpClient();
            var serialized = await Task.Run(() => JsonConvert.SerializeObject(data, _serializerSettings));
            var response =
                await httpClient.PostAsync(uri, new StringContent(serialized, Encoding.UTF8, "application/json"));

            var result = await HandleResponse<TResult>(response);
            return result;
        }

        public Task<TResult> PutAsync<TResult>(string uri, TResult data, string authorizationToken = null,
            string authorizationMethod = "Bearer")
        {
            return PutAsync<TResult, TResult>(uri, data);
        }

        public async Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data,
            string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            var httpClient = CreateHttpClient();
            var serialized = await Task.Run(() => JsonConvert.SerializeObject(data, _serializerSettings));
            var response =
                await httpClient.PutAsync(uri, new StringContent(serialized, Encoding.UTF8, "application/json"));

            var result = await HandleResponse<TResult>(response);
            return result;
        }

        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        private async Task<TResult> TryParseResponseContent<TResult>(string content)
        {
            TResult parsedContent;
            try
            {
                parsedContent =
                    await Task.Run(() => JsonConvert.DeserializeObject<TResult>(content, _serializerSettings));
            }
            catch (Exception ex)
            {
                throw new ServiceParseException(content, ex.Message);
            }

            return parsedContent;
        }


        private async Task<TResult> HandleResponse<TResult>(HttpResponseMessage response)
        {
            var responseData = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Forbidden ||
                    response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new ServiceAuthenticationException(responseData);
                }

                TResult parsedContent;
                try
                {
                    parsedContent = await TryParseResponseContent<TResult>(responseData);
                }
                catch (ServiceParseException ex)
                {
                    throw new ServiceHttpRequestException<string>(response.StatusCode, responseData);
                }

                throw new ServiceHttpRequestException<TResult>(response.StatusCode, parsedContent);
            }

            return await TryParseResponseContent<TResult>(responseData);
        }
    }
}
