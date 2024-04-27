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
        public List<Product> Products { get; private set; }

        public int ClientId { get; private set; }
        public Client Client { get; private set; }

        internal Order(List<Product> products, int clientId)
        {
            Date = DateTime.Now;
            Products = products;
            ClientId = clientId;
            SetTotal();
        }

        internal void SetClient(Client client)
        {
            Client = client;
            ClientId = client.Id;
        }
        
        internal void SetTotal() => Total = Products.Sum(x => x.Price);
        

        internal void setId(int id) => Id = id;        
        


    }
}
