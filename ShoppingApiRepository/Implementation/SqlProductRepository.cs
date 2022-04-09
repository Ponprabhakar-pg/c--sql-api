using System.Collections.Generic;
using ShoppingApiRepository.SqlEntity;
using ShoppingApiRepository.Interface;
using System.Linq;
using System;

namespace ShoppingApiRepository.Implementation
{
    public class SqlProductRepository : ISqlProductRepository
    {
        public readonly SqlDbContext _sqlDbContext;

        public SqlProductRepository(SqlDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
        }
        public List<SqlEntityProductModal> GetProducts()
        {
            return _sqlDbContext.Products.ToList();
        }

        public bool AddProduct(SqlEntityProductModal EntityProductDetails)
        {
            bool AddProductStatus = true;
            try
            {
                _sqlDbContext.Products.Add(EntityProductDetails);
                _sqlDbContext.SaveChanges();
            }
            catch(Exception e)
            {
                AddProductStatus = false;
            }
            return AddProductStatus;
        }

        public bool UpdateProductQuantity(string Name, int Quantity)
        {
            bool UpdateProductQuantityStatus = true;
            try {
                var ProductDetails = _sqlDbContext.Products.FirstOrDefault(x=>x.Id == Name.ToLower().Replace(" ",""));
                ProductDetails.AvailableQuantity = Quantity;
                _sqlDbContext.SaveChanges();
            }
            catch(Exception e)
            {
                UpdateProductQuantityStatus = false;
            }
            return UpdateProductQuantityStatus;
        }

        public bool DeleteProduct(string Name)
        {
            bool DeleteProductStatus = true;
            try
            {
                var ProductDetails = _sqlDbContext.Products.FirstOrDefault(x => x.Id == Name.ToLower().Replace(" ", ""));
                _sqlDbContext.Remove(ProductDetails);
                _sqlDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                DeleteProductStatus = false;
            }
            return DeleteProductStatus;
        }



    }
}
