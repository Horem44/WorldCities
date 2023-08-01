using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WorldCities.Api.ActionFilters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                string errorMessage = string.Join(
                    " | ",
                    context.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                );

                context.Result = new BadRequestObjectResult(errorMessage);
            }
        }
    }
}
