using CleanArchitecture.Application.Abstractions.Services.Authentications;

namespace CleanArchitecture.Application.Abstractions.Services;

public interface IAuthService : IExternalAuthentication, IInternalAuthentication
{

}
