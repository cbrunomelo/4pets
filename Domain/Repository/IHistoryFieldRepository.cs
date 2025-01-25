using Domain.Entitys;

namespace Domain.Repository
{
    public interface IHistoryFieldRepository
    {
        int Create(HistoryField historyField);
    }
}