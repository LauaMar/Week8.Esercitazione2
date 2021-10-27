using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Es1.Core.Interfaces;
using Week8.Es1.Core.Models;

namespace Week8.Es1.EF.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ProductContext ctx;
        public EFProductRepository(ProductContext context)
        {
            ctx = context;
        }
        public bool AddItem(Product item)
        {
            if (item == null)
                return false;

            ctx.Products.Add(item);
            ctx.SaveChanges();
            return true;

        }

        public bool DeleteItemById(int id)
        {
            if (id <= 0)
                return false;

            Product toBeDeleted = ctx.Products.Find(id);
            if (toBeDeleted == null)
                return false;

            ctx.Products.Remove(toBeDeleted);
            ctx.SaveChanges();
            return true;
        }

        public IEnumerable<Product> Fetch(Func<Product, bool> filter = null)
        {
            if (filter != null)
                return ctx.Products.Where(filter);

            return ctx.Products;
        }

        public Product GetByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                return null;

            return ctx.Products.SingleOrDefault(p => p.ProductCode == code);
        }

        public Product GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Products.Find(id);
        }

        public bool UpdateItem(Product updatedItem)
        {
            if (updatedItem == null)
                return false;

            ctx.Entry(updatedItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            ctx.SaveChanges();
            return true;
        }
    }
}
