using Domain.Entitys.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class History
    {
        public History(string entityName, int entityId, int userId, EHistoryAction action, DateTime date)
        {
            this.entityName = entityName;
            EntityId = entityId;
            UserId = userId;
            Action = action;
            Date = date;
        }

        public int Id { get; set; }
        public EHistoryAction Action { get; set; }
        public string entityName { get; set; }
        public int EntityId { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
