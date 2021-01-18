using oreoApplicationCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace oreoApplicationBusinessLayer.IBusinessService
{
    public interface IProductBL
    {
        List<Product> GetAllProducts();
        bool AddProduct(Product products);
        bool RemoveProduct(Product products);
    }
}
