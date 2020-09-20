using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using adme360.models.DTOs.Containers;
using adme360.presenter.ServiceAgents.Contracts.Base;

namespace adme360.presenter.ServiceAgents.Contracts
{
    public interface IContainersService : IEntityService<ContainerUiModel>
    {
        Task<List<ContainerPointUiModel>> GetAllActiveContainersPointsAsync(string authorizationToken = null);
        Task<IList<ContainerUiModel>> GetAllActiveContainersAsync(bool active);
        Task<ImageContainerDto> UploadImage(string imagePath, string imageFile);

        Task<List<ContainerUiModel>> GetAllActiveContainersWithoutDeviceAssignedAsync(bool active,
            string authorizationToken = null);
        Task<ContainerUiModel> CreateContainerAsync(ContainerUiModel changedContainer, string authorizationToken = null);
    }
}