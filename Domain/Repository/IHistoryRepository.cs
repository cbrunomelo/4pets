using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IHistoryRepository
    {
        int Create(History history);
        int GetHistoryId(Entity entity);
    }
}
