using Domain.Commands.HistoryCommands;
using Domain.Commands.OrderCommands;
using Domain.Entitys;
using Domain.Entitys.Enuns;
using Domain.Events;
using Domain.Extensions;
using Domain.Handlers.Contracts;
using Domain.Repository;
using Domain.Validation;
using MediatR;

namespace Domain.Handlers
{
    public class OrderHandler : IHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _repo;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMediator _mediator;

        public OrderHandler(IOrderRepository repository
            ,IOrderItemRepository orderItemRepository
            ,IMediator mediator) 
        {
            _repo = repository;
            _orderItemRepository = orderItemRepository;
            _mediator = mediator;
        }
        public async Task<IHandleResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            Order order = new Order(command.Itens, command.ClientId);
            var validate = new OrderValidation().Validate(order);
            if (!validate.IsValid)
                return new HandleResult("Não foi possível criar o pedido", validate.Errors.Select(x => x.ErrorMessage).ToList());

            var orderItens = _orderItemRepository.LoadProductsWithStock(order.Itens);

            if (orderItens.Count != order.Itens.Count)
                return new HandleResult("Não foi possível criar o pedido", "Produto sem estoque");

            var outOfStock = GetOutOfStock(orderItens);

            if (outOfStock.Count > 0)
                return new HandleResult("Não foi possível criar o pedido, um ou mais produto indisponível", outOfStock);

            int id = _repo.Create(new Order(orderItens, command.ClientId));
            if (id == 0)
                return new HandleResult("Não foi possível criar o pedido", "Erro interno");

            order.SetId(id);

            order.AddNotification(new OrderCreatedNotification<Order>(order));

            _mediator.Send(new CreateHistoryCommand(command, order, null, EHistoryAction.Insert));

            _mediator.PublishAll(order);

            return new HandleResult(true, "Pedido criado com sucesso", order);

            
        }

        private List<string> GetOutOfStock(List<OrderItem> orderItens)
        {
            var outOfStock = new List<string>();
            foreach (var item in orderItens)
            {
                if (item.Product.Stock.Quantity < item.Quantity)
                    outOfStock.Add(item.Product.Name);
            }
            return outOfStock;
        }
    }
}
