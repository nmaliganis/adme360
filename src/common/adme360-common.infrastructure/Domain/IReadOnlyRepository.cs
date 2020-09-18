using System.Collections.Generic;

namespace adme360.common.infrastructure.Domain
{
    public interface IReadOnlyRepository<T, in TId>
        where T : IAggregateRoot
    {
        T FindBy(TId id);
        IList<T> FindAll();
        IList<T> FindAll(int index, int count);
    }
}
