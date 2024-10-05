using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LapShop.ChangeTracking.Data.Config
{
	public class BusinessInfoConfiguration : IEntityTypeConfiguration<TbBusinessInfo>
    {
        public void Configure(EntityTypeBuilder<TbBusinessInfo> builder)
        {
            builder.HasKey(e => e.BusinessInfoId);

            builder.ToTable("TbBusinessInfo");

            builder.HasIndex(e => e.CutomerId, "IX_TbBusinessInfo_CutomerId").IsUnique();

            builder.Property(e => e.Budget).HasColumnType("decimal(8, 2)");
            builder.Property(e => e.BusinessCardNumber).HasMaxLength(20);

            builder.HasOne(d => d.Cutomer).WithOne(p => p.TbBusinessInfo).HasForeignKey<TbBusinessInfo>(d => d.CutomerId);
       
        }


    }

}
