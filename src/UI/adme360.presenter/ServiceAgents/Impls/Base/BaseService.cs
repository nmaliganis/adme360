using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Base;
using dl.wm.presenter.Exceptions;
using dl.wm.presenter.ServiceAgents.BaseProvider;
using dl.wm.presenter.ServiceAgents.Contracts.Base;
using dl.wm.presenter.UriBuilders;

namespace dl.wm.presenter.ServiceAgents.Impls.Base
{
  public class BaseService<TEntity> : IEntityService<TEntity> where TEntity : IUiModel
  {
    protected readonly IRequestProvider RequestProvider;
    protected readonly string ServiceName;

    protected UriBuilder CreateUriBuilder()
    {
      return new UriBuilder(ClientUriAddressesRepository.UriAddressesRepository[ServiceName]);
    }

    public BaseService(string serviceName)
    {
      RequestProvider = BaseProvider.RequestProvider.Provider;
      ServiceName = serviceName;
    }

    public virtual async Task<TEntity> GetEntityByIdAsync(Guid entityId, string authorizationToken = null)
    {
      UriBuilder builder = CreateUriBuilder();
      builder.Path += $"/{entityId.ToString()}";
      return await RequestProvider.GetAsync<TEntity>(builder.ToString(), authorizationToken);
    }

    public virtual async Task<List<TEntity>> GetEntitiesAsync(string authorizationToken = null)
    {
      UriBuilder builder = CreateUriBuilder();
      try
      {
          return await RequestProvider.GetAsync<List<TEntity>>(builder.ToString(), authorizationToken);
      }
      catch (Exception e)
      {
          throw new ServiceHttpRequestException(e.Message);
      }
    }

    public virtual async Task<TEntity> CreateEntityAsync(TEntity newEntity, string authorizationToken = null)
    {
      UriBuilder builder = CreateUriBuilder();
      return await RequestProvider.PostAsync<TEntity, TEntity>(builder.ToString(), newEntity, authorizationToken);
    }

    public virtual async Task<TEntity> UpdateEntityAsync(TEntity updatedEntity, string authorizationToken = null)
    {
      UriBuilder builder = CreateUriBuilder();
      builder.Path += updatedEntity.Id;
      return await RequestProvider.PutAsync<TEntity, TEntity>(builder.ToString(), updatedEntity, authorizationToken);
    }

    public virtual async Task<TEntity> RemoveEntityAsync(Guid entityId, string authorizationToken = null)
    {
      UriBuilder builder = CreateUriBuilder();
      builder.Path += entityId.ToString();
      return await RequestProvider.DeleteAsync<TEntity>(builder.ToString(), authorizationToken);
    }
  }
}
