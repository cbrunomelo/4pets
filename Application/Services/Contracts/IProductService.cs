using Application.Dtos;
using Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Contracts
{
    internal interface IProductService
    {        
        IResultService GetProduct(ProductDto product);
        IResultService CreateProduct(ProductDto product, int userId);
        IResultService UpdateProduct(ProductDto product);
        IResultService DeleteProduct(ProductDto product);
        

    }
}
