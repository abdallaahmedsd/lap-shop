
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LapShop.ChangeTracking.Data.Config
{
    public class ItemConfiguration : IEntityTypeConfiguration<TbItem>
    {
        public void Configure(EntityTypeBuilder<TbItem> builder)
        {
            builder.HasKey(e => e.ItemId);

            builder.HasIndex(e => e.ItemTypeId, "IX_TbItems_ItemTypeId");

            builder.HasIndex(e => e.OsId, "IX_TbItems_OsId");

            builder.Property(e => e.CreatedBy).HasDefaultValue("");
            builder.Property(e => e.CreatedDate).HasDefaultValue(new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));
            builder.Property(e => e.ImageName).HasMaxLength(200);
            builder.Property(e => e.ItemName).HasMaxLength(100);
            builder.Property(e => e.ItemTypeId).HasDefaultValue(0);
            builder.Property(e => e.OsId).HasDefaultValue(0);
            builder.Property(e => e.PurchasePrice).HasColumnType("decimal(8, 2)");
            builder.Property(e => e.SalesPrice).HasColumnType("decimal(8, 2)");

            builder.HasOne(d => d.Category).WithMany(p => p.TbItems)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbItems_TbCategories");

            builder.HasOne(d => d.ItemType).WithMany(p => p.TbItems)
                .HasForeignKey(d => d.ItemTypeId)
                .HasConstraintName("FK_TbItems_TbItemTypes").IsRequired();

            builder.HasOne(d => d.Os).WithMany(p => p.TbItems)
                .HasForeignKey(d => d.OsId)
                .HasConstraintName("FK_TbItems_TbOs")
                              .IsRequired();

            builder.HasOne(d => d.GPU)
                  .WithMany(g => g.Items)
                  .HasForeignKey(d => d.GPUId).HasConstraintName("FK_TbItems_TbGPUs")
                  .IsRequired();

            builder.HasOne(d => d.Processor)
                 .WithMany(g => g.Items)
                 .HasForeignKey(d => d.ProcessorId).HasConstraintName("FK_TbItems_TbProcessors")
                 .IsRequired();
            builder.HasOne(d => d.HardDisk)
                 .WithMany(g => g.Items)
                 .HasForeignKey(d => d.HardDiskId).HasConstraintName("FK_TbItems_TbHardDisks")
                 .IsRequired();
            builder.HasOne(d => d.ScreenResolution)
              .WithMany(g => g.Items)
              .HasForeignKey(d => d.ScreenResolutionId).HasConstraintName("FK_TbItems_ScreenResolutions")
              .IsRequired();

            builder.HasOne(d => d.RAM)
            .WithMany(g => g.Items)
            .HasForeignKey(d => d.RAMId).HasConstraintName("FK_TbItems_TbRAMs")
            .IsRequired(false);

            builder.Property(x => x.IsDeleted).IsRequired();

            builder.HasQueryFilter(x => x.IsDeleted == false); //When its value is false bring it back..

            builder.Property(e => e.GPUId).HasColumnName("GPUId").HasColumnType("INT");

            builder.HasMany(d => d.Customers).WithMany(p => p.Items)
                .UsingEntity<Dictionary<string, object>>(
                    "TbCustomerItem",
                    r => r.HasOne<TbCustomer>().WithMany().HasForeignKey("CustomerId"),
                    l => l.HasOne<TbItem>().WithMany().HasForeignKey("ItemId"),
                    j =>
                    {
                        j.HasKey("ItemId", "CustomerId");
                        j.ToTable("TbCustomerItems");
                        j.HasIndex(new[] { "CustomerId" }, "IX_TbCustomerItems_CustomerId");
                    });

        }
    }
}



