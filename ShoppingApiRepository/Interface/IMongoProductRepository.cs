using System.Collections.Generic;
using ShoppingApiRepository.MongoEntity;

namespace ShoppingApiRepository.Interface
{
    public interface IMongoProductRepository
    {
        public List<MongoEntityProductModal> GetProducts();
        public bool AddProduct(MongoEntityProductModal EntityProductDetails);
        public bool UpdateProductQuantity(string Name, int Quantity);
        public bool DeleteProduct(string Name);
    }
}
