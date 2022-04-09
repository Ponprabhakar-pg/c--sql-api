
using System.ComponentModel.DataAnnotations;
using MongoDB.Driver;

namespace ShoppingApiRepository.MongoEntity
{
    public class MongoEntityProductModal
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public int AvailableQuantity { get; set; }
        public int Price { get; set; }
    }
}
