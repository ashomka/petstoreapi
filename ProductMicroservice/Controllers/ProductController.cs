using System.Collections.Generic;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Models;
using ProductMicroservice.Repository;

namespace ProductMicroservice.Controllers
{
    [Route("pet/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // GET: pet/findByStatus
        [HttpGet("findByStatus")]
        public IActionResult Get(string statusList)
        {
            List<Pet> result = new List<Pet>();
            string[] statuses = statusList.Split(new char[] {','});
            foreach (var status in statuses)
                result.AddRange(_productRepository.GetByStatus(status));

            return new OkObjectResult(result);
        }

        // GET: pet/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            var product = _productRepository.GetById(id);
            return new OkObjectResult(product);
        }

        // POST: pet/5
        [HttpPost("{id}")]
        public IActionResult Post(long id, [FromBody] string name, [FromBody] InventoryStatus status)
        {
            using (var scope = new TransactionScope())
            {
                var pet = _productRepository.GetById(id);
                pet.Name = name;
                pet.Status = status;
                _productRepository.Update(pet);
                scope.Complete();
                return new OkResult();
            }
        }

        // PUT: pet
        [HttpPut]
        public IActionResult Put([FromBody] Pet pet)
        {
            if (pet != null)
            {
                using (var scope = new TransactionScope())
                {
                    _productRepository.Insert(pet);
                    scope.Complete();
                    return CreatedAtAction(nameof(Get), new { id = pet.Id }, pet);
                }
            }
            return new NoContentResult();
        }

        // DELETE: pet/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _productRepository.Delete(id);
            return new OkResult();
        }
    }
}
