using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace WorldCities.Infrastructure.ModelBinders
{
    public class JwtUserIdModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            HttpContext httpContext = bindingContext.HttpContext;

            string userId = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var userGuid))
            {
                bindingContext.ModelState.AddModelError("UserId", "Invalid or missing UserId");
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(userGuid);

            return Task.CompletedTask;
        }
    }
}
