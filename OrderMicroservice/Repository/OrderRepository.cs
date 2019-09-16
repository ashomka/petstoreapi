using OrderMicroservice.DBContexts;
using OrderMicroservice.Models;
using OrderMicroservice.Repository;

namespace OrderMicroservice.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _dbContext;

        public OrderRepository(OrderContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(long orderId)
        {
            var order = _dbContext.Orders.Find(orderId);
            _dbContext.Orders.Remove(order);
            Save();
        }

        public Order FindById(long orderId)
        {
            return _dbContext.Orders.Find(orderId);
        }


        public void Place(Order order)
        {
            _dbContext.Add(order);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
