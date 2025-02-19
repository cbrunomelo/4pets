using Domain.Entitys;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorys
{
    public class StockRepository : IStockRepository
    {
        private readonly StoreDbContext _context;
        public StockRepository()
        {
            _context = new StoreDbContext();
        }
        public void DecreaseStock(int productId, int quantity)
        {
            try
            { 
                var stock = _context.Stocks.FirstOrDefault(x => x.ProductId == productId);
                stock?.DecreaseStock(quantity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                
            }
        }

        public Stock Get(int stockId)
        {
            try
            {
                return _context.Stocks.FirstOrDefault(x => x.Id == stockId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Update(Stock stock)
        {
            throw new NotImplementedException();
        }
    }
}
