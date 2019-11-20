# MvcSocialAuthentication

###### Initialize a new solution:  
```
mkdir SocialAuth
cd SocialAuth
dotnet new mvc -n SocialAuth -o SocialAuth -au Individual
dotnet new nunit -n SocialAuth.Test -o SocialAuth.Test
dotnet new sln
dotnet sln add SocialAuth
dotnet sln add SocialAuth.Test
```
###### Set `Client ID` and `Client Secret` for each provider:   
```
cd SocialAuth
dotnet user-secrets set "Authentication:GitHub:ClientId" "<ClientId>"
dotnet user-secrets set "Authentication:GitHub:ClientSecret" "<ClientSecret>"
dotnet user-secrets set "Authentication:Reddit:ClientId" "<ClientId>"
dotnet user-secrets set "Authentication:Reddit:ClientSecret" "<ClientSecret>"
```
###### Add the required NuGet packages:  
```
dotnet add package AspNet.Security.OAuth.Reddit
dotnet add package AspNet.Security.OAuth.GitHub
```
###### Add the providers to `services` in the `Startup.cs` file:
```cs
services.AddAuthentication()
    .AddReddit(options =>
    {
        IConfigurationSection redditAuthNSection = Configuration.GetSection("Authentication:Reddit");
        options.ClientId = redditAuthNSection["ClientId"];
        options.ClientSecret = redditAuthNSection["ClientSecret"];
    })
    .AddGitHub(options =>
    {
        IConfigurationSection gitHubAuthNSection = Configuration.GetSection("Authentication:GitHub");
        options.ClientId = gitHubAuthNSection["ClientId"];
        options.ClientSecret = gitHubAuthNSection["ClientSecret"];
    });
```