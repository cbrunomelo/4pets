﻿using Domain.Entitys;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorys
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _context;
        public ProductRepository()
        {
            _context = new StoreDbContext();
        }
        public int Create(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return product.Id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<Product> GetUnavailables(List<Product> products)
        {
            try
            {
                return _context.Products.Where(x => x.Stock.Quantity != 0)
                    .Include(x => x.Stock).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void LoadStock(List<OrderItem> itens)
        {
            try
            {
                foreach (var item in itens)
                {
                    item.Product = _context.Products.Find(item.ProductId);
                    item.Product.Stock = _context.Stocks.Find(item.Product.StockId);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public bool VerifyProductExist(string name)
        {
            try
            {
                return _context.Products.Any(x => x.Name == name);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}