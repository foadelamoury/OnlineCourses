using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");

            builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(e => e.CreateDate)
                      .HasColumnType("datetime")
                      .HasDefaultValueSql("(getdate())").HasColumnOrder(1);


            builder.Property(e => e.ModifyDate).HasColumnType("datetime").HasColumnOrder(2);




            builder.Property(e => e.NameA)
                      .IsRequired();

            builder.Property(e => e.NameE)
                      ;
        }
    }
}
