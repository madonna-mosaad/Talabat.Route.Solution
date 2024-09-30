using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Layer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Layer.Data.Configrations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p=>p.Brand).WithMany().HasForeignKey(p=>p.ProductBrandId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Category).WithMany().HasForeignKey(p => p.ProductCategoryId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
        }
    }
}
