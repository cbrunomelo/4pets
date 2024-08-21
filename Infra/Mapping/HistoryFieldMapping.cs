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
    internal class HistoryFieldMapping : IEntityTypeConfiguration<HistoryField>
    {
        public void Configure(EntityTypeBuilder<HistoryField> builder)
        {
            builder.ToTable("TB_HISTORYFIELD");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Action).IsRequired().HasColumnType("int");
            builder.Property(x => x.FieldName).IsRequired().HasMaxLength(60).HasColumnType("varchar(60)");
            builder.Property(x => x.CurrentValue).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.HasOne(x => x.History).WithMany(x => x.Fields).HasForeignKey(x => x.HistoryId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
