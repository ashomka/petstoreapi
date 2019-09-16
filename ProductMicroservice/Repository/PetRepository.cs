using Microsoft.EntityFrameworkCore;
using ProductMicroservice.DBContexts;
using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductMicroservice.Repository
{
    public class PetRepository : IProductRepository
    {
        private readonly ProductContext _dbContext;

        public PetRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(long productId)
        {
            var product = _dbContext.Pets.Find(productId);
            _dbContext.Pets.Remove(product);
            Save();
        }

        public Pet GetById(long productId)
        {
            return _dbContext.Pets.Find(productId);
        }

        public IEnumerable<Pet> GetByStatus(string status)
        {
            var result = new List<Pet>();
            InventoryStatus inventoryStatus;
            if (Enum.TryParse(status, out inventoryStatus))
                return _dbContext.Pets.Where(p => p.Status == inventoryStatus);
            return new List<Pet>();
        }

        public void Insert(Pet pet)
        {
            _dbContext.Add(pet);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Pet pet)
        {
            _dbContext.Entry(pet).State = EntityState.Modified;
            Save();
        }
    }
}
