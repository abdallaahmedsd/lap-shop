

using BusinessLib.Bl.Contract;
using LapShop.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Identity.Client;
using System;

namespace LapShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemViewService<VwItem> _clsViewItem;
        private readonly ISpecialGetFeature<TbItemImage> _clsItemImage;

        public HomeController(IItemViewService<VwItem> viewItemService,
             ISpecialGetFeature<TbItemImage> ItemImageService)
        {
            _clsViewItem = viewItemService;
            _clsItemImage = ItemImageService;

        }
        public IActionResult Index()
        {
            VmHomePage vm=new VmHomePage();

            _LoadData(vm);

            return View(vm);

        }

        public IActionResult Details(int? entityId)
        {

            if (entityId != null) 
            {

                VwItem  viewItem= _clsViewItem.GetItemViewById(Convert.ToInt32(entityId));
                List<TbItemImage>   lstItemImages=_clsItemImage.GetAllById(Convert.ToInt32(entityId)).ToList();
                List<VwItem> lstRelatedItems = _clsViewItem.GetRelatedItems(viewItem.SalesPrice,6);
                
                if (viewItem is null || lstItemImages is null|| lstRelatedItems is null) {

                    return NotFound(); // Handle cases where data isn't found
                }

                ViewItemDetails ViewItemDetailsViewModel = new ViewItemDetails
                {
                    VwItem = viewItem,
                    lstItemImages = lstItemImages,
                    lstRelatedItems = lstRelatedItems
                };

                if (entityId.HasValue)
                {
                    //_clsViewItem.
                    return View("Details", ViewItemDetailsViewModel);

                }

            }

           
            return RedirectToAction("Index");

        }
        private void _LoadData(VmHomePage vm)
        {
    
            vm.lstSpecialOfferItems = _clsViewItem.GetSpecialOfferItems();
            vm.lstRecommendedItems = _clsViewItem.GetRecommendItems();
            vm.lstNewItems = _clsViewItem.GetNewItems();
            vm.lstFreeDelivery = _clsViewItem.GetFreeDeliveryItems();
        }
        [HttpGet]
        private IEnumerable<VwItem> GetSpecialOfferItems(VmHomePage vm, int page ,int pageSize=4)
        {
           return vm.lstSpecialOfferItems = _clsViewItem.GetSpecialOfferItems();

        }
    }
}
