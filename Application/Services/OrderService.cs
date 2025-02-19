using Application.Dtos;
using Application.Messaging;
using Application.Services.Contracts;
using AutoMapper;
using Domain.Commands.HistoryCommands;
using Domain.Commands.OrderCommands;
using Domain.Handlers;
using Domain.Handlers.Contracts;
using Domain.Repository;
using MediatR;
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
                           IMediator mediator)
        {

            _orderHandler = new OrderHandler(orderRepository, orderItemRepository, mediator);

        }

        public async Task<IResultService<OrderDto>> Create(OrderDto orderDto)
        {
            var command = _mapper.Map<CreateOrderCommand>(orderDto);
            var result = await _orderHandler.Handle(command, new CancellationToken());
            return _mapper.Map<ResultService<OrderDto>>(result);
        }


    }
}
