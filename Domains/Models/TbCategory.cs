

namespace Domains.Models;

public partial class TbCategory
{
    [Key]
    [ValidateNever]
    public int CategoryId { get; set; }

    [StringLength(30)]
    [Required(ErrorMessage ="You cannot add Category without a name")]
    public string CategoryName { get; set; } = null!;
    [ValidateNever]

    public string CreatedBy { get; set; } = null!;
    [ValidateNever]

    public DateTime CreatedDate { get; set; }

    public bool CurrentState { get; set; }
    [ValidateNever]

    public string ImageName { get; set; } = null!;

    public bool ShowInHomePage { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<TbItem> TbItems { get; set; } = new List<TbItem>();
}

