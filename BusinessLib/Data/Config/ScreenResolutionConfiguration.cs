
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace LapShop.ChangeTracking.Data.Config
{
    public class ScreenResolutionConfiguration : IEntityTypeConfiguration<TbScreenResolution>
    {
        public void Configure(EntityTypeBuilder<TbScreenResolution> builder)
        {
            builder.HasKey(x => x.ScreenResolutionId);

            builder.Property(x => x.ScreenResolutionName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(250).IsRequired();

            builder.ToTable("TbScreenResolutions");
        
            builder.HasData(
              new TbScreenResolution { ScreenResolutionId = 1, ScreenResolutionName=  "Full HD (1920x1080)" },
              new TbScreenResolution { ScreenResolutionId = 2, ScreenResolutionName = "Quad HD (2560x1440)" },
              new TbScreenResolution { ScreenResolutionId = 3, ScreenResolutionName = "4K Ultra HD (3840x2160)" },
              new TbScreenResolution { ScreenResolutionId = 4, ScreenResolutionName = "HD (1366x768)" },
              new TbScreenResolution { ScreenResolutionId = 5, ScreenResolutionName = "HD+ (1600x900)" },
              new TbScreenResolution { ScreenResolutionId = 6, ScreenResolutionName = "HD Ready (1280x720)" },
              new TbScreenResolution { ScreenResolutionId = 7, ScreenResolutionName = "WUXGA (1920x1200)" },
              new TbScreenResolution { ScreenResolutionId = 8, ScreenResolutionName = "WQXGA (2560x1600)" },
              new TbScreenResolution { ScreenResolutionId = 9, ScreenResolutionName = "Ultrawide Quad HD (3440x1440)" },
              new TbScreenResolution { ScreenResolutionId = 10,ScreenResolutionName = "Super UltraWide (5120x1440)" }
            );

        }

    }

}