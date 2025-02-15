using Application.Dtos;
using Application.Dtos.Conf;
using Application.Messaging;
using Application.Services.Contracts;
using AutoMapper;
using Domain.Commands;
using Domain.Commands.HistoryCommands;
using Domain.Commands.ProductCommands;
using Domain.Entitys;
using Domain.Handlers;
using Domain.Handlers.Contracts;
using Domain.Queries;
using Domain.Repository;
using MediatR;

namespace Application.Services;

public class ProductService : IProductService
{
    private readonly ProductHandler _productHandler;
    private readonly IProductQuery _productQuery;
    private IMapper _mapper;
    private readonly IMediator _mediator;
    public ProductService(IProductRepository productRepository
                        , IMediator mediator
                         , IProductQuery productQuery)
    {
        _productQuery = productQuery;
        _productHandler = new ProductHandler(productRepository, mediator);
        _mapper = AutoMapperConfiguration.Get();
    }
    public async Task<IResultService<ProductDto>> Create(ProductDto product, int userId)
    {

        var command = _mapper.Map<CreateProductCommand>(product, opt => opt.Items["UserId"] = userId);

        var result = await _productHandler.Handle(command);
        if (result.Sucess)
        {
            var productDto = _mapper.Map<ProductDto>((Product)result.Data);

            return new ResultService<ProductDto>(true, "Success", productDto);
        }
        return new ResultService<ProductDto>(false, "Error", result.Errors);
    }

    public IResultService<bool> Delete(int Id, int userId)
    {
        try
        {
            var command = new DeleteProductCommand(Id, userId);
            var result = _productHandler.Handle(command);
            if (result.Sucess)
                return new ResultService<bool>(true, "Success", true);
            return new ResultService<bool>(false, result.Message, result.Errors);
        }
        catch
        {
            return new ResultService<bool>(false, "Internal Error", "001x00");
        }
    }

    public IResultService<IEnumerable<ProductDto>> GetAll(PaginacaoDto pag)
    {
        try
        {
            var products = _productQuery.GetProducts(pag.Page, pag.PageSize);
            var productsDto = _mapper.Map<List<ProductDto>>(products);
            return new ResultService<IEnumerable<ProductDto>>(true, "Success", productsDto);
        }
        catch
        {
            return new ResultService<IEnumerable<ProductDto>>(false, "Internal Error", "001x00");
        }

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

    public async Task<IResultService<ProductDto>> Update(ProductDto product, int usuarioId)
     {
        try
        {
            var command = _mapper.Map<UpdateProductCommand>(product, opt => opt.Items["UserId"] = usuarioId);
            var result =await _productHandler.Handle(command);
            if (result.Sucess)
            {
                var rtnProductDto = _mapper.Map<ProductDto>((Product)result.Data);

                return new ResultService<ProductDto>(true, "Success", rtnProductDto);
            }
            return new ResultService<ProductDto>(false, result.Message, result.Errors);
        }
        catch
        {
            return new ResultService<ProductDto>(false, "Internal Error", "001x00");
        }
    }

}

