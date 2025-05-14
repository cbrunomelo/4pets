using Domain.Entitys.Enuns;
using MediatR;

namespace Domain.Entitys
{
    public abstract class Entity
    {
        private List<INotification> _notifications = new List<INotification>();
        public IReadOnlyCollection<INotification> Notifications => _notifications.AsReadOnly();
        public int Id { get; protected set; }
        public EStatus Status { get; internal set; }
        public History History { get; set; }
        public int HistoryId { get; set; }
        public abstract Entity Clone();

        public void AddNotification(INotification notification) => _notifications.Add(notification);
        public void ClearNotifications() => _notifications.Clear();
    }
}