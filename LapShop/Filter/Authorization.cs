using Microsoft.AspNetCore.Mvc.Filters;

namespace LapShop.Filter
{
	public class Authorization:ActionFilterAttribute
	{
		public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			
			string actionName = context.HttpContext.Request.RouteValues["action"].ToString();
			
			if (string.IsNullOrEmpty(actionName)) {

				throw new ArgumentNullException($"{nameof(actionName)}");
			}
			
			string controllerName=context.HttpContext.Request.RouteValues["controller"].ToString();
			
			if (string.IsNullOrEmpty(controllerName)) { 
				throw new ArgumentNullException($"{nameof(controllerName)}");


			}

			return base.OnActionExecutionAsync(context, next);
		}

	}
}
