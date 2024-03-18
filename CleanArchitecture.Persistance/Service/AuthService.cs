using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Abstractions.Services;
using CleanArchitecture.Application.Exceptions.User;
using CleanArchitecture.Application.Features.Commands.User.Login;
using CleanArchitecture.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Service;


public sealed class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly IJwtProvider _jwtProvider;

    public AuthService(UserManager<User> userManager, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _jwtProvider = jwtProvider;
    }

    public async Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellation)
    {
        User? user = await _userManager.Users.Where
            (u => u.UserName == request.userNameOrEmail || u.Email == request.userNameOrEmail).FirstOrDefaultAsync(cancellation);

        if (user is null) throw new UserNotFoundExcepiton();

        var result = await _userManager.CheckPasswordAsync(user, request.Password);

        if (result)
        {
            LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
            return response;
        }

        throw new WrongCurrentPasswordException();

    }
}
