using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Es1.Core.Models;

namespace Week8.Es1.Core.Interfaces
{
    public interface IProductRepository: IRepository<Product>
    {
        Product GetByCode(string code);
    }
}
