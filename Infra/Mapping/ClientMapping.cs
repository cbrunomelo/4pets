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
    internal class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("TB_CLIENT");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(20);
            builder.HasOne(x => x.History).WithOne(x => x.Client).HasForeignKey<History>(x => x.ClientId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
