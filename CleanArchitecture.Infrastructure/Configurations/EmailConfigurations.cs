namespace CleanArchitecture.Infrastructure.Configurations
{
    public sealed record EmailConfigurations(
     string Stmp,
     string Password,
     int Port,
     bool SSL = true,
     bool Html = true);

}
