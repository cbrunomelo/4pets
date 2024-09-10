using Application.Dtos;
using Application.Messaging;

namespace Application.Services.Contracts;
internal interface IProductService
{
    IResultService GetProduct(ProductDto product);
    IResultService CreateProduct(ProductDto product, int userId);
    IResultService UpdateProduct(ProductDto product);
    IResultService DeleteProduct(ProductDto product);
    IResultService GetById(int id, int userId);
}

