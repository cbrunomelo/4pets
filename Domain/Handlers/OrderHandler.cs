using Domain.Commands.OrderCommands;
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
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IStockRepository _stockRepository;
        
        public OrderHandler(IOrderRepository repository, IProductRepository productRepository) 
        {
            _repo = repository;
            _productRepository = productRepository;
        }
        public IHandleResult Handle(CreateOrderCommand command)
        {
            Order order = new Order(command.Itens, command.ClientId);
            var validate = new OrderValidation().Validate(order);
            if (!validate.IsValid)
                return new HandleResult("Não foi possível criar o pedido", validate.Errors.Select(x => x.ErrorMessage).ToList());

            var orderItens = _orderItemRepository.LoadProductsWithStock(order.Itens);

            if (orderItens.Count != order.Itens.Count)
                return new HandleResult("Não foi possível criar o pedido", "Produto sem estoque");

            var outOfStock = new List<string>();

            foreach (var item in orderItens)
            {
                if (item.Quantity > item.Product.Stock.Quantity)
                    outOfStock.Add(item.Product.Name);
            }

            if (outOfStock.Count > 0)
                return new HandleResult("Não foi possível criar o pedido", outOfStock);

            int id = _repo.Create(new Order(orderItens, command.ClientId));
            if (id == 0)
                return new HandleResult("Não foi possível criar o pedido", "Erro interno");

            order.SetId(id);

            foreach (var item in orderItens)
            {
                _stockRepository.DecreaseStock(item.Product.Id, item.Quantity);
            }

            return new HandleResult(true, "Pedido criado com sucesso", order);

            
        }
    }
}
