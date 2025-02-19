using Domain.Commands;
using Domain.Commands.HistoryCommands;
using Domain.Commands.ProductCommands;
using Domain.Entitys;
using Domain.Entitys.Enuns;
using Domain.Handlers.Contracts;
using Domain.Queries.CategoryQuerys;
using Domain.Repository;
using Domain.Validation;
using MediatR;

namespace Domain.Handlers
{
    public class ProductHandler : IHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IMediator _mediator;
        public ProductHandler(IProductRepository repository,
                              IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<IHandleResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            Product product = new Product(command.Name, command.Price, command.Description, command.CategoryId);

            var produtcValidate = new ProductValidation().Validate(product);

            if (!produtcValidate.IsValid)
                return new HandleResult("Por favor corrija os campos abaixo", produtcValidate.Errors.Select(x => x.ErrorMessage).ToList());

            if (_repository.VerifyProductExist(product.Name))
                return new HandleResult("Não foi possivel criar o produto", "Nome do produto já cadastrado");

            var categoriaExiste = await _mediator.Send(new VerifyCategoryExist(product.CategoryId ?? 0));
            if (!categoriaExiste)
                return new HandleResult("Não foi possivel criar o produto", "Categoria não encontrada");

            int id = _repository.Create(product);

            if (id == 0)
                return new HandleResult("Não foi possivel criar o produto", "Erro interno");

            product.SetId(id);

            await _mediator.Send(new CreateHistoryCommand(command, product, null, EHistoryAction.Insert));

            return new HandleResult(true, "Produto criado com sucesso", product);
        }

        public async Task<IHandleResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            Product productNew = _repository.GetById(command.Id);

            if (productNew == null)
                return new HandleResult("Não foi possivel atualizar o produto", "Produto não encontrado");

            Product productOld = (Product)productNew.Clone();

            productNew.Update(command.Name, command.Price, command.Description, command.CategoryId);

            var produtcValidate = new ProductValidation().Validate(productNew);

            if (!produtcValidate.IsValid)
                return new HandleResult("Por favor corrija os campos abaixo", produtcValidate.Errors.Select(x => x.ErrorMessage).ToList());

            var categoriaExiste = await _mediator.Send(new VerifyCategoryExist(productNew.CategoryId ?? 0));
            if (!categoriaExiste)
                return new HandleResult("Não foi possivel atualizar o produto", "Categoria não encontrada");

            _repository.Update(productNew);

            _mediator.Send(new CreateHistoryCommand(command, productNew, productOld, EHistoryAction.Update));

            return new HandleResult(true, "Produto atualizado com sucesso", productNew);
        }


        public IHandleResult Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            Product product = _repository.GetById(command.Id);
            if (product == null)
                return new HandleResult("Não foi possivel deletar o produto", "Produto não encontrado");
            _repository.Delete(product);
            _mediator.Send(new CreateHistoryCommand(command, product, null, EHistoryAction.Delete));
            return new HandleResult(true, "Produto deletado com sucesso", product);

        }
    }
}
