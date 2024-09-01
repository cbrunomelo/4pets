using Application.Dtos;
using Application.Messaging;
using Application.Services.Contracts;
using AutoMapper;
using Domain.Commands.HistoryCommands;
using Domain.Commands.OrderCommands;
using Domain.Handlers;
using Domain.Handlers.Contracts;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private IMapper _mapper;

        private readonly IHandler<CreateOrderCommand> _orderHandler;
        public OrderService(IOrderRepository orderRepository, 
                           IOrderItemRepository orderItemRepository, 
                           IHandler<CreateHistoryCommand> historyHandler,
                           IStockRepository stockRepository)
        {

            _orderHandler = new OrderHandler(orderRepository, orderItemRepository, historyHandler, stockRepository);

        }

        public IResultService Create(OrderDto orderDto)
        {
            var command = _mapper.Map<CreateOrderCommand>(orderDto);
            var result = _orderHandler.Handle(command);
            return _mapper.Map<ResultService>(result);
        }


    }
}
