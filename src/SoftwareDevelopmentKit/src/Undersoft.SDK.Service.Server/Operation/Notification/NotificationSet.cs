using MediatR;

namespace Undersoft.SDK.Service.Server.Operation.Notification;

using Command;
using Series;
using Undersoft.SDK.Service.Data.Event;

public abstract class NotificationSet<TCommand> : Catalog<Notification<TCommand>>, INotification
    where TCommand : CommandBase
{
    public EventPublishMode PublishMode { get; set; }

    protected NotificationSet(EventPublishMode publishPattern, Notification<TCommand>[] commands)
        : base(commands)
    {
        PublishMode = publishPattern;
    }
}
