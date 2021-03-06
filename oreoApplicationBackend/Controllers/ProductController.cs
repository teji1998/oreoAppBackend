﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using oreoApplicationBusinessLayer.IBusinessService;
using oreoApplicationCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oreoApplicationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductBL productBL;
        IConfiguration configuration;

        public ProductController(IProductBL productBL,IConfiguration configuration)
        {
            this.productBL = productBL;
            this.configuration = configuration;
        }

        [HttpGet()]
        [Authorize(Roles = "Admin,User")]

        public IActionResult GetAllProducts()
        {
            try
            {
                List<Product> productList = this.productBL.GetAllProducts();
                if (productList != null)
                {
                    return this.Ok(new { Success = true, Message="Product records obtained successfully", data = productList });
                }
                else
                {
                    return this.NotFound(new { Success = false, Message = "Product records obtaining unsuccessful" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        [HttpPost("Add")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddProducts(Product products)
        {
            try
            {
                if (this.productBL.AddProduct(products))
                {
                    return this.Ok(new { Success = true, Message = "Products was added successfully !!!" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Success = false, Message = "Sorry, product was not added  !!!!" });
                }
            }
            catch (Exception exception)
            {

                if (exception != null)
                {
                    return StatusCode(StatusCodes.Status409Conflict,
                        new { Success = false, ErrorMessage = "Sorry, can't add duplicate products" });
                }
                else
                {
                    return this.BadRequest(new { success = false, Message = exception.Message });
                }

            }
        }

        [HttpPost("Remove")]
        public IActionResult RemoveProduct(Product products)
        {
            try
            {
                if (this.productBL.RemoveProduct(products))
                {
                    return this.Ok(new { success = true, Message = "Products Removed successfully" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Success = false, Message = "product record is not removed " });
                }
            }
            catch (Exception exception)
            {

                if (exception != null)
                {
                    return StatusCode(StatusCodes.Status409Conflict,
                        new { Success = false, ErrorMessage = "Cannot insert duplicate products" });
                }
                else
                {
                    return this.BadRequest(new { success = false, Message = exception.Message });
                }

            }
        }

    }
}
  
