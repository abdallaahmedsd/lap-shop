
using BusinessLib.Bl;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace LapShop.ChangeTracking.Data.Config
{
	public class RolePremissionConfiguration : IEntityTypeConfiguration<ApplicationRole>
	{
		public void Configure(EntityTypeBuilder<ApplicationRole> builder)
		{

			builder.ToTable("AspNetRoles");


            builder.Property(e => e.RolePremssions).HasConversion(
                v => JsonConvert.SerializeObject(v),//Convert to json string from stroage
                v => JsonConvert.DeserializeObject<Dictionary<string, object>>(v));//Convert back to Dictionary


            builder.Property(e => e.RolePremssions).HasColumnType("VARCHAR(MAX)");

            builder.Property(e => e.RolePremssions).IsRequired();

		}


	}

}
