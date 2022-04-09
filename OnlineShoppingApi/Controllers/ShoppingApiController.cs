using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ShoppingApiModal;
using ShoppingApiService.Interface;

namespace OnlineShoppingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingApiController : Controller
    {
        public readonly IProductService _productService;
        public ShoppingApiController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetProducts")]
        public List<ProductModal> GetProducts()
        {
            return _productService.FetchProducts();
        }

        [HttpPost("AddProduct")]
        public bool AddProduct([FromForm] ProductModal ProductDetails)
        {
            bool AddProductStatus = false;
            if(ProductDetails.Name != null && ProductDetails.AvailableQuantity > 0 && ProductDetails.Price > 0)
            {
                AddProductStatus = _productService.CreateProduct(ProductDetails);
            }
            return AddProductStatus;
        }

        [HttpPut("UpdateProductQuantity")]
        public bool UpdateProductQuantity([FromForm] string Name, int Quantity)
        {
            bool UpdateProductQuantityStatus = false;
            if (Name != null && Quantity > 0)
            {
                UpdateProductQuantityStatus = _productService.ModifyProductQuantity(Name, Quantity);
            }
            return UpdateProductQuantityStatus;
        }

        [HttpDelete("DeleteProduct/{Name}")]
        public bool DeleteProduct(string Name)
        {
            bool DeleteProductStatus = false;
            if (Name != null)
            {
                DeleteProductStatus = _productService.RemoveProduct(Name);
            }
            return DeleteProductStatus;
        }
    }
}
