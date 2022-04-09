using System.ComponentModel.DataAnnotations;

namespace ShoppingApiRepository.SqlEntity
{
    public class SqlEntityProductModal
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public int AvailableQuantity { get; set; }
        public int Price { get; set; }
    }
}
