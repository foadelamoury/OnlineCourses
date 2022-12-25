using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities");

        builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();

        builder.Property(e => e.CreateDate)
                      .HasColumnType("datetime")
                      .HasDefaultValueSql("(getdate())").HasColumnOrder(1);


        builder.Property(e => e.ModifyDate).HasColumnType("datetime").HasColumnOrder(2);



        builder.Property(e => e.Name)
                  .IsRequired();



    }
}