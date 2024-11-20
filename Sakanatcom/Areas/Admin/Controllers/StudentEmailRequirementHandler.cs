namespace Sakanatcom.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class StudentEmailRequirementHandler : AuthorizationHandler<IAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IAuthorizationRequirement requirement)
        {
            var userEmailClaim = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

            if (userEmailClaim != null && userEmailClaim.Value.EndsWith("@std"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
