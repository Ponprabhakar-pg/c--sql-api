using System.Collections.Generic;
using ShoppingApiModal;
using ShoppingApiService.Interface;
using ShoppingApiRepository.Interface;
using ShoppingApiRepository.SqlEntity;
using AutoMapper;

namespace ShoppingApiService.Implementation
{
    public class ProductService : IProductService
    {
        public readonly ISqlProductRepository _productRepository;
        public readonly IMapper _mapper;
        public ProductService(ISqlProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public List<ProductModal> FetchProducts()
        {
            return _mapper.Map<List<ProductModal>>(_productRepository.GetProducts());
        }

        public bool CreateProduct(ProductModal ProductDetails)
        {
            ProductDetails.Id = ProductDetails.Name.ToLower().Replace(" ", "");
            return _productRepository.AddProduct(_mapper.Map<SqlEntityProductModal>(ProductDetails));
        }

        public bool ModifyProductQuantity(string Name, int Quantity)
        {
            return _productRepository.UpdateProductQuantity(Name, Quantity);
        }

        public bool RemoveProduct(string Name)
        {
            //ProductDetails.Id = ProductDetails.Name.ToLower().Replace(" ", "");
            return _productRepository.DeleteProduct(Name);
        }
    }
}
