using Domain.Entitys.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class HistoryField : Entity
    {

        public HistoryField(int historyID, int userId, EHistoryAction action, string fieldName, string currentValue) 
        {
            HistoryId = historyID;
            UserId = userId;
            Action = action;
            FieldName = fieldName;
            CurrentValue = currentValue;
        }

        private int UserId;
        public EHistoryAction Action { get; set; }
        public string FieldName { get; set; }
        public string CurrentValue { get; set; }
        public int HistoryId { get; set; }
        public History History { get; set; }
        
    }
}
