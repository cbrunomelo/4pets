using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class Order : Entity
    {
        public DateTime Date { get; private set; }
        public decimal Total { get; private set; }
        public List<OrderItem> Itens { get; private set; }
        public int ClientId { get; private set; }
        public Client Client { get; private set; }

        private Order()
        {            
        }
        internal Order(List<OrderItem> itens, int clientId)
        {
            Date = DateTime.Now;
            Itens = itens;
            ClientId = clientId;
            SetTotal();
        }

        internal void SetClient(Client client)
        {
            Client = client;
            ClientId = client.Id;
        }
        
        internal void SetTotal() => Total = Itens.Sum(x => x.Total);

        public void SetId(int id) => Id = id;

        public override Entity Clone()
        {
            var itens = new List<OrderItem>();
            foreach (var item in Itens)
            {
                itens.Add(new OrderItem(item.Product, item.Quantity));
            }
            return new Order(itens, ClientId);
        }
    }
}
