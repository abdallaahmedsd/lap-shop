namespace LapShop.Models
{
    public class ShoppingCartItem
    {
        public int ItemId {  get; set; }

        public string ItemName { get; set; } = null!;

        public string ImgaeName { get; set; } = null!;

        public int Qty { get; set; }

        public decimal Price { get; set; }

        public decimal Total =>Math.Round( Qty * Price,3);
    }
}
