using oreoApplicationBusinessLayer.IBusinessService;
using oreoApplicationCommonLayer.Models;
using oreoApplicationRepositoryLayer.IRepositoryServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace oreoApplicationBusinessLayer.BusinessService
{
    public class ProductBL : IProductBL
    {
        private readonly IProductRL productRL;

        public ProductBL(IProductRL productRL)
        {
            this.productRL = productRL;
        }


        public List<Product> GetAllProducts()
        {
            try
            {
                return this.productRL.GetAllProducts(); ;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool AddProduct(Product products)
        {
            try
            {
                return this.productRL.AddProduct(products);
            }
            catch (Exception e )
            {
                throw e;
            }
        }

        public bool RemoveProduct(Product products)
        {
            try
            {
                return this.productRL.RemoveProduct(products);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
