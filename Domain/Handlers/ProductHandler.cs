using Domain.Commands;
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

namespace Domain.Handlers
{
    public class ProductHandler : IHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IHandler<CreateHistoryCommand> _historyHandle;
        private readonly ICategoryRepository _categoryRepository;
        public ProductHandler(IProductRepository repository, 
                             IHandler<CreateHistoryCommand> historyHandle
                             ,ICategoryRepository categoryRepo)
        {
            _repository = repository;
            _historyHandle = historyHandle;
            _categoryRepository = categoryRepo;
        }

        public IHandleResult Handle(CreateProductCommand command)
        {
            Product product = new Product(command.Name, command.Price, command.Description, command.CategoryId);

            var produtcValidate = new ProductValidation().Validate(product);

            if (!produtcValidate.IsValid)
                return new HandleResult("Por favor corrija os campos abaixo", produtcValidate.Errors.Select(x => x.ErrorMessage).ToList());

            if (_repository.VerifyProductExist(product.Name))
                return new HandleResult("Não foi possivel criar o produto", "Nome do produto já cadastrado");

            if (!_categoryRepository.VerifyCategoryExist(product.CategoryId))
                return new HandleResult("Não foi possivel criar o produto", "Categoria não encontrada");

            int id = _repository.Create(product);

            if (id == 0)
                return new HandleResult("Não foi possivel criar o produto", "Erro interno");

            product.SetId(id);

            _historyHandle.Handle(new CreateHistoryCommand(command, product, null, EHistoryAction.Insert));
            return new HandleResult(true, "Produto criado com sucesso", product);
        }

    }
}
