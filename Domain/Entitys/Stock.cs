using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class Stock : Entity
    {
        public Stock(){}
        public string Name { get; private set; }       
        public decimal Quantity { get; private set; }
        public decimal AvaragePrice { get; private set; }
        public decimal TotalValue { get; private set; }
        public Product Product { get; private set; }
        public int ProductId {
            get {
                if (Product is null)
                    return 0;
                return Product.Id;
            }
            set { } }
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
            
        
        public void DecreaseStock(decimal quantity)
        {
            Quantity -= quantity;
            TotalValue -= quantity * AvaragePrice;
        }

        internal void Entry(decimal quantity, decimal totalValue)
        {
            Quantity += quantity;
            TotalValue += totalValue;
            AvaragePrice = TotalValue / Quantity;
        }

        public override Entity Clone() => new Stock(Name, Quantity, AvaragePrice, TotalValue, Product);
        
    }
}
