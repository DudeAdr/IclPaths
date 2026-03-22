using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IclPaths.API.CustomActionFilters
{
    public class NotFoundIfNullAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Result is ObjectResult objectResult)
            {
                if(objectResult.Value == null)
                {
                    context.Result = new NotFoundResult();
                }
            }
            base.OnActionExecuted(context);
        }
    }
}
