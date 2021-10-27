using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Es1.Core.Models;

namespace Week8.Es1.Core.Interfaces
{
    public interface IMainBusinessLayer
    {
        IEnumerable<Product> FetchProducts(Func<Product, bool> filter = null);
        Product FetchProductById(int id);
        Product FetchProductByCode(string code);
        ResultBL CreateProduct(Product newProd);
        ResultBL EditProduct(Product modifiedProd);
        ResultBL DeleteProductById(int id);
    }
}
