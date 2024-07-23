﻿using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IOrderRepository
    {
        int Create(Order order);       
        bool Exists(string name);
    }
}
