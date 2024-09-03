using Application.Dtos;
using Application.Messaging;
using Application.Services.Contracts;
using AutoMapper;
using Domain.Commands;
using Domain.Commands.HistoryCommands;
using Domain.Entitys;
using Domain.Handlers;
using Domain.Handlers.Contracts;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductHandler _productHandler;
        private IMapper _mapper;
        public ProductService(IProductRepository productRepository
                             ,IHandler<CreateHistoryCommand> historyHandler
                             ,ICategoryRepository categoryRepo)
        {
            _productHandler = new ProductHandler(productRepository, historyHandler, categoryRepo);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDto, CreateProductCommand>();
            });

            _mapper = config.CreateMapper();
        }
        public IResultService CreateProduct(ProductDto product, int userId)
        {
            var command = new CreateProductCommand(product.Name
                                                   ,product.Price
                                                   ,product.Description
                                                   ,product.Category
                                                   ,userId);
            var result = _productHandler.Handle(command);
            if (result.Sucess)
            {
                var productDto = new ProductDto
                (
                    (result.Data as Product).Id,
                    (result.Data as Product).Name,
                    (result.Data as Product).Description,
                    (result.Data as Product).Price,
                    (result.Data as Product).CategoryId ?? 0
                );

                return new ResultService(true, "Success", productDto);
            }
            return new ResultService(false, "Error", result.Errors);
        }

        public IResultService DeleteProduct(ProductDto product)
        {
            throw new NotImplementedException();
        }

        public IResultService GetProduct(ProductDto product)
        {
            throw new NotImplementedException();

        }

        public IResultService UpdateProduct(ProductDto product)
        {
            throw new NotImplementedException();
        }
    }
}
