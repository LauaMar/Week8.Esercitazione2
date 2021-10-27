using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week8.Es1.Core;
using Week8.Es1.Core.Interfaces;
using Week8.Es1.Core.Models;
using Week8.Es1.MVC.Helpers;
using Week8.Es1.MVC.Models;

namespace Week8.Es1.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IMainBusinessLayer mainBL;
        public ProductsController(IMainBusinessLayer BL)
        {
            mainBL = BL;
        }
        public IActionResult Index()
        {
            var results = mainBL.FetchProducts();

            var vmResults = results.ToListViewModel();
            return View(vmResults);
        }

        public IActionResult Details(string code)
        {
            if (string.IsNullOrEmpty(code))
                return View("NotFound");

            var prod = mainBL.FetchProductByCode(code);
            if (prod == null)
                return View("Error");

            var prodMapped = prod.ToViewModel();
            return View(prodMapped);
        }

        public IActionResult Create()
        {
            var prodVM = new ProductViewModel();
            prodVM.Typologies = new List<SelectListItem>();
            int typologiesNumber = Enum.GetNames(typeof(Product.Typology)).Length;
            for (int i = 0; i <= typologiesNumber - 1; i++)
            {
                var typ = (Product.Typology)i;
                prodVM.Typologies.Add(new SelectListItem { Text = typ.ToString(), Value = i.ToString() });
            }
            return View(prodVM);
            //var tipologie = MappingExtensions.FromEnumToSelectList<Product.Typology>();
            //return View(tipologie);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model == null)
                return View("ExceptionError", new ResultBL(false, "error!"));
            Product newProd = model.ToProduct();

            var output = mainBL.CreateProduct(newProd);

            if (!output.Success)
                return View("ExceptionError", output);

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Edit(string code)
        {
            if (string.IsNullOrEmpty(code))
                return View("NotFound");

            var toBeEdited = mainBL.FetchProductByCode(code);
            if (toBeEdited == null)
                return View("Not Found");
            var prodVM = toBeEdited.ToViewModel();

            prodVM.Typologies = new List<SelectListItem>();
            int typologiesNumber = Enum.GetNames(typeof(Product.Typology)).Length;
            for (int i = 0; i <= typologiesNumber - 1; i++)
            {
                var typ = (Product.Typology)i;
                prodVM.Typologies.Add(new SelectListItem { Text = typ.ToString(), Value = i.ToString() });
            }
            return View(prodVM);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel prodVM)
        {
            if (!ModelState.IsValid)
                return View(prodVM);

            if (prodVM == null)
                return View("ExceptionError", new ResultBL(false, "error!"));

            Product editedProd = prodVM.ToProduct();

            var output = mainBL.EditProduct(editedProd);

            if (!output.Success)
                return View("ExceptionError", output);

            return View("Details", prodVM);

        }
        [Route("Products/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return View("ExceptionError", "Invalid product id");

            Product product = mainBL.FetchProductById(id);
            if (product == null)
                return View("NotFound");

            ProductViewModel prodVM = product.ToViewModel();

            return View("Delete", prodVM);
        }


        [HttpPost]
        public IActionResult DeletePost(int id, IFormCollection collection)
        {
            if (id<=0)
                return View("NotFound");

            var output = mainBL.DeleteProductById(id);

            if (!output.Success)
                return View("ExceptionError", output);

            var results = mainBL.FetchProducts();

            var vmResults = results.ToListViewModel();

            return View("Index", vmResults);

        }
    }
}
