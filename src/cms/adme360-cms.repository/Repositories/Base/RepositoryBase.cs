using System.Collections.Generic;
using adme360.common.infrastructure.Domain;
using NHibernate;

namespace adme360.cms.repository.Repositories.Base
{
  public abstract class RepositoryBase<T, TEntityKey>
    where T : IAggregateRoot
  {
    protected ISession Session;

    protected RepositoryBase(ISession session)
    {
      Session = session;
    }

    public void Add(T entity)
    {
      Session.Save(entity);
    }

    public void Remove(T entity)
    {
      Session.Delete(entity);
    }

    public void Save(T entity)
    {
      Session.SaveOrUpdate(entity);
    }

    public T FindBy(TEntityKey id)
    {
      return Session.Get<T>(id);
    }

    public IList<T> FindAll()
    {
      var criteriaQuery =
        Session.CreateCriteria(typeof(T))
          .SetCacheable(true)
          .SetCacheMode(CacheMode.Normal)
          .SetFlushMode(FlushMode.Never);

      return (List<T>)criteriaQuery.List<T>();
    }

    public IList<T> FindAll(int index, int count)
    {
      var criteriaQuery =
        Session.CreateCriteria(typeof(T))
          .SetCacheable(true)
          .SetCacheMode(CacheMode.Normal)
          .SetFlushMode(FlushMode.Never);

      return (List<T>)criteriaQuery.SetFetchSize(count)
        .SetFirstResult(index).List<T>();
    }
  }
}
