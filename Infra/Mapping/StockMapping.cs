﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entitys;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
    public class StockMapping : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("TB_STOCK");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.AvaragePrice).IsRequired();
            builder.Property(x => x.TotalValue).IsRequired();
            builder.HasOne(x => x.Product).WithOne(x => x.Stock);//.HasForeignKey<Product>(x => x.StockId);
            builder.HasMany(x => x.ClientObservers).WithOne(x => x.Stock);
            builder.HasOne(x => x.History).WithOne(x => x.Stock).HasForeignKey<History>(x => x.StockId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
