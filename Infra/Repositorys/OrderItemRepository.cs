﻿using Domain.Entitys;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorys
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly StoreDbContext _context;
        public OrderItemRepository()
        {
            _context = new StoreDbContext();
        }
        public List<OrderItem> LoadProductsWithStock(List<OrderItem> itens)
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
                return null;
            }
            return itens;
        }
    }
}
