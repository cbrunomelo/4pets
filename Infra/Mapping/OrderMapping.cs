using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Mapping
{
    internal class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("TB_ORDER");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Total).IsRequired();
            builder.HasOne(x => x.Client).WithMany(x => x.Orders);
            builder.HasMany( x => x.Itens).WithOne(x => x.Order);
            builder.HasOne(x => x.History).WithOne(x => x.Order).HasForeignKey<History>(x => x.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
