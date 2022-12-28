using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
{
    public void Configure(EntityTypeBuilder<StudentCourse> builder)
    {

        builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();


        builder.Property(e => e.CourseId)
                  ;


        builder.Property(e => e.StudentId);

        builder.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())").HasColumnOrder(1);


        builder.Property(e => e.ModifyDate).HasColumnType("datetime").HasColumnOrder(2);
    }
}
