﻿using Domain.Commands.Contracts;
using Domain.Entitys;
using Domain.Entitys.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.HistoryCommands
{
    public record CreateHistoryCommand(ICommand command,Entity CurrentEntity,Entity OldEntity ,EHistoryAction Action) : ICommand
    {
        public DateTime Date { get; init; } = DateTime.Now;
        int ICommand.UserId { get; init; }
    }
}