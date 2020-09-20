using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using adme360.models.DTOs.Base;
using adme360.presenter.ServiceAgents.Base;

namespace adme360.presenter.ServiceAgents.Contracts.Base
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