using Application.Dtos;
using Application.Messaging;

namespace Application.Services.Contracts;
internal interface IProductService
{
    IResultService<IEnumerable<ProductDto>> GetAll(PaginacaoDto pag);
    IResultService<ProductDto> Create(ProductDto product, int userId);
    IResultService<ProductDto> Update(ProductDto product, int userId);
    IResultService<bool> Delete(int Id, int userID);
    IResultService<ProductDto> GetById(int id, int userId);
}

