using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Vehicles;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls.Base;

namespace dl.wm.presenter.ServiceAgents.Impls
{
    public class VehiclesService : BaseService<VehicleUiModel>, IVehiclesService
    {
        private static readonly string _serviceName = "VehiclesService";

        public VehiclesService() : base(_serviceName)
        {

        }
        
        public async Task<IList<VehicleUiModel>> GetAllActiveVehiclesAsync(bool active)
        {
            UriBuilder builder = CreateUriBuilder();
            builder.Path += $"/{active.ToString()}" ;
            return await RequestProvider.GetAsync<IList<VehicleUiModel>>(builder.ToString());
        }
    }
}