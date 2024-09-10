using Domain.Entitys;
using Domain.Queries.Contracts;

namespace Domain.Queries;
public interface IProductQuery : IQuery
{
    Product GetProduct(Product product);
    Product GetProductById(int id);
}

