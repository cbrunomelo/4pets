﻿using System;
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
        public Category? Category { get; private set; }
        public int? CategoryId { get; set; }
        public List<OrderItem> OrderItems { get; private set; }
        //public int StockId { get; private set; }
        public Stock? Stock { get; set; }
        public Product(string name, decimal price, string description, int? categoryid)
        {
            Name = name;
            Price = price;
            Description = description;
            CategoryId = categoryid;
        }

        private Product()
        {
        }

        internal void SetCategory(Category category)
        {
            Category = category;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public void Update(string name, decimal price, string description, int categoryId)
        {
            Name = name;
            Price = price;
            Description = description;
            CategoryId = categoryId;
        }


        public override Entity Clone()
        {
            var product = new Product();
            product.Name = Name;
            product.Price = Price;
            product.Description = Description;
            product.CategoryId = CategoryId;
            product.Id = Id;
            return product;

        }
    }
}
