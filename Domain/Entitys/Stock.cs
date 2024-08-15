using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class Stock : Entity
    {
        public string Name { get; private set; }       
        public decimal Quantity { get; private set; }
        public decimal AvaragePrice { get; private set; }
        public decimal TotalValue { get; private set; }
        public Product Product { get; private set; }
        private List<Client> _clientObservers { get; set; }
        public IReadOnlyCollection<Client> ClientObservers => _clientObservers;
        public void setEntry(decimal quantity, decimal totalValue)
        {
            Quantity += quantity;
            TotalValue += totalValue;
            AvaragePrice = TotalValue / Quantity;
        }

        public void AttachObserver(Client client)
        {
            _clientObservers.Add(client);
        }

        public void DetachObserver(Client client)
        {
            _clientObservers.Remove(client);
        }

        public Stock(string name, decimal quantity, decimal avaragePrice, decimal totalValue, Product product)
        {
            Name = name;
            Quantity = quantity;
            AvaragePrice = avaragePrice;
            TotalValue = totalValue;
            Product = product;
            _clientObservers = new List<Client>();
        }       
            
        

    }
}
