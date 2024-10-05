
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace LapShop.ChangeTracking.Data.Config
{
    public class RAMConfiguration : IEntityTypeConfiguration<TbRAM>
    {
        public void Configure(EntityTypeBuilder<TbRAM> builder)
        {
            builder.HasKey(x => x.RAMId);

            builder.Property(x => x.RAMSize)
                .HasColumnType("INT")
                .IsRequired(false);

            builder.ToTable("TbRAMs");
            builder.HasData(
              new TbRAM { RAMId = 1, RAMSize = 2},
              new TbRAM { RAMId = 2, RAMSize = 4},
              new TbRAM { RAMId = 3, RAMSize = 8},
              new TbRAM { RAMId = 4, RAMSize = 16},
              new TbRAM { RAMId = 5, RAMSize = 32},
              new TbRAM { RAMId = 6, RAMSize = 64},
              new TbRAM { RAMId = 7, RAMSize = 128 },
              new TbRAM { RAMId = 8, RAMSize = 261 }

          );
        }
    }
}