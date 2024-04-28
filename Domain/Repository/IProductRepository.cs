﻿using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IProductRepository
    {
        int Create(Product product);
        List<string> GetUnavailables(List<Product> products);
        bool VerifyProductExist(string name);
    }
}
