using Domain.Commands.HistoryCommands;
using Domain.Entitys;
using Domain.Handlers.Contracts;
using Domain.Repository;
using Domain.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Handlers
{
    public class HistoryHandler : IHandler<CreateHistoryCommand>
    {
        private readonly IHistoryRepository _repo;
        public HistoryHandler(IHistoryRepository repo)
        {
            _repo = repo;
        }
        public IHandleResult Handle(CreateHistoryCommand command)
        {
            var history = new History(command.EntityName, command.EntityId, command.UserId, command.Action, command.Date);
            var validationResult = new HistoryValidation().Validate(history);
            if (!validationResult.IsValid)
                return new HandleResult("Histórico inválido!", validationResult.Errors.Select(x => x.ErrorMessage).ToList());

            var id = _repo.Create(history);
            if (id == 0)
                return new HandleResult("Não foi possivel criar histórico.", "Erro interno");

            return new HandleResult(true, "Histórico criado com sucesso", history);

        }
    }
}
