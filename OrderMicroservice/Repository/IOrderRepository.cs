using OrderMicroservice.Models;

namespace OrderMicroservice.Repository
{
    public interface IOrderRepository
    {
        Order FindById(long orderId);
        void Place(Order order);
        void Delete(long orderId);
        void Save();
    }
}
