
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace LapShop.ChangeTracking.Data.Config
{
    public class ProcessorConfiguration : IEntityTypeConfiguration<TbProcessor>
    {
        public void Configure(EntityTypeBuilder<TbProcessor> builder)
        {
            builder.HasKey(x => x.ProcessorId);

            builder.Property(x => x.ProcessorName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(250).IsRequired();

            builder.ToTable("TbProcessors");
            // Seed data
            builder.HasData(
                new TbProcessor { ProcessorId = 1, ProcessorName = "Intel Core i9-13900K" },
                new TbProcessor { ProcessorId = 2, ProcessorName = "AMD Ryzen 9 7950X" },
                new TbProcessor { ProcessorId = 3, ProcessorName = "Intel Core i7-13700K" },
                new TbProcessor { ProcessorId = 4, ProcessorName = "AMD Ryzen 7 7800X" },
                new TbProcessor { ProcessorId = 5, ProcessorName = "Intel Core i5-13600K" },
                new TbProcessor { ProcessorId = 6, ProcessorName = "AMD Ryzen 5 7600X" },
                new TbProcessor { ProcessorId = 7, ProcessorName = "Intel Core i3-13100" },
                new TbProcessor { ProcessorId = 8, ProcessorName = "AMD Ryzen 3 7300X" },
                new TbProcessor { ProcessorId = 9, ProcessorName = "Intel Xeon W-3375" },
                new TbProcessor { ProcessorId = 10, ProcessorName = "AMD Threadripper 3990X" }
            );
        }
    }
}