using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Week8.Es1.Core.Models.Product;

namespace Week8.Es1.MVC.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insert Code!")]
        [MaxLength(6, ErrorMessage = "Max 6 characters!")]
        [Display(Name ="Code")]
        public string ProductCode { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Typology")]
        public Typology Type { get; set; }
        [Required]
        [Display(Name ="Price")]
        public decimal SellingPrice { get; set; }
        [Display(Name ="Purchased at")]
        public decimal BuyingPrice { get; set; }

        public List<SelectListItem> Typologies { get; set; }

    }
}
