using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace LapShop.ChangeTracking.Data.Config
{
    public class GPUConfiguration : IEntityTypeConfiguration<TbGPU>
    {
        public void Configure(EntityTypeBuilder<TbGPU> builder)
        {
            builder.HasKey(x => x.GPUId);

            builder.Property(x => x.GPUName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(250).IsRequired();

            builder.ToTable("TbGPUs");

        }
    }
}