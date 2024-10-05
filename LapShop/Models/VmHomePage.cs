namespace LapShop.Models
{
    public class VmHomePage
    {
        public List<VwItem>lstSpecialOfferItems{ get; set; }
        public List<VwItem> lstRecommendedItems { get; set; } 
        public List<VwItem> lstNewItems { get; set; } 
        public List<VwItem> lstFreeDelivery { get; set; }
        public List<VwItemCategory> lstCategories { get; set; }
        public List<TbSlider > lstSliders { get; set; }
        public TbSettings TbSettings { get; set; }
        public VmHomePage()
        {
            lstSpecialOfferItems = new List<VwItem>();
            lstRecommendedItems = new List<VwItem>();
            lstNewItems = new List<VwItem>();
            lstFreeDelivery = new List<VwItem>();
            lstCategories = new List<VwItemCategory>();
        }

    }

}
