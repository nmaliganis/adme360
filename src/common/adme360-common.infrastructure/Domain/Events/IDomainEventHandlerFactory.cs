using System.Collections.Generic;

namespace adme360.common.infrastructure.Domain.Events
{
    public interface IDomainEventHandlerFactory
    {
        IEnumerable<IDomainEventHandler<T>> GetDomainEventHandlersFor<T>(T domainEvent)
            where T : IDomainEvent;
    }
}