using Domain.Entitys;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorys
{
    public class HistoryFieldsRepository : IHistoryFieldRepository
    {
        private readonly StoreDbContext _context;  
        public HistoryFieldsRepository()
        {
            _context = new StoreDbContext();
        }
        public int Create(HistoryField historyField)
        {
            try
            {   _context.HistoryFields.Add(historyField);
                _context.SaveChanges();
                return historyField.Id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
