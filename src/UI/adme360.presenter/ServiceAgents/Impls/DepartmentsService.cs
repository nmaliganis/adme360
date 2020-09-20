using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Employees.Departments;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls.Base;

namespace dl.wm.presenter.ServiceAgents.Impls
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