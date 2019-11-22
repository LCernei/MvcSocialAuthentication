using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SocialAuth.Authorization
{
    public class ProviderHandler : AuthorizationHandler<ProviderRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ProviderRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == ClaimTypes.AuthenticationMethod &&
                                            c.Value == "GitHub"))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}