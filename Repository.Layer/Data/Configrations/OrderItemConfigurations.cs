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
    public class OrderItemConfigurations : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            //will add columns of productOrderItem to OrderItem table
            builder.OwnsOne(OI => OI.productOrderItem, productOrderItem => productOrderItem.WithOwner());
            builder.Property(o => o.Price).HasColumnType("decimal(18,2)");
        }
    }
}
