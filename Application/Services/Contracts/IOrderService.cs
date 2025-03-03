﻿using Application.Dtos;
using Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Contracts
{
    public interface IOrderService
    {
        Task<IResultService<OrderDto>> Create(OrderDto orderDto);
    }
}
