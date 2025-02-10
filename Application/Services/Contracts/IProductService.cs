using Application.Dtos;
using Application.Messaging;

namespace Application.Services.Contracts;
internal interface IProductService
{
    IResultService<ProductDto> GetProduct(ProductDto product);
    IResultService<ProductDto> CreateProduct(ProductDto product, int userId);
    IResultService<ProductDto> UpdateProduct(ProductDto product, int userId);
    IResultService<ProductDto> DeleteProduct(ProductDto product);
    IResultService<ProductDto> GetById(int id, int userId);
}

