using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Users;
using dl.wm.models.DTOs.Users.Accounts;
using dl.wm.presenter.Exceptions;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls.Base;
using Newtonsoft.Json;
using RestSharp;

namespace dl.wm.presenter.ServiceAgents.Impls
{
    public class AccountsService : BaseService<UserUiModel>, IAccountsService
    {
        private static readonly string _serviceName = "AccountsService";

        public AccountsService() : base(_serviceName)
        {

        }

        public async Task<UserUiModel> CreateRegisterNewUserAccountAsync(AccountUiModel registerUser, string authorizationToken = null)
        {
            UriBuilder builder = CreateUriBuilder();
            builder.Path += "/register";

            UserUiModel result = new UserUiModel();

            var client = new RestClient(builder.Uri.ToString());
            var request = new RestRequest("", Method.POST);
            
            request.AddJsonBody(new UserForRegistrationUiModel()
            {
                Login = registerUser.Login, 
                Password = registerUser.UserPassword,
                Firstname = registerUser.Employee.Firstname,
                Lastname = registerUser.Employee.Lastname,
                Email = registerUser.Employee.Email,
                Gender = registerUser.Employee.GenderIndex,
                GenderValue = registerUser.Employee.GenderValue,
                Phone = registerUser.Employee.Phone,
                ExtPhone = registerUser.Employee.ExtPhone,
                Mobile = registerUser.Employee.Mobile,
                ExtMobile = registerUser.Employee.ExtMobile,
                Notes = registerUser.Employee.Notes,
                AddressStreetOne = registerUser.Employee.AddressStreetOne,
                AddressStreetTwo = registerUser.Employee.AddressStreetTwo,
                AddressPostCode = registerUser.Employee.AddressPostCode,
                AddressCity = registerUser.Employee.AddressCity,
                AddressRegion = registerUser.Employee.AddressRegion,
                UserRoleId = registerUser.UserRoleId,
                EmployeeRoleId = registerUser.Employee.EmployeeRoleId,
                DepartmentId = registerUser.Employee.DepartmentId,
            });
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"bearer {authorizationToken}");

            var response = client.Execute(request);
            if(response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<UserUiModel>(response.Content);
            }
            else if(response.StatusCode == HttpStatusCode.BadRequest)
            {
                AccountErrorModel resultError = JsonConvert.DeserializeObject<AccountErrorModel>(response.Content);
                throw new ServiceHttpRequestException<string>(response.StatusCode, resultError.errorMessage);
            }

            return result;
        }

        public Task<UserUiModel> UpdateRegisterExistingUserAccountAsync(AccountUiModel changedUser, string authorizationToken = null)
        {
            throw new NotImplementedException();
        }
    }
}
