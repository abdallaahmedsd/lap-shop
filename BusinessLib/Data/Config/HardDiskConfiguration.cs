
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace LapShop.ChangeTracking.Data.Config
{
    public class HardDiskConfiguration : IEntityTypeConfiguration<TbHardDisk>
    {
        public void Configure(EntityTypeBuilder<TbHardDisk> builder)
        {
            builder.HasKey(x => x.HardDiskId);

            builder.Property(x => x.HardDiskName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(250).IsRequired();

            builder.ToTable("TbHardDisks");
            builder.HasData(
              new TbHardDisk { HardDiskId = 1, HardDiskName = "Samsung 970 EVO Plus 1TB NVMe M.2" },
              new TbHardDisk { HardDiskId = 2, HardDiskName = "Western Digital Blue 1TB 7200 RPM SATA" },
              new TbHardDisk { HardDiskId = 3, HardDiskName = "Seagate Barracuda 2TB 7200 RPM SATA" },
              new TbHardDisk { HardDiskId = 4, HardDiskName = "Crucial MX500 500GB 3D NAND SATA 2.5 Inch" },
              new TbHardDisk { HardDiskId = 5, HardDiskName = "Samsung 860 EVO 500GB 2.5 Inch SATA" },
              new TbHardDisk { HardDiskId = 6, HardDiskName = "WD Black SN750 1TB NVMe M.2" },
              new TbHardDisk { HardDiskId = 7, HardDiskName = "Toshiba X300 4TB 7200 RPM SATA" },
              new TbHardDisk { HardDiskId = 8, HardDiskName = "Kingston A2000 1TB NVMe M.2" },
              new TbHardDisk { HardDiskId = 9, HardDiskName = "Seagate FireCuda 2TB SSHD SATA" },
              new TbHardDisk { HardDiskId = 10,HardDiskName = "WD Blue 2TB SATA 2.5 Inch" }
          );
        }
    }
}