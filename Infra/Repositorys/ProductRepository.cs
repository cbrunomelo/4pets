using Domain.Entitys;
using Domain.Queries;
using Domain.Repository;
using Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorys
{
    public class ProductRepository : IProductRepository, IProductQuery
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
                throw;
            }
        }

        public void Delete(Product product)
        {
            try
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        public Product GetById(int id)
        {
            try
            {
                return _context.Products
                                .FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Product> GetProducts(int page, int pageSize)
        {
            IEnumerable<Product> products = new List<Product>();

            try
            {
                products = _context.Products
                    .Include(x => x.Category)
                    .Include(x => x.Stock)
                    .AsQueryable()
                    .Paginate(page, pageSize)
                    .ToList();

                return products;
            }
            catch (Exception ex)
            {
                return products;
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

                _context.OrderItems.Include(x => x.Product).ThenInclude(x => x.Stock).Where(x => itens.Select(x => x.ProductId).Contains(x.ProductId)).ToList();

            }
            catch (Exception ex)
            {
            }
        }

        public void Update(Product product)
        {
            try
            {
                var prod = _context.Products.FirstOrDefault(x => x.Id == product.Id);
                if (prod != null)
                {
                    prod.Update(product.Name, product.Price, product.Description, product.CategoryId.Value);
                    _context.SaveChanges();
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
