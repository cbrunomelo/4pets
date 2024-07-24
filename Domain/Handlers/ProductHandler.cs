using Domain.Commands;
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
    public class ProductHandler : IHandler<CreateProductCommands>
    {
        private readonly IProductRepository _repository;

        public ProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public IHandleResult Handle(CreateProductCommands command)
        {
            Product product = new Product(command.Name, command.Price, command.Description, command.CategoryId);

            var produtcValidate = new ProductValidation().Validate(product);

            if (!produtcValidate.IsValid)
                return new HandleResult("Por favor corrija os campos abaixo", produtcValidate.Errors.Select(x => x.ErrorMessage).ToList());

            if (_repository.VerifyProductExist(product.Name))
                return new HandleResult("Não foi possivel criar o produto", "Nome do produto já cadastrado");
            
            int id = _repository.Create(product);

            if (id == 0)
                return new HandleResult("Não foi possivel criar o produto", "Erro interno");

            product.SetId(id);

            return new HandleResult(true, "Produto criado com sucesso", product);
        }

    }
}
