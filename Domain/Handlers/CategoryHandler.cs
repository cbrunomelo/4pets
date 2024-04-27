using Domain.Commands.CategoryCommands;
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
    public class CategoryHandler : IHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _repo;

        public CategoryHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }
        public IHandleResult Handle(CreateCategoryCommand command)
        {
            var category = new Category(command.Name);
            var validationResult = new CategoryValidation().Validate(category);
            if (!validationResult.IsValid)
                return new HandleResult("Categoria inválida!", validationResult.Errors.Select(x => x.ErrorMessage));

            if (_repo.CategoryExists(category.Name))
                return new HandleResult(false, "Categoria já cadastrada", null);

            var id = _repo.CreateCategory(category);
            if (id == 0)
                return new HandleResult(false, "Erro ao criar a categoria", null);

            category.SetId(id);

            return new HandleResult(true, "Categoria criada com sucesso", category);
        }
    }
}
