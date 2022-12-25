using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CourseCategoryConfiguration : IEntityTypeConfiguration<CourseCategory>
{
    public void Configure(EntityTypeBuilder<CourseCategory> builder)
    {
        builder.ToTable("CourseCategory");

        builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
        builder.Property(e => e.CreateDate)
                           .HasColumnType("datetime")
                           .HasDefaultValueSql("(getdate())").HasColumnOrder(1);


        builder.Property(e => e.ModifyDate).HasColumnType("datetime").HasColumnOrder(2);



        builder.Property(e => e.Name)
                  .IsRequired();
    }
}
