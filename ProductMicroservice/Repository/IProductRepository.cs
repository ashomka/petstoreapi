using ProductMicroservice.Models;
using System.Collections.Generic;

namespace ProductMicroservice.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Pet> GetByStatus(string status);
        Pet GetById(long product);
        void Insert(Pet product);
        void Delete(long productId);
        void Update(Pet product);
        void Save();
    }
}
