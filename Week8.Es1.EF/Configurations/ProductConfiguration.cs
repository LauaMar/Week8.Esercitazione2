using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Es1.Core.Models;

namespace Week8.Es1.EF.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.ProductCode).IsUnique();
            builder.Property(p => p.ProductCode)
                   .HasMaxLength(6)
                   .IsRequired();
            builder.Property(p => p.Description)
                    .HasMaxLength(400);
            builder.Property(p => p.BuyingPrice);
            builder.Property(p => p.SellingPrice);
            builder.Property(p => p.Type);

            builder.HasData(
                new Product
                {
                    Id = 1,
                    ProductCode = "EL001",
                    Description = "Laptop ASUS",
                    BuyingPrice = 1250.00m,
                    SellingPrice = 1549.99m,
                    Type = Product.Typology.Elettronica
                },
                new Product
                {
                    Id = 2,
                    ProductCode = "ABB001",
                    Description = "Jeans Levis donna",
                    BuyingPrice = 10m,
                    SellingPrice = 49.99m,
                    Type = Product.Typology.Abbigliamento
                });
        }
    }
}
