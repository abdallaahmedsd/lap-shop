namespace Domains.Models;
public partial class TbItem : ISoftDeletable
{
    [ValidateNever]
    [Key]
    public int ItemId { get; set; }
    [Required(ErrorMessage = ("please enter element name"))]
    public string ItemName { get; set; } = null!;
    [Required(ErrorMessage = ("please fill the price"))]
    [DataType(DataType.Currency,ErrorMessage =("please enter currency"))]
    [Range(100,100000,ErrorMessage ="please enter price in system range")]
    public decimal SalesPrice { get; set; }
    [ValidateNever]
    [DataType(DataType.Currency, ErrorMessage = ("please enter currency"))]
    [Range(100, 100000, ErrorMessage = "please enter Purchase price in system range")]
    public decimal PurchasePrice { get; set; }
    [Required(ErrorMessage = ("please enter Category "))]
    public int CategoryId { get; set; }

    public string? ImageName { get; set; } = string.Empty;
    [ValidateNever]

    public DateTime CreatedDate { get; set; }
    [ValidateNever]

    public string CreatedBy { get; set; } = null!;

    public int CurrentState { get; set; }
    [ValidateNever]

    public string? UpdatedBy { get; set; }
    [ValidateNever]
    public DateTime? UpdatedDate { get; set; }
    [ValidateNever]

    public string? Description { get; set; }
    [Required(ErrorMessage = ("please enter GPU "))]

    public int? GPUId { get; set; }
    [Required(ErrorMessage = ("please enter HardDisk "))]

    public int? HardDiskId { get; set; }
    [Required(ErrorMessage = ("please enter ItemType "))]

    public int? ItemTypeId { get; set; }
    [Required(ErrorMessage = ("please enter Processor "))]

    public int? ProcessorId { get; set; }
    [Required(ErrorMessage = ("please enter RAM "))]

    public int ? RAMId { get; set; }
    public int? ScreenResolutionId { get; set; }
    [Required(ErrorMessage ="Size of element is required")]
    public string? ScreenSize { get; set; }

    public string? Weight { get; set; }
    [Required(ErrorMessage = ("please enter Os "))]

    public int? OsId { get; set; }

    public virtual TbCategory? Category { get; set; }

    public virtual TbItemType? ItemType { get; set; }

    public virtual TbOs? Os { get; set; }
    public virtual TbGPU? GPU { get; set; }
    public virtual TbProcessor? Processor { get; set; }
    public virtual TbHardDisk? HardDisk { get; set; }
    public virtual TbScreenResolution? ScreenResolution { get; set; }
    public virtual TbRAM? RAM { get; set; }

    public virtual ICollection<TbItemDiscount> TbItemDiscounts { get; set; } = new List<TbItemDiscount>();

    public virtual ICollection<TbItemImage> TbItemImages { get; set; } = new List<TbItemImage>();

    public virtual ICollection<TbPurchaseInvoiceItem> TbPurchaseInvoiceItems { get; set; } = new List<TbPurchaseInvoiceItem>();

    public virtual ICollection<TbSalesInvoiceItem> TbSalesInvoiceItems { get; set; } = new List<TbSalesInvoiceItem>();

    public virtual ICollection<TbCustomer> Customers { get; set; } = new List<TbCustomer>();
    public bool IsDeleted { get ; set ; }
    public DateTime? DateDeleted { get ; set; }

}
