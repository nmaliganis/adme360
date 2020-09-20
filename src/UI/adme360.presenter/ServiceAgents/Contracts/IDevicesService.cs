using System.Collections.Generic;
using System.Threading.Tasks;
using adme360.models.DTOs.Devices;
using adme360.presenter.ServiceAgents.Contracts.Base;

namespace adme360.presenter.ServiceAgents.Contracts
{
    public interface IDevicesService : IEntityService<DeviceUiModel>
    {
        Task<List<DeviceUiModel>> GetAllActiveDevicesWithoutSimcardAssignedAsync(bool active, string authorizationToken = null);
    }
}