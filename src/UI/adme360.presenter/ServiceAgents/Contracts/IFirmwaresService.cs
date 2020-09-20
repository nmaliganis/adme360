using System.Collections.Generic;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Firmwares;
using dl.wm.presenter.ServiceAgents.Contracts.Base;

namespace dl.wm.presenter.ServiceAgents.Contracts
{
    public interface IFirmwaresService : IEntityService<FirmwareUiModel>
    {
        Task<IList<FirmwareUiModel>> GetAllActiveFirmwaresAsync(bool active);
        Task<FirmwareUiModel> CreateFirmwareAsync(FirmwareUiModel viewChangedFirmware, string authorizationToken = null);
    }
}