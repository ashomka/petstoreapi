using System.Collections.Generic;

namespace ProductMicroservice.Models
{
    public enum InventoryStatus { Available, Pending, Sold }
    public class Pet
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CategoryId { get; set; }
        public List<Tag> Tags { get; set; }
        public InventoryStatus Status { get; set; }
    }
}
