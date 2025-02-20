using Domain.Commands.HistoryCommands;
using Domain.Commands.StockCommands;
using Domain.Handlers.Contracts;
using Domain.Repository;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Handlers
{
    public class StockHandler : IHandler<EntryStockCommand>,
                                IHandler<CreateStockCommand>
    {
        private IStockRepository _stockRepository;
        private IMediator _mediator;
        public StockHandler(IStockRepository stockRepository, IMediator mediator)
        {
            _stockRepository = stockRepository;
            _mediator = mediator;
        }

        public async Task<IHandleResult> Handle(EntryStockCommand command, CancellationToken cancellationToken)
        {
            var stock = _stockRepository.Get(command.StockId);

            var oldStock = stock.Clone() as Entitys.Stock;

            if (stock == null)
                return new HandleResult("Estoque não encontrado", "Estoque não encontrado");

            stock.Entry(command.Quantity, command.TotalValue);

            _stockRepository.Update(stock);

            await _mediator.Send(new CreateHistoryCommand(command, stock, oldStock, Entitys.Enuns.EHistoryAction.Update));

            return new HandleResult(true, "Estoque atualizado com sucesso", stock);
        }

        public async Task<IHandleResult> Handle(CreateStockCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
