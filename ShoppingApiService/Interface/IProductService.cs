using ShoppingApiModal;
using System.Collections.Generic;

namespace ShoppingApiService.Interface
{
    public interface IProductService
    {
        public List<ProductModal> FetchProducts();
        public bool CreateProduct(ProductModal ProductDetails);
        public bool ModifyProductQuantity(string Name, int Quantity);
        public bool RemoveProduct(string Name);
    }
}
