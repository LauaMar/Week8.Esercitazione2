using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week8.Es1.Core.Models;
using Week8.Es1.MVC.Models;

namespace Week8.Es1.MVC.Helpers
{
    public static class MappingExtensions
    {
        public static ProductViewModel ToViewModel(this Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                ProductCode = product.ProductCode,
                Description = product.Description,
                BuyingPrice = product.BuyingPrice,
                SellingPrice = product.SellingPrice,
                Type = product.Type,
            };
        }
        public static IEnumerable<ProductViewModel> ToListViewModel(this IEnumerable<Product> products)
        {
            return products.Select(p => p.ToViewModel());
        }
        public static Product ToProduct (this ProductViewModel pwm)
        {
            return new Product
            {
                Id = pwm.Id,
                ProductCode = pwm.ProductCode,
                Description = pwm.Description,
                BuyingPrice = pwm.BuyingPrice,
                SellingPrice = pwm.SellingPrice,
                Type = pwm.Type,
            };
        }
        public static IEnumerable<SelectListItem> FromEnumToSelectList<T>() where T : struct //qui si usa il generico di tipo struct per poterlo
                                                                                             //usare con tutti gli enum (che è un tipo struct)
        {
            var step1 = Enum.GetValues(typeof(T));
            var step2 = step1.Cast<T>();
            var step3 = step2.Select(e => new SelectListItem() { Text = e.ToString(), Value = e.ToString() });
            var step4 = step3.ToList();
            return step4;

            //return (Enum.GetValues(typeof(T))).Cast<T>().Select(e => new SelectListItem() { Text = e.ToString(), Value = e.ToString() }).ToList();
        }
    }
}
