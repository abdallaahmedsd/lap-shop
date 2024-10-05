using Microsoft.AspNetCore.Mvc.Rendering;

namespace LapShop.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ItemsController : Controller
    {
        private readonly IBusinessInterface<TbCategory> _clsCategory;
        //private readonly clsItem _clsItem;
        private readonly IBusinessInterface<TbItem> _clsItem;
        private readonly IItemViewService<VwItem> _clsViewItem;
        private readonly IBusinessInterface<TbItemType>  _clsTypeItem;
        private readonly IBusinessInterface<TbOs> _clsOs;
        private readonly IBusinessInterface<TbGPU> _clsGPU;
        private readonly IBusinessInterface<TbProcessor> _clsProcessor;
        private readonly IBusinessInterface<TbHardDisk> _clsHardDisk;
        private readonly IBusinessInterface<TbScreenResolution> _clsScreenResolution;
        private readonly IBusinessInterface<TbRAM> _clsRAM;


        public ItemsController(IBusinessInterface<TbCategory> categoryService,
                              IBusinessInterface<TbItem> clsItemService,
                             IItemViewService<VwItem> clsViewItemService,
                             IBusinessInterface<TbItemType> itemTypeService,
                             IBusinessInterface<TbOs> osService,
                             IBusinessInterface<TbGPU> gpuService,
                             IBusinessInterface<TbProcessor> processorService,
                             IBusinessInterface<TbHardDisk> hardDiskService,
                             IBusinessInterface<TbScreenResolution> screenResolutionService,
                             IBusinessInterface<TbRAM> ramService)
        {
            _clsCategory = categoryService;
            _clsItem = clsItemService;
            _clsViewItem = clsViewItemService;
            //_clsItem = itemService;
            _clsTypeItem = itemTypeService;
            _clsOs = osService;
            _clsGPU = gpuService;
            _clsProcessor = processorService;
            _clsHardDisk = hardDiskService;
            _clsScreenResolution = screenResolutionService;
            _clsRAM = ramService;
        }

        public IActionResult Index()
        {
            return View();

        }
        public IActionResult List()      
        {
           
          
            ViewBag.CategoryList = _clsCategory.GetAll(); ;

           ViewBag.ItemTypesList = _clsTypeItem.GetAll();

            var elements = _clsViewItem.GetAllItemsData(null,null);

            return View(elements);
        }

        public IActionResult Edit(int? elementId)
        {
            try
            {
                ViewBag.categoriesList = _clsCategory.GetAll();
                ViewBag.OsList = _clsOs.GetAll();
                ViewBag.ItemTypesList= _clsTypeItem.GetAll();
                ViewBag.GPUsList = _clsGPU.GetAll();
                ViewBag.ProcessorsList = _clsProcessor.GetAll();
                ViewBag.HardDisksList = _clsHardDisk.GetAll();
                ViewBag.RAMsList = _clsRAM.GetAll();
                ViewBag.ScreenResolutionsList = _clsScreenResolution.GetAll();

                if (elementId != null)
                {
                    TbItem elementToEdit = _clsItem.GetById(Convert.ToInt32(elementId));
                    return View(elementToEdit);
                }
            }
            catch 
            (Exception ex) 
            { return View(new TbItem()); }


            return View(new TbItem());

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Save(TbItem elementToSave, List<IFormFile> Files)
        {

           
            if (!ModelState.IsValid)
            {
                ViewBag.categoriesList = _clsCategory.GetAll();
                ViewBag.OsList = _clsOs.GetAll();
                ViewBag.ItemTypesList = _clsTypeItem.GetAll();
                ViewBag.GPUsList = _clsGPU.GetAll();
                ViewBag.ProcessorsList = _clsProcessor.GetAll();
                ViewBag.HardDisksList = _clsHardDisk.GetAll();
                ViewBag.RAMsList = _clsRAM.GetAll();
                ViewBag.ScreenResolutionsList = _clsScreenResolution.GetAll();

                return View("Edit", elementToSave);
            }
 
            try
            {

                if ( Files.Count > 0)
                {

                    elementToSave.ImageName =await Helper.UploadImage(Files,"Items");
                }

                if (_clsItem.Save(elementToSave))
                {
                    return RedirectToAction("List");
                }
 
                else
                {
                    ViewBag.categoriesList = _clsCategory.GetAll();
                    ViewBag.OsList = _clsOs.GetAll();
                    ViewBag.ItemTypesList = _clsTypeItem.GetAll();
                    ViewBag.GPUsList = _clsGPU.GetAll();
                    ViewBag.ProcessorsList = _clsProcessor.GetAll();
                    ViewBag.HardDisksList = _clsHardDisk.GetAll();
                    ViewBag.RAMsList = _clsRAM.GetAll();
                    ViewBag.ScreenResolutionsList = _clsScreenResolution.GetAll();

                    return View("Edit", elementToSave);

                }

            }
            catch (Exception ex)
            {

                // Handle the concurrency exception
                ModelState.AddModelError("Exception..", "The record you attempted to edit was modified by another user after you got the original value. Please reload the form and try again.");
                return View("Edit", elementToSave);
            }

        }

        public async Task<IActionResult> Delete(int elementId)
        {
            try
            {
                _clsItem.Delete(elementId);

                return RedirectToAction("List");

            }
            catch (Exception ex)
            {
                return RedirectToAction("List");
            }

        }
        [HttpGet]
        public IActionResult Search(int? elementId1,int? elementId2)
        {
            if (elementId1.HasValue|| elementId2.HasValue)
            {
                ViewBag.SelectedCategoryId = elementId1;
                ViewBag.SelectedItemTypeId = elementId2;
                ViewBag.CategoryList = _clsCategory.GetAll(); 
                ViewBag.ItemTypesList = _clsTypeItem.GetAll();

                var elements = _clsViewItem.GetAllItemsData(elementId1, elementId2);

                return View("List", elements);
            }
            return RedirectToAction("list");


        }

        [HttpGet]
        public JsonResult GetAllCategoriesInList()
        {
            var categories=_clsCategory.GetAll();

            return Json(categories);
        }

        [HttpGet]
        public JsonResult GetAllItemTypesInList()
        {
            var itemTypes = _clsTypeItem.GetAll();

            return Json(itemTypes);
        }
    }
}
