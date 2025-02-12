using Domain.Entitys;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorys
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly StoreDbContext _context;
        private Entity _entity;
        private Dictionary<Type, Func<History, bool>> _fields = new Dictionary<Type, Func<History, bool>>();
        public HistoryRepository()
        {
            _context = new StoreDbContext();
            PreencherDic();
        }

        public int Create(History history)
        {
            try
            {
                _context.Histories.Add(history);
                _context.SaveChanges();
                return history.Id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetHistoryId(Entity entity)
        {
            try
            {
                _entity = entity;

                var predicate = _fields[entity.GetType()];
                var history = _context.Histories.FirstOrDefault(predicate);
                if (history != null)
                    return history.Id;
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        private void PreencherDic()
        {
            _fields.Add(typeof(Category), x => x.CategoryId == _entity.Id);
            _fields.Add(typeof(Client), x => x.ClientId == _entity.Id);
            _fields.Add(typeof(Order), x => x.OrderId == _entity.Id);
            _fields.Add(typeof(OrderItem), x => x.OrderItemId == _entity.Id);
            _fields.Add(typeof(Product), x => x.ProductId == _entity.Id);
            _fields.Add(typeof(Stock), x => x.StockId == _entity.Id);

        }
    }
}
