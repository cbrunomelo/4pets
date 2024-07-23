using Domain.Entitys;

namespace Domain.Repository
{
    public interface IOrderItemRepository
    {
        List<OrderItem> LoadProductsWithStock(List<OrderItem> itens);
    }
}