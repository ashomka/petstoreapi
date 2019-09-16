using System;

namespace OrderMicroservice.Models
{
    public enum OrderStatus { Placed, Approved, Delivered }
    public class Order
    {
        public long Id { get; set; }
        public long PetId { get; set; }
        public int Quantity { get; set; }
        public DateTime ShipDate { get; set; }
        public OrderStatus Status { get; set; }
        public bool Complete { get; set; }
    }
}
