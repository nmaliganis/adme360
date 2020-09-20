using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Base;
using dl.wm.presenter.ServiceAgents.Base;

namespace dl.wm.presenter.ServiceAgents.Contracts.Base
{
    public interface IEntityService<TEntity> : IService where TEntity : IUiModel
    {
        Task<TEntity> GetEntityByIdAsync(Guid entityId, string authorizationToken = null);

        Task<List<TEntity>> GetEntitiesAsync(string authorizationToken = null);
        Task<TEntity> CreateEntityAsync(TEntity newEntity, string authorizationToken = null);
        Task<TEntity> UpdateEntityAsync(TEntity updatedEntity, string authorizationToken = null);
        Task<TEntity> RemoveEntityAsync(Guid entityId, string authorizationToken = null);
    }
}