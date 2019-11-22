using Microsoft.AspNetCore.Authorization;

namespace SocialAuth.Authorization
{
    public class ProviderRequirement : IAuthorizationRequirement
    {
        public string Provider { get; }

        public ProviderRequirement(string provider)
        {
            Provider = provider;
        }
    }
}