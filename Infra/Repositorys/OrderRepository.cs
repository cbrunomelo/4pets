using Domain.Entitys;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorys
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreDbContext _context;
        public OrderRepository()
        {
            _context = new StoreDbContext();
        }
        public int Create(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order.Id;
        }

    }
}
