using Application.Dtos;
using Application.Messaging;
using Application.Services.Contracts;
using AutoMapper;
using Domain.Commands;
using Domain.Commands.HistoryCommands;
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
                             ,IHandler<CreateHistoryCommand> historyHandler)
        {
            _productHandler = new ProductHandler(productRepository, historyHandler);
        }
        public IResultService CreateProduct(ProductDto product)
        {
            var command = _mapper.Map<CreateProductCommand>(product);
            var result = _productHandler.Handle(command);
            return _mapper.Map<ResultService>(result);
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
