using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Es1.Core.Interfaces;
using Week8.Es1.Core.Models;

namespace Week8.Es1.Core
{
    public class MainBusinessLayer : IMainBusinessLayer
    {
        private readonly IProductRepository _repoPr;
        public MainBusinessLayer(IProductRepository repository)
        {
            _repoPr = repository;
        }

        public ResultBL CreateProduct(Product newProd)
        {
            if (newProd == null)
                return new ResultBL (false, "Invalid Product data." );
            var output = _repoPr.AddItem(newProd);
            return new ResultBL(output, output ? "OK!" : "Sorry, something went wrong...");
        }

        public ResultBL DeleteProductById(int id)
        {
            if (id <= 0)
                return new ResultBL(false, "Invalid Product id");

            var output = _repoPr.DeleteItemById(id);
            if (!output)
                return new ResultBL(output, "Something went wrong...");

            return new ResultBL(output, "Ok!");
        }

        public ResultBL EditProduct(Product modifiedProd)
        {
            if (modifiedProd == null)
                return new ResultBL(false, "Invalid product data.");

            var output = _repoPr.UpdateItem(modifiedProd);
            return new ResultBL(output, output ? "OK!" : "Something went wrong...");
        }

        public Product FetchProductByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                return null;

            return _repoPr.GetByCode(code);
        }

        public Product FetchProductById(int id)
        {
            if (id <= 0)
                return null;

            return _repoPr.GetById(id);
        }

        public IEnumerable<Product> FetchProducts(Func<Product, bool> filter = null)
        {
            return _repoPr.Fetch(filter);
        }
    }
}
