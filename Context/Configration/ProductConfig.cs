using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Context.Configration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductID);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(1000); // عدل الحد الأقصى حسب الحاجة

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.UnitsInStock)
                .IsRequired();

            builder.Property(p => p.ImagePath)
                .HasMaxLength(300); // طول افتراضي لمسار الصورة

            //builder.HasOne(p => p.Category)
            //    .WithMany(c => c.Products)
            //    .HasForeignKey(p => p.CategoryID)
            //    .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(p => p.OrderDetails)
                .WithOne(od => od.Product)
                .HasForeignKey(od => od.ProductID);

            //builder.HasMany(p => p.CartItems)
            //    .WithOne(ci => ci.Product)
            //    .HasForeignKey(ci => ci.ProductID);
        }
    }
}
