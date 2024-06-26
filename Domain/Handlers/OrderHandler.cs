﻿using Domain.Commands.OrderCommands;
using Domain.Entitys;
using Domain.Handlers.Contracts;
using Domain.Repository;
using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Handlers
{
    public class OrderHandler : IHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _repo;
        private readonly IProductRepository _productRepository;
        public OrderHandler(IOrderRepository repository, IProductRepository productRepository) 
        {
            _repo = repository;
            _productRepository = productRepository;
        }
        public IHandleResult Handle(CreateOrderCommand command)
        {
            Order order = new Order(command.Products, command.ClientId);
            var validate = new OrderValidation().Validate(order);
            if (!validate.IsValid)
                return new HandleResult("Não foi possível criar o pedido", validate.Errors.Select(x => x.ErrorMessage).ToList());

            List<Product> UnavailableProducts = _productRepository.GetUnavailables(order.Products);
            if (UnavailableProducts.Count > 0)
                return new HandleResult("Não foi possível criar o pedido, um ou mais produto indisponível", UnavailableProducts.Select(x => x.Name).ToList());


            int id = _repo.Create(order);
            if (id == 0)
                return new HandleResult("Não foi possível criar o pedido", "Erro interno");

            order.SetId(id);

            return new HandleResult(true, "Pedido criado com sucesso", order);

            
        }
    }
}
