using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API_Silicon.Filters;

[AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
public class UseApiKeyAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        var apiKey = config.GetValue<string>("ApiKey");
        apiKey = apiKey!.Trim();

        if (!context.HttpContext.Request.Query.TryGetValue("key", out var providedKey))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        if (!apiKey!.Equals(providedKey))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        await next();
    }
}
