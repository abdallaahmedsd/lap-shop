namespace Domains.Models;

public partial class TbGPU
{
    [Key]
    public int GPUId { get; set; }

    public string GPUName { get; set; } = null!;

    public virtual ICollection<TbItem> Items { get; set; } = new List<TbItem>();
}

