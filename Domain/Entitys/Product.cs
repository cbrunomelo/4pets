using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public Category Category { get; private set; }
        public int CategoryId { get; set; }

        public int StockId { get
                                 {
                                     if (Stock is not null)
                                         return Stock.Id;
                                     return 0;
                                 }

                            set { } }
        public Stock Stock { get; private set; }
        public Product(string name, decimal price, string description, int categoryid)
        {
            Name = name;
            Price = price;
            Description = description;
            CategoryId = categoryid;
        }

        internal void SetCategory(Category category)
        {
            Category = category;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public void SetStock(Stock stock)
        {
            Stock = stock;
        }

    }
}
