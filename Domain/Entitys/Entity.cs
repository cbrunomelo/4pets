using Domain.Entitys.Enuns;

namespace Domain.Entitys
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public EStatus Status { get; internal set; }
        public History History { get; set; }
        public int HistoryId { get; set; }
    }
}