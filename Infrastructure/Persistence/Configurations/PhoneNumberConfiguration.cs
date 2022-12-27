using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.ToTable("PhoneNumber");

            builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(e => e.CreateDate)
                      .HasColumnType("datetime")
                      .HasDefaultValueSql("(getdate())").HasColumnOrder(1);


            builder.Property(e => e.ModifyDate).HasColumnType("datetime").HasColumnOrder(2);




        builder.Property(e => e.number)
                      .IsRequired();

            builder.Property(e => e.StudentId).IsRequired();
    }
    }
}
