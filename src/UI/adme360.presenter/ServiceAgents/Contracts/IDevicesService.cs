using System.Collections.Generic;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Devices;
using dl.wm.presenter.ServiceAgents.Contracts.Base;

namespace dl.wm.presenter.ServiceAgents.Contracts
{
    public interface IDevicesService : IEntityService<DeviceUiModel>
    {
        Task<List<DeviceUiModel>> GetAllActiveDevicesWithoutSimcardAssignedAsync(bool active, string authorizationToken = null);
    }
}