using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace oreoApplicationCommonLayer.Models
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public double ActualPrice { get; set; }
        [Required]
        public double DiscountedPrice { get; set; }
        [Required]
        public int ProductQuantity { get; set; }
        [Required]
        public string ProductImage { get; set; }

        //public bool AddedToCart { get; set; }
    }
}
