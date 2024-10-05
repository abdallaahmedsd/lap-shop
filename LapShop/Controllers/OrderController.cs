

using BusinessLib.Bl.Contract;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Data;

namespace LapShop.Controllers
{
    public class OrderController : Controller
    {
        public readonly UserManager<ApplicationUser> _userManager;
        private readonly IBusinessInterface<TbItem> _clsItem;
		private readonly ISpecialInvoiceFeature _clsSalesInvoice;

        public OrderController(IBusinessInterface<TbItem> ItemService, UserManager<ApplicationUser> UserManagerService,
		  ISpecialInvoiceFeature salesInvoiceService )
        {
            _clsItem = ItemService;
            _userManager = UserManagerService;
			_clsSalesInvoice = salesInvoiceService;

		}
        public IActionResult Cart()
        {
            // Attempt to retrieve the cart from the session
          
            //var sessionCart = HttpContext.Session.GetString("Cart");//http context
            
            var sessionCart = HttpContext.Request.Cookies["Cart"];


            if (string.IsNullOrEmpty(sessionCart))
            {
                // If the cart is empty or missing, return a view indicating an empty cart
                return View("EmptyCart");
            }

            try
            {
                // Deserialize the cart from the session string
                var cart = JsonConvert.DeserializeObject<ShoppingCart>(sessionCart);

                // Return the cart view with the deserialized object
                return View(cart);
            }
            catch (JsonException ex)
            {
                // Log the exception if necessary
                // Handle any errors that occurred during deserialization
                // You could return an error view or a default empty cart view
                return View("Error", ex);
            }
        }


        /// <summary>
        /// add item inside card
        /// </summary>
        public IActionResult AddToCart(int itemId)
        {
            // Retrieve the item by ID
            TbItem item = _clsItem.GetById(itemId);

            // Create a new shopping cart item
            ShoppingCartItem newShoppingCartItem = new ShoppingCartItem
            {
                ItemId = itemId,
                ItemName = item.ItemName,
                Price = item.SalesPrice,
                Qty = 1,
                ImgaeName = item.ImageName
            };

            // Get the existing cart from the session (if any)
            //var sessionCart = HttpContext.Session.GetString("Cart");//Httpcontext

            var sessionCart = HttpContext.Request.Cookies["Cart"];

            ShoppingCart cart;

            if (string.IsNullOrEmpty(sessionCart))
            {
                // If no cart exists in the session, create a new one
                cart = new ShoppingCart();
            }
    
            else
            {
                // If a cart exists, deserialize it
                cart = JsonConvert.DeserializeObject<ShoppingCart>(sessionCart);
            }

            
            // Add the new item to the cart
            _InsertNewItemIntoCart(newShoppingCartItem, cart);
            
            _CalculateTotalItemPrices(cart);

            // Save the updated cart back to the session
            //HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart)); //http context
            HttpContext.Response.Cookies.Append("Cart", JsonConvert.SerializeObject(cart));

            // Redirect to the Cart action
            return RedirectToAction("Cart", "Order");

        }

        public IActionResult MyOrders()
        {

            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult>OrderSuccess()
        {
            try
            {

                //check if cart exists in coockies or not ..
                var cartCookies = HttpContext.Request.Cookies["Cart"];
                if (cartCookies != null)
                {
                    var shoppingCartObj =
                    JsonConvert.DeserializeObject<ShoppingCart>(cartCookies);

                    if (shoppingCartObj == null)
                    {
                        // Handle the scenario when the role is not found
                        ViewBag.ErrorMessage = $"Cart cannot be found";
                        return View("NotFound");
                    }

                    await SaveOrder(shoppingCartObj);

                }
            }
            catch (Exception ex) {

				return View("Error");

			}
            return View();

		}

		public async Task SaveOrder(ShoppingCart newCart)
        {
            //map to sales invoice 

            List<TbSalesInvoiceItem> lstSalesInvoiceItems=new List<TbSalesInvoiceItem>();
            foreach(var item in newCart.lstItems)
            {

                TbSalesInvoiceItem SalesInvoiceItem = new() {
                   InvoicePrice=item.Price,
                    ItemId=item.ItemId,
                   Qty=item.Qty
                  };

                lstSalesInvoiceItems.Add(SalesInvoiceItem);

			}
            
            var user = await _userManager.GetUserAsync(User);

            TbSalesInvoice tbSalesInvoice = new TbSalesInvoice
            {
                DelivryDate = DateTime.Now.AddDays(25),
                CreatedBy = user.Id,
                CreatedDate = DateTime.Now,
                CustomerId = Guid.Parse(user.Id),
                InvoiceDate = DateTime.Now,

            };

            _clsSalesInvoice.Save(lstSalesInvoiceItems, tbSalesInvoice,true);


		}


        //[Authorize]
        //public IActionResult CheckOut()
        //{

        //    return View();
        //}
        
        private void _InsertNewItemIntoCart(ShoppingCartItem newShoppingCartItem, ShoppingCart cart)
        {
            if(cart.lstItems.Where(i=>i.ItemId== newShoppingCartItem.ItemId).Any())
            {
                cart.lstItems.Where(i => i.ItemId == newShoppingCartItem.ItemId).SingleOrDefault().Qty += 1;
            }
            else
            {
                cart.lstItems.Add(newShoppingCartItem);
            }
        }

        private void _CalculateTotalItemPrices(ShoppingCart cart)
        {
            decimal totalItemsPrice=cart.lstItems.Sum(i=>i.Total);
            cart.Total = totalItemsPrice;

        }


    }
}
