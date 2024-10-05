
namespace Domains.Models;

public partial class TbScreenResolution
{
    [Key]
    public int ScreenResolutionId { get; set; }

    public string ScreenResolutionName { get; set; } = null!;

    public virtual ICollection<TbItem> Items { get; set; } = new List<TbItem>();
}