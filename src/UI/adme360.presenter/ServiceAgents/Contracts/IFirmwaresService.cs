using System.Collections.Generic;
using System.Threading.Tasks;
using adme360.models.DTOs.Firmwares;
using adme360.presenter.ServiceAgents.Contracts.Base;

namespace adme360.presenter.ServiceAgents.Contracts
{
    public interface IFirmwaresService : IEntityService<FirmwareUiModel>
    {
        Task<IList<FirmwareUiModel>> GetAllActiveFirmwaresAsync(bool active);
        Task<FirmwareUiModel> CreateFirmwareAsync(FirmwareUiModel viewChangedFirmware, string authorizationToken = null);
    }
}