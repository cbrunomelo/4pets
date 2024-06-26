﻿using Domain.Commands.CategoryCommands;
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
            var category = new Category(command.Name, command.Description);
            var validationResult = new CategoryValidation().Validate(category);
            if (!validationResult.IsValid)
                return new HandleResult("Categoria inválida!", validationResult.Errors.Select(x => x.ErrorMessage).ToList()); ;

            if (_repo.CategoryExists(category.Name))
                return new HandleResult("Não foi possivel criar categoria.", "Categoria já cadastrada"); 

            var id = _repo.CreateCategory(category);
            if (id == 0)
                return new HandleResult("Não foi possivel criar categoria.", "Erro interno");

            category.SetId(id);

            return new HandleResult(true, "Categoria criada com sucesso", category);
        }
    }
}
