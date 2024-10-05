
namespace Domains.Models;

public partial class TbHardDisk
{
    [Key]
    public int HardDiskId { get; set; }

    public string HardDiskName { get; set; } = null!;

    public virtual ICollection<TbItem> Items { get; set; } = new List<TbItem>();
}
