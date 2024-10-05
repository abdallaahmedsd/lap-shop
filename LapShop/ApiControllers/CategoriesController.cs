using BusinessLib;
using LapShop.Models.APIModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LapShop.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IBusinessInterface<TbCategory> _clsCategory;
        private readonly UserManager<ApplicationUser> _userManager;

        public CategoriesController(IBusinessInterface<TbCategory>categoryService
            , UserManager<ApplicationUser> userManagerService)
        {
            _clsCategory = categoryService;
            _userManager = userManagerService;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult Get()
        {
                try
                {
                    var result = _clsCategory.GetAll();

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

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _clsCategory.GetById(id);

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

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post([FromBody] TbCategory entity)
        {

         
            if (entity == null || !ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new ApiResponse { Data = null, Errors = errors, StatusCode = "400" });
            }

            try
            {
                var user = _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return BadRequest(new ApiResponse { Data = null, Errors = "User not logged in", StatusCode = "400" });
                }


                _clsCategory.Save(entity);

                var message = entity.CategoryId == 0 ? "New Category created successfully." :
                    $"Category [{entity.CategoryId}] updated successfully.";
                return Ok(new ApiResponse { Data = message, Errors = null, StatusCode = "201" });
            }
            catch (Exception ex)
            {
                var errors = new List<string>
                {
                       entity.CategoryId == 0 ? "Failed to create the category." : $"Failed to update category [{entity.CategoryId}].",
                       ex.Message,
                       "Please try again or contact support."
               };
                return StatusCode(500, new ApiResponse { Data = null, Errors = errors, StatusCode = "500" });
            }
        }

        // DELETE api/<CategoriesController>/5
        [HttpPost("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (id<0)
            {
                return BadRequest(new ApiResponse { Data = null, Errors = "Invalid Id < 0", StatusCode = "400" });
            }

            try
            {
                var user = _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return BadRequest(new ApiResponse { Data = null, Errors = "User not logged in", StatusCode = "400" });
                }
                _clsCategory.Delete(id);

                var message = "Category was deleted successfully.";
                return Ok(new ApiResponse { Data = message, Errors = null, StatusCode = "201" });
            }
            catch (Exception ex)
            {
                var errors = new List<string>
                {
                       "Failed to delete category [{id}].",
                       ex.Message,
                       "Please try again or contact support."
               };
                return StatusCode(500, new ApiResponse { Data = null, Errors = errors, StatusCode = "500" });
            }

         
        }
    }
}
