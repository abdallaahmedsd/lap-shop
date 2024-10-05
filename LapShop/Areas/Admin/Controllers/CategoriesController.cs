


namespace LapShop.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CategoriesController : Controller
    {
        private readonly IBusinessInterface<TbCategory> _clsCategory;
        public CategoriesController(IBusinessInterface<TbCategory> categoryService)
        {
            _clsCategory = categoryService;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {

            var categoriesList = _clsCategory.GetAll();

            return View(categoriesList);
        }

        public IActionResult Edit(int? elementId)
        {
            try
            {

                if (elementId != null)
                {

                    TbCategory categoryToEdit = _clsCategory.GetById(Convert.ToInt32(elementId));
                    return View(categoryToEdit);

                }
            }
            catch (Exception ex) { return View(new TbCategory()); }


            return View(new TbCategory());

        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Save(TbCategory elementToSave, List<IFormFile> Files)
        {


            if (!ModelState.IsValid)
            {
                return View("Edit", elementToSave);
            }

            try
            {


                if (elementToSave.ImageName == null&& Files.Count>0)
                {

                    elementToSave.ImageName =  await Helper.UploadImage(Files, "Categories");
                }

                if (_clsCategory.Save(elementToSave))
                {
                    return RedirectToAction("List");
                }
                else
                {
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


                _clsCategory.Delete(elementId);

                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                return RedirectToAction("List");
            }

        }
   
    }

}

