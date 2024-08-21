using Domain.Entitys;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorys
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _context;
        public CategoryRepository()
        {
            _context = new StoreDbContext();
        }
        public bool CategoryExists(string name)
        {
            try
            {
                return _context.Categories.Any(c => c.Name == name);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int CreateCategory(Category category)
        {
            try
            {
                if (CategoryExists(category.Name))
                    return 0;
                _context.Categories.Add(category);
                _context.SaveChanges();
                return category.Id;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public Category GetById(int id)
        {
            try
            {
                return _context.Categories.FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public bool Update(Category category)
        {
            try
            {
                var oldCtr = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
                if (oldCtr is null)
                    return false;
                oldCtr.Update(category);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
