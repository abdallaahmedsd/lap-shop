
using System.ComponentModel.DataAnnotations.Schema;

namespace Domains.Models;

public partial class VwItem
{
    public string ItemName { get; set; } = null!;

    public decimal PurchasePrice { get; set; }

    public decimal SalesPrice { get; set; }

    public int CategoryId { get; set; }

    public string? ImageName { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public int CurrentState { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Description { get; set; }

    public int  GPUId { get; set; }
    public string? GPUName{ get; set; }
    public int? HardDiskId { get; set; }

    public string? HardDisk { get; set; }

    public int? ItemTypeId { get; set; }
    public int? ProcessorId{ get; set; }

    public string? Processor { get; set; }

    public int? RAMId { get; set; }
    public int? RAMSize { get; set; }
      public bool IsDeleted { get; set; }
    public int? ScreenResolutionId{ get; set; }

    public string? ScreenResolution { get; set; }

    public string? ScreenSize { get; set; }

    public string? Weight { get; set; }

    public int? OsId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string ItemTypeName { get; set; } = null!;

    public string OsName { get; set; } = null!;

    public int ItemId { get; set; }

    [NotMapped]
	public decimal DiscountPercentageValue
	{
		get
		{
			// Calculate the discount value
			decimal discountValue =  SalesPrice- PurchasePrice;
            if (discountValue < 0)
            {
                discountValue = 10;
            }
            if (PurchasePrice <=0) {
                PurchasePrice = 1;
            }
			// Calculate the discount percentage and ensure it's positive
			decimal discountPercentage = Math.Abs(discountValue / PurchasePrice * 100);

			// Round down to the nearest whole number
			return Math.Floor(discountPercentage);
		}
	}


}
