namespace Domain.Repository
{
    public interface IStockRepository
    {
        void DecreaseStock(int productId, int quantity);
    }
}