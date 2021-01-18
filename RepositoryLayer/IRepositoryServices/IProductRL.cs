using oreoApplicationCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace oreoApplicationRepositoryLayer.IRepositoryServices
{
    public interface IProductRL
    {
        List<Product> GetAllProducts();
        bool AddProduct(Product products);
        bool RemoveProduct(Product products);
    }
}
