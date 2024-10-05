using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace LapShop.ChangeTracking.Data.Config
{
	public class FormConfiguration : IEntityTypeConfiguration<TbForms>
	{
		public void Configure(EntityTypeBuilder<TbForms> builder)
		{

			builder.ToTable("TbViewNames");

		
		}


	}

}
