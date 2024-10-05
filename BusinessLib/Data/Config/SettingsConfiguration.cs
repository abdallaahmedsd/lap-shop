using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LapShop.ChangeTracking.Data.Config
{
    public class SettingsConfiguration : IEntityTypeConfiguration<TbSettings>
    {
        public void Configure(EntityTypeBuilder<TbSettings> builder)
        {

            builder.HasKey(x => x.Id);



        }
    
    }

}
