using System.Collections.Generic;
using System.Threading.Tasks;
using adme360.models.DTOs.Vehicles;
using adme360.presenter.ServiceAgents.Contracts.Base;

namespace adme360.presenter.ServiceAgents.Contracts
{
    public interface IVehiclesService : IEntityService<VehicleUiModel>
    {
        Task<IList<VehicleUiModel>> GetAllActiveVehiclesAsync(bool active);
    }
}