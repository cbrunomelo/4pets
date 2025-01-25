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
    internal class HistoryMapping : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.ToTable("TB_HISTORY");
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Fields).WithOne(x => x.History);
            builder.HasOne(x => x.Category).WithOne(x => x.History).OnDelete(DeleteBehavior.NoAction);



        }
    }
}
