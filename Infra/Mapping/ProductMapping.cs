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
    internal class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("TB_PRODUCT");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
            builder.Property(x => x.CategoryId);
            builder.HasOne(x => x.Category).WithMany(List => List.Products).HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.History).WithOne(x => x.Product).HasForeignKey<History>(x => x.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
