using Domain.Commands;
using Domain.Commands.HistoryCommands;
using Domain.Commands.ProductCommands;
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
                             , ICategoryRepository categoryRepo)
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

        public IHandleResult Handle(UpdateProductCommand command)
        {
            Product productNew = _repository.GetById(command.Id);

            if (productNew == null)
                return new HandleResult("Não foi possivel atualizar o produto", "Produto não encontrado");

            Product productOld = productNew.Copy();

            productNew.Update(command.Name, command.Price, command.Description, command.CategoryId);

            var produtcValidate = new ProductValidation().Validate(productNew);

            if (!produtcValidate.IsValid)
                return new HandleResult("Por favor corrija os campos abaixo", produtcValidate.Errors.Select(x => x.ErrorMessage).ToList());

            if (!_categoryRepository.VerifyCategoryExist(productNew.CategoryId))
                return new HandleResult("Não foi possivel atualizar o produto", "Categoria não encontrada");

            _repository.Update(productNew);

            _historyHandle.Handle(new CreateHistoryCommand(command, productNew, productOld, EHistoryAction.Update));
            return new HandleResult(true, "Produto atualizado com sucesso", productNew);
        }


        public IHandleResult Handle(DeleteProductCommand command)
        {
            Product product = _repository.GetById(command.Id);
            if (product == null)
                return new HandleResult("Não foi possivel deletar o produto", "Produto não encontrado");
            _repository.Delete(product);
            _historyHandle.Handle(new CreateHistoryCommand(command, product, null, EHistoryAction.Delete));
            return new HandleResult(true, "Produto deletado com sucesso", product);

        }
    }
}
