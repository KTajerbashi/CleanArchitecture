namespace CleanArchitecture.Core.Domain.Library.Common;

public interface IEvent : INotification
{

}
public abstract class BaseEvent : IEvent
{
}


public interface IBaseEventHandler<TEvent> : INotificationHandler<TEvent>
    where TEvent : BaseEvent
{

}

public abstract class BaseEventHandler<TEvent> : IBaseEventHandler<TEvent>
    where TEvent : BaseEvent
{
    public abstract Task Handle(TEvent notification, CancellationToken cancellationToken);

}
