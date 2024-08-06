using Domain.Commands.HistoryCommands;
using Domain.Entitys;
using Domain.Entitys.Enuns;
using Domain.Handlers.Contracts;
using Domain.Repository;
using Domain.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Handlers
{
    public class HistoryHandler : IHandler<CreateHistoryCommand>
    {
        private readonly IHistoryRepository _repo;
        private readonly IHistoryFieldRepository _repoField;

        public HistoryHandler(IHistoryRepository repo, IHistoryFieldRepository repoField)
        {
            _repo = repo;
            _repoField = repoField;
        }
        public IHandleResult Handle(CreateHistoryCommand command)
        {
            var history = new History(command.CurrentEntity, command.command.UserId);
            var validationResult = new HistoryValidation().Validate(history);
            if (!validationResult.IsValid)
                return new HandleResult("Histórico inválido!", validationResult.Errors.Select(x => x.ErrorMessage).ToList());

            int historyID = 0;
            if (command.Action == EHistoryAction.Insert)
            {
                historyID = _repo.Create(history);
            }

            if ( command.Action == EHistoryAction.Update)
            {
                historyID = _repo.GetHistoryId(command.CurrentEntity);
            }
            if (historyID == 0)
                return new HandleResult("Não foi possivel criar histórico.", "Erro interno 00x001");

            foreach (var field in command.CurrentEntity.GetType().GetType().GetProperties())
            {
                var currentValue = field.GetValue(command.CurrentEntity)?.ToString();
                var oldValue = command.OldEntity?.GetType().GetProperty(field.Name)?.GetValue(command.OldEntity)?.ToString();
                if (currentValue != oldValue)
                {
                    var historyField = new HistoryField(historyID, command.command.UserId, command.Action, field.Name, currentValue);
                    var fieldId = _repoField.Create(historyField);
                    if (fieldId == 0)
                        return new HandleResult("Não foi possivel criar histórico.", "Erro interno 00x002");
                }

            }


            var id = _repo.Create(history);
            if (id == 0)
                return new HandleResult("Não foi possivel criar histórico.", "Erro interno");

            return new HandleResult(true, "Histórico criado com sucesso", history);

        }
    }
}
