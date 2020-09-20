using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using adme360.models.DTOs.Employees.Departments;
using adme360.presenter.ServiceAgents.Contracts;
using adme360.presenter.ServiceAgents.Impls.Base;

namespace adme360.presenter.ServiceAgents.Impls
{
    public class DepartmentsService : BaseService<DepartmentUiModel>, IDepartmentsService
    {
        private static readonly string _serviceName = "DepartmentsService";

        public DepartmentsService() : base(_serviceName)
        {

        }
        
        public async Task<IList<DepartmentUiModel>> GetAllActiveDepartmentsAsync(bool active)
        {
            UriBuilder builder = CreateUriBuilder();
            builder.Path += $"/{active.ToString()}" ;
            return await RequestProvider.GetAsync<IList<DepartmentUiModel>>(builder.ToString());
        }

        public Task<DepartmentUiModel> CreateEmployeeDepartmentAsync(DepartmentUiModel viewChangedEmployeeDepartment, string tokenConfigValue)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentUiModel> UpdateEmployeeDepartmentAsync(DepartmentUiModel viewChangedEmployeeDepartment, string tokenConfigValue)
        {
            throw new NotImplementedException();
        }
    }
}