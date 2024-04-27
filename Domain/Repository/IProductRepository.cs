using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IProductRepository
    {
        int CreateProduct(Product product);
        List<string> GetUnavailableProducts(List<Product> products);
    }
}
