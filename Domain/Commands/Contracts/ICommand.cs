﻿using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Contracts
{
    public interface ICommand
    {
        int UserId { get; init; }
    }
}
