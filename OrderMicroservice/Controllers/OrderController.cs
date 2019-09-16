using System;
using System.Collections.Generic;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.Models;
using OrderMicroservice.Repository;

namespace OrderMicroservice.Controllers
{
    [Route("store/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: store/Inventory
        [HttpGet("Inventory")]
        public IEnumerable<string> Get()
        {
            // consume "/pet/findByStatus" from ProductMicroservice
            throw new NotImplementedException();
        }

        // GET: store/Order/5
        [HttpGet("Order/{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            var order = _orderRepository.FindById(id);
            return new OkObjectResult(order);
        }

        // POST: store/Order
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            using (var scope = new TransactionScope())
            {
                _orderRepository.Place(order);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
            }
        }

        // DELETE: store/Order/5
        [HttpDelete("Order/{id}")]
        public IActionResult Delete(long id)
        {
            _orderRepository.Delete(id);
            return new OkResult();
        }
    }
}
