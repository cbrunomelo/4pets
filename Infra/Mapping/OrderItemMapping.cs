﻿using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Mapping
{
    internal class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("TB_ORDER_ITEM");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Total).IsRequired();
            builder.HasOne(x => x.Product).WithMany(x => x.OrderItems).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Order).WithMany(x => x.Itens).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.History).WithOne(x => x.OrderItem).HasForeignKey<History>(x => x.OrderItemId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
