using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");

            builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(e => e.CreateDate)
                      .HasColumnType("datetime")
                      .HasDefaultValueSql("(getdate())").HasColumnOrder(1);


            builder.Property(e => e.ModifyDate).HasColumnType("datetime").HasColumnOrder(2);




            builder.Property(e => e.NameA)
                      .IsRequired();

            builder.Property(e => e.NameE)
                      ;


            builder.Property(e => e.CountryId).IsRequired();



        }
    }
}
