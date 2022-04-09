using System.Collections.Generic;
using ShoppingApiRepository.SqlEntity;

namespace ShoppingApiRepository.Interface
{
     public interface ISqlProductRepository
    {
        public List<SqlEntityProductModal> GetProducts();
        public bool AddProduct(SqlEntityProductModal EntityProductDetails);
        public bool UpdateProductQuantity(string Name, int Quantity);
        public bool DeleteProduct(string Name);
    }
}
