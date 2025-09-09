using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace dp.Attributes
{
    public class AdminOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var role = context.HttpContext.Session.GetString("Role");
            if(string.IsNullOrEmpty(role) || role != "Admin")
            {
                context.Result = new RedirectToActionResult("AccesDenied", "User", null);

            }

            base.OnActionExecuting(context);
        }
    }
}
