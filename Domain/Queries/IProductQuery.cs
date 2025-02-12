using Domain.Entitys;
using Domain.Queries.Contracts;

namespace Domain.Queries;
public interface IProductQuery : IQuery
{
    IEnumerable<Product> GetProducts(int page, int pageSize);
    Product GetById(int id);
}

