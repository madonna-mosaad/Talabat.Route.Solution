using Core.Layer.Order_Aggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Layer.Data.Configrations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o=>o.Status).HasConversion(s=>s.ToString(),s=>(Status)Enum.Parse(typeof(Status),s));
            builder.OwnsOne(o => o.ShappingAddress, ShappingAddress => ShappingAddress.WithOwner());
            builder.Property(o => o.SubTotal).HasColumnType("decimal(18,2)");
            builder.HasOne(o=>o.DeliveryMethod).WithMany().HasForeignKey(o=>o.DeliveryMethodId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
