using Domain.Entitys.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class History
    {
        public History()
        {
            
        }
        public History(Entity entity, int userId)
        {
            UserId = userId;
            CreateDate = DateTime.Now;
            setEntity(entity);
        }

        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public OrderItem OrderItem { get; set; }
        public int OrderItemId { get; set; }
        public Stock Stock { get; set; }
        public int StockId { get; set; }
        public List<HistoryField> Fields { get; set; } = new List<HistoryField>();

        private void setEntity(Entity entity)
        {
            Dictionary<Type, Action> Dictionary = new Dictionary<Type, Action>
            {
                { typeof(User), () => { UserId = entity.Id; } },
                { typeof(Category), () => { CategoryId = entity.Id; } },
                { typeof(Client), () => { ClientId = entity.Id; } },
                { typeof(Product), () => { ProductId = entity.Id; } },
                { typeof(Order), () => { OrderId = entity.Id; } },
                { typeof(OrderItem), () => { OrderItemId = entity.Id; } },
                { typeof(Stock), () => { StockId = entity.Id; } },

            };
        }

    }
}