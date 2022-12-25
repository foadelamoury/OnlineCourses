using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("Image");

        builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
        builder.Property(e => e.CreateDate)
                  .HasColumnType("datetime")
                  .HasDefaultValueSql("(getdate())").HasColumnOrder(1);


        builder.Property(e => e.ModifyDate).HasColumnType("datetime").HasColumnOrder(2);



        builder.Property(e => e.Name)
                  .IsRequired();


        builder.Property(e => e.ParentId)
                  .IsRequired();

        builder.Property(e => e.ParentTableName)
                 .IsRequired();
    }
}