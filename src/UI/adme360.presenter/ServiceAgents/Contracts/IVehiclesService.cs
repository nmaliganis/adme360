using System.Collections.Generic;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Vehicles;
using dl.wm.presenter.ServiceAgents.Contracts.Base;

namespace dl.wm.presenter.ServiceAgents.Contracts
{
    public interface IVehiclesService : IEntityService<VehicleUiModel>
    {
        Task<IList<VehicleUiModel>> GetAllActiveVehiclesAsync(bool active);
    }
}