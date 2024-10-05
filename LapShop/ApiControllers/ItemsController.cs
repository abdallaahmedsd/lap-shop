using BusinessLib;
using LapShop.Models.APIModel;
using LapShop.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LapShop.ApiControllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ItemsController : ControllerBase
	{
		private readonly IItemViewService<VwItem> _clsViewItem;
		private readonly IBusinessInterface<TbItem> _clsItem;
        private readonly IItemLight<TbItem> _clsLightItem;

        private readonly UserManager<ApplicationUser> _userManager;
		public ItemsController(IItemViewService<VwItem>viewItemService,
			IBusinessInterface<TbItem>itemService, UserManager<ApplicationUser> userManagerService,
            IItemLight<TbItem> lightItemService)
        {
			_clsViewItem = viewItemService;
			_clsItem = itemService;
			_userManager = userManagerService;
            _clsLightItem = lightItemService;
        }
        // GET: api/<ItemsController>
        [HttpGet]
		public IActionResult Get()
        {

            try
            {
                var result = _clsViewItem.GetAllItemsData(null,null).ToList();

         

                var apiResponse = new ApiResponse
                {
                    Data = result,
                    Errors = null,
                    StatusCode = "200"
                };

                return Ok(apiResponse); // Automatically sets status code to 200
            }
            catch (Exception ex)
            {
                var apiResponse = new ApiResponse
                {
                    Data = null,
                    Errors = new List<string> { ex.Message }, // Return errors as a list for better structure
                    StatusCode = "500" // More appropriate for server errors
                };

                return StatusCode(500, apiResponse); // Use StatusCode to specify a custom status code
            }
		}

        [HttpGet("DTO/paging")]
        public IActionResult Get(int page,int pageSize)
        {

            try
            {
                var result = _clsLightItem.LightData(page,pageSize).ToList();

               var dtoResult= result.Select(x => new ItemDTO()
                {
                    Description = x.Description,
                    ImageName = x.ImageName,
                    ItemId = x.ItemId,
                    ItemName = x.ItemName,
                    PurchasePrice = x.PurchasePrice
                });

                var apiResponse = new ApiResponse
                {
                    Data = dtoResult,
                    Errors = null,
                    StatusCode = "200"
                };

                return Ok(apiResponse); // Automatically sets status code to 200
            }
            catch (Exception ex)
            {
                var apiResponse = new ApiResponse
                {
                    Data = null,
                    Errors = new List<string> { ex.Message }, // Return errors as a list for better structure
                    StatusCode = "500" // More appropriate for server errors
                };

                return StatusCode(500, apiResponse); // Use StatusCode to specify a custom status code
            }
        }


        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
		public IActionResult Get(int id)
		{
            try
            {
                var result= _clsViewItem.GetItemViewById(id);

                var apiResponse = new ApiResponse
                {
                    Data = result,
                    Errors = null,
                    StatusCode = "200"
                };

                return Ok(apiResponse); // Automatically sets status code to 200
            }
            catch (Exception ex)
            {
                var apiResponse = new ApiResponse
                {
                    Data = null,
                    Errors = new List<string> { ex.Message }, // Return errors as a list for better structure
                    StatusCode = "500" // More appropriate for server errors
                };

                return StatusCode(500, apiResponse); // Use StatusCode to specify a custom status code
            }

		}

		[HttpGet("GetByCategoryId/{CategoryId}")]
		public IActionResult GetByCategoryId(int CategoryId)
		{
            try
            {
                var result= _clsViewItem.GetAllItemsData(CategoryId, null).ToList();

                var apiResponse = new ApiResponse
                {
                    Data = result,
                    Errors = null,
                    StatusCode = "200"
                };

                return Ok(apiResponse); // Automatically sets status code to 200
            }
            catch (Exception ex)
            {
                var apiResponse = new ApiResponse
                {
                    Data = null,
                    Errors = new List<string> { ex.Message }, // Return errors as a list for better structure
                    StatusCode = "500" // More appropriate for server errors
                };

                return StatusCode(500, apiResponse); // Use StatusCode to specify a custom status code
            }

		}

        [HttpPost]
        public IActionResult Post([FromBody] VwItem item)
        {
            if (item == null || !ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new ApiResponse { Data = null, Errors = errors, StatusCode = "400" });
            }

            try
            {
                var user = _userManager.GetUserAsync(User).Result;
                if (user == null)
                {
                    return BadRequest(new ApiResponse { Data = null, Errors = "User not logged in", StatusCode = "400" });
                }

                TbItem model = new TbItem
                {
                    ItemId = item.ItemId,
                    CategoryId = item.CategoryId,
                    CreatedDate = item.CreatedDate,
                    CurrentState = item.CurrentState,
                    CreatedBy = user.Id.ToString(),
                    GPUId = item.GPUId,
                    HardDiskId = item.HardDiskId,
                    ItemName = item.ItemName,
                    OsId = item.OsId,
                    ProcessorId = item.ProcessorId,
                    ItemTypeId = item.ItemTypeId,
                    RAMId = item.RAMId,
                    ScreenResolutionId = item.ScreenResolutionId,
                    ScreenSize = item.ScreenSize,
                };

                _clsItem.Save(model);

                var message = item.ItemId == 0 ? "New item created successfully." : $"Item [{model.ItemId}] updated successfully.";
                return Ok(new ApiResponse { Data = message, Errors = null, StatusCode = "201" });
            }
            catch (Exception ex)
            {
                var errors = new List<string>
                {
                       item.ItemId == 0 ? "Failed to create the item." : $"Failed to update item [{item.ItemId}].",
                       ex.Message,
                       "Please try again or contact support."
               };
                return StatusCode(500, new ApiResponse { Data = null, Errors = errors, StatusCode = "500" });
            }
        }
        [HttpPost("delete/{id}")]
		public void Post( int Id)
		{
			
			_clsItem.Delete(Id);
		}

		
	}
}
