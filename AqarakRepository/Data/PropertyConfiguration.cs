using AqarakCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqarakRepository.Data
{
    public class PropertyConfiguration : IEntityTypeConfiguration<MyProperty>
    {
        

        public void Configure(EntityTypeBuilder<MyProperty> builder)
        {
            builder.Property(x => x.PropertyType).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.LocationId).IsRequired();
            builder.Property(x => x.Size).IsRequired().HasColumnType("decimal(2,18)");
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.OwnerId);

        }
    }
}
