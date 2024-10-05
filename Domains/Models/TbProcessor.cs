
namespace Domains.Models;

public partial class TbProcessor
{
    [Key]
    public int ProcessorId { get; set; }

    public string ProcessorName { get; set; } = null!;

    public virtual ICollection<TbItem> Items { get; set; } = new List<TbItem>();
}
