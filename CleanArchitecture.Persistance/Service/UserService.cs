using AutoMapper;
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Abstractions.Services;
using CleanArchitecture.Application.Exceptions.Token;
using CleanArchitecture.Application.Exceptions.User;
using CleanArchitecture.Application.Features.Commands.User.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Features.Commands.User.Login;
using CleanArchitecture.Domain.Dtos.User;
using CleanArchitecture.Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Persistance.Service;

public sealed class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    //private readonly IEmailSendingService _emailSendingService;
    private readonly IJwtProvider _jwtProvider;

    public UserService(UserManager<User> userManager, IMapper mapper, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _mapper = mapper;
        _jwtProvider = jwtProvider;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _userManager.FindByNameAsync(username);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<User> RegisterAsync(CreateUserDto createUserDto)
    {
        var appUserDb = await GetByEmailAsync(createUserDto.Email.Value);
        if (appUserDb is not null)
            throw new ExistEmailException();

        var appUsername = await GetByUsernameAsync(createUserDto.UserName);
        if (appUsername is not null)
            throw new ExistUsernameException();

        User user = _mapper.Map<User>(createUserDto);

        var createUserResult = await _userManager.CreateAsync(user, createUserDto.Password);

        if (!createUserResult.Succeeded)
        {
            var errorMessage = string.Join(" ",
                createUserResult.Errors.Select(error => $"{error.Code} : {error.Description}"));
            throw new CreateUserFailedException(errorMessage);
        }

        //await _emailSendingService.SendEmailAsync();

        return user;
    }

    public async Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        User user = await _userManager.FindByIdAsync(request.UserId);
        if (user is null) throw new UserNotFoundExcepiton();

        if (user.RefreshToken != request.RefreshToken)
            throw new InvalidRefreshTokenError();

        if (user.RefreshTokenExpires < DateTime.Now)
            throw new RefreshTokenExpiredError();

        LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);

        return response;


    }
}
