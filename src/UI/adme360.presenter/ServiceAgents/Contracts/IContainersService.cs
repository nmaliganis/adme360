using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Containers;
using dl.wm.presenter.ServiceAgents.Contracts.Base;

namespace dl.wm.presenter.ServiceAgents.Contracts
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