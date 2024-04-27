using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    internal class Product : Entity
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public ProductCategory Category { get; private set; }

        internal Product(string name, decimal price, string description, ProductCategory category)
        {
            Name = name;
            Price = price;
            Description = description;
            Category = category;
        }

        internal void SetCategory(ProductCategory category)
        {
            Category = category;
        }

    }
}
