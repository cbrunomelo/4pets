using Domain.Entitys;
using MediatR;

namespace Domain.Extensions;

static class MediatrExtension
{
    public static bool PublishAll(this IMediator mediator, Entity entity)
    {
        if (entity.Notifications.Count == 0)
            return true;
        foreach (var notification in entity.Notifications)
        {
            mediator.Publish(notification);
        }
        entity.ClearNotifications();
        return false;
    }
}
