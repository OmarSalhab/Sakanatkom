using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

public class BlockEmailAuthorizationFilter : IAuthorizationFilter
{
    private readonly string blockedEmailDomain;

    public BlockEmailAuthorizationFilter(string blockedEmailDomain)
    {
        this.blockedEmailDomain = blockedEmailDomain;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var userEmail = context.HttpContext.User?.FindFirstValue(ClaimTypes.Email);

        if (!string.IsNullOrWhiteSpace(userEmail) && userEmail.Contains(blockedEmailDomain))
        {
            // User has a blocked email domain, so deny access
            context.Result = new ForbidResult();
        }
    }
}