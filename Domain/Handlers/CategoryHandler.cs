using Domain.Commands.CategoryCommands;
using Domain.Commands.HistoryCommands;
using Domain.Entitys;
using Domain.Entitys.Enuns;
using Domain.Handlers.Contracts;
using Domain.Repository;
using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Domain.Handlers
{
    public class CategoryHandler : IHandler<CreateCategoryCommand>, IHandler<EditCategoryCommand>, IHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _repo;
        private readonly IHandler<CreateHistoryCommand> _historyHandle;

        public CategoryHandler(ICategoryRepository repo, IHandler<CreateHistoryCommand> historyHandle)
        {
            _repo = repo;
            _historyHandle = historyHandle;
        }
        public async Task<IHandleResult> Handle(CreateCategoryCommand command)
        {
            var category = new Category(command.Name, command.Description);
            var validationResult = new CategoryValidation().Validate(category);
            if (!validationResult.IsValid)
                return new HandleResult("Categoria inválida!", validationResult.Errors.Select(x => x.ErrorMessage).ToList()); ;

            if (_repo.CategoryExists(category.Name))
                return new HandleResult("Não foi possivel criar categoria.", "Categoria já cadastrada"); 

            category.Status = EStatus.Active;

            var id = _repo.CreateCategory(category);
            if (id == 0)
                return new HandleResult("Não foi possivel criar categoria.", "Erro interno");

            category.SetId(id);

            _historyHandle.Handle(new CreateHistoryCommand(command, category, null,EHistoryAction.Insert));
            return new HandleResult(true, "Categoria criada com sucesso", category);
        }

        public async Task<IHandleResult> Handle(EditCategoryCommand command)
        {
            var category = new Category(command.Name, command.Description);
            category.SetId(command.Id);
            var validationResult = new CategoryValidation().Validate(category);
            if (!validationResult.IsValid)
                return new HandleResult("Categoria inválida!", validationResult.Errors.Select(x => x.ErrorMessage).ToList()); ;

            if (_repo.CategoryExists(category.Name))
                return new HandleResult("Não foi possivel editar categoria.", "Categoria já cadastrada");

            var OldCategory = _repo.GetById(command.Id);

            var sucess = _repo.Update(category);
            if (sucess)
                return new HandleResult("Não foi possivel editar categoria.", "Erro interno");

            _historyHandle.Handle(new CreateHistoryCommand(command, category, OldCategory,EHistoryAction.Update));
            return new HandleResult(true, "Categoria editada com sucesso", category);
        }


        public async Task<IHandleResult> Handle(DeleteCategoryCommand command)
        {
            var category = _repo.GetById(command.Id);
            if (category == null)
                return new HandleResult("Categoria não encontrada", "Categoria não encontrada");

            category.Status = EStatus.Inactive;

            var oldCategory = _repo.GetById(command.Id);
            var sucess = _repo.Update(category);

            if (!sucess)
                return new HandleResult("Não foi possivel deletar categoria.", "Erro interno");

            _historyHandle.Handle(new CreateHistoryCommand(command, category, oldCategory, EHistoryAction.Update));
            return new HandleResult(true, "Categoria deletada com sucesso", category);

        }

    }
}
