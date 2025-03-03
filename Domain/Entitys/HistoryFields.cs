﻿using Domain.Entitys.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class HistoryField : Entity
    {
        public HistoryField() { }
        public HistoryField(int historyID, int userId, EHistoryAction action, string fieldName, string currentValue, string previousValue) 
        {
            HistoryId = historyID;
            UserId = userId;
            Action = action;
            FieldName = fieldName;
            CurrentValue = currentValue;
            PreviousValue = previousValue;
        }

        private int UserId;
        public EHistoryAction Action { get; set; }
        public string FieldName { get; set; }
        public string CurrentValue { get; set; }
        public string PreviousValue { get; set; }
        public int HistoryId { get; set; }
        public History History { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public override Entity Clone()
        {
            return new HistoryField(HistoryId, UserId, Action, FieldName, CurrentValue, PreviousValue);
        }
    }
}
