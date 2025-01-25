using Domain.Commands.HistoryCommands;
using Domain.Commands.StockCommands;
using Domain.Handlers.Contracts;
using Domain.Repository;
using Domain.Services;
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
        private IEmailService _emailService;
        private IHandler<CreateHistoryCommand> _historyHandle;
        public StockHandler(IStockRepository stockRepository, IEmailService emailService, IHandler<CreateHistoryCommand> historyHandle)
        {
            _stockRepository = stockRepository;
            _emailService = emailService;
            _historyHandle = historyHandle;
        }

        public IHandleResult Handle(EntryStockCommand command)
        {
            var stock = _stockRepository.Get(command.StockId);

            if (stock == null)
                return new HandleResult("Estoque não encontrado", "Estoque não encontrado");

            if (stock.Quantity == 0 && stock.ClientObservers.Count > 0 && command.Quantity > 0)
            {
                foreach (var client in stock.ClientObservers)
                {
                    _emailService.Send(client.Email, "Estoque disponível", $"O estoque {stock.Name} está disponível");
                }
            }

            _historyHandle.Handle(new CreateHistoryCommand(command, stock, null, Entitys.Enuns.EHistoryAction.Update));

            return new HandleResult(true, "Estoque atualizado com sucesso", stock);
        }

        public IHandleResult Handle(CreateStockCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
