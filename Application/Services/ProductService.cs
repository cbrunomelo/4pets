using Application.Dtos;
using Application.Messaging;
using Application.Services.Contracts;
using AutoMapper;
using Domain.Commands;
using Domain.Commands.HistoryCommands;
using Domain.Entitys;
using Domain.Handlers;
using Domain.Handlers.Contracts;
using Domain.Queries;
using Domain.Repository;

namespace Application.Services;

public class ProductService : IProductService
{
    private readonly ProductHandler _productHandler;
    private readonly IProductQuery _productQuery;
    private IMapper _mapper;
    public ProductService(IProductRepository productRepository
                         , IHandler<CreateHistoryCommand> historyHandler
                         , ICategoryRepository categoryRepo
                         , IProductQuery productQuery)
    {
        _productQuery = productQuery;
        _productHandler = new ProductHandler(productRepository, historyHandler, categoryRepo);
        _mapper = AutoMapperConfiguration.Get();
    }
    public IResultService<ProductDto> CreateProduct(ProductDto product, int userId)
    {
        var command = new CreateProductCommand(product.Name
                                               , product.Price
                                               , product.Description
                                               , product.Category
                                               , userId);
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

            return new ResultService<ProductDto>(true, "Success", productDto);
        }
        return new ResultService<ProductDto>(false, "Error", result.Errors);
    }

    public IResultService<ProductDto> DeleteProduct(ProductDto product)
    {
        throw new NotImplementedException();
    }

    public IResultService<ProductDto> GetProduct(ProductDto product)
    {
        throw new NotImplementedException();

    }

    public IResultService<ProductDto> GetById(int id, int userId)
    {
        try
        {
            var product = _productQuery.GetById(id);
            if (product == null)
                return new ResultService<ProductDto>(false, "Product not found", "001x00");

            var productDto = new ProductDto
            (
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.CategoryId ?? 0
            );

            return new ResultService<ProductDto>(true, "Success", productDto);
        }
        catch (Exception ex)
        {
            return new ResultService<ProductDto>(false, "Internal Error", "001x00");
        }
    }

    public IResultService<ProductDto> UpdateProduct(ProductDto product, int usuarioId)
     {
        try
        {
            var command = _mapper.Map<UpdateProductCommand>(product, opt => opt.Items["UserId"] = usuarioId);
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

                return new ResultService<ProductDto>(true, "Success", productDto);
            }
            return new ResultService<ProductDto>(false, result.Message, result.Errors);
        }
        catch
        {
            return new ResultService<ProductDto>(false, "Internal Error", "001x00");
        }
    }

}

