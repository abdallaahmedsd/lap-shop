
namespace Domains.Models;

public partial class TbRAM
{
    [Key]
    public int RAMId { get; set; }
    [Range(1,512,ErrorMessage =("please enter ram size in range"))]
    [Required]
    public int ?RAMSize { get; set; } 

    public virtual ICollection<TbItem> Items { get; set; } = new List<TbItem>();
}