using Domain.Commands.HistoryCommands;
using Domain.Entitys;
using Domain.Entitys.Enuns;
using Domain.Handlers.Contracts;
using Domain.Repository;
using Domain.Validation;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Handlers
{
    public class HistoryHandler : IRequestHandler<CreateHistoryCommand, IHandleResult>, IHandler<CreateHistoryCommand>
    {
        private readonly IHistoryRepository _repo;
        private readonly IHistoryFieldRepository _repoField;

        public HistoryHandler(IHistoryRepository repo, IHistoryFieldRepository repoField)
        {
            _repo = repo;
            _repoField = repoField;
        }
        public async Task<IHandleResult> Handle(CreateHistoryCommand request, CancellationToken cancellationToken)
        {
            var history = new History(request.CurrentEntity, request.command.UserId);
            var validationResult = new HistoryValidation().Validate(history);
            if (!validationResult.IsValid)
                return new HandleResult("Histórico inválido!", validationResult.Errors.Select(x => x.ErrorMessage).ToList());

            int historyID = _repo.GetHistoryId(request.CurrentEntity);
            if (historyID == 0)
            {
                historyID = _repo.Create(history);
            }

            if (historyID == 0)
                return new HandleResult("Não foi possivel criar histórico.", "Erro interno 00x001");

            foreach (var field in request.CurrentEntity.GetType().GetProperties())
            {
                var currentValue = field.GetValue(request.CurrentEntity)?.ToString();
                var oldValue = request.OldEntity?.GetType().GetProperty(field.Name)?.GetValue(request.OldEntity)?.ToString();
                if (currentValue != oldValue)
                {
                    var historyField = new HistoryField(historyID, request.command.UserId, request.Action, field.Name, currentValue, oldValue);
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

        public Task<IHandleResult> Handle(CreateHistoryCommand command) => Handle(command, new System.Threading.CancellationToken());
        
    }
}
