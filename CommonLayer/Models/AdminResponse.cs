using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace oreoApplicationCommonLayer.Models
{
    public class AdminResponse
    {
        public int AdminId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        public string Role { get; set; }
    }
}
