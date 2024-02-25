using AutoMapper;
using CleanArchitecture.Application.Abstractions.Services;
using CleanArchitecture.Application.Exceptions.User;
using CleanArchitecture.Domain.Dtos.User;
using CleanArchitecture.Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Persistance.Service
{
    public sealed class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<AppUser?> GetByUsernameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<AppUser?> GetByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<AppUser> RegisterAsync(CreateUserDto createUserDto)
        {
            var appUserDb = await GetByEmailAsync(createUserDto.Email.Value);
            if (appUserDb is not null)
                throw new ExistEmailException();

            var appUsername = await GetByUsernameAsync(createUserDto.UserName);
            if (appUsername is not null)
                throw new ExistUsernameException();

            AppUser user = _mapper.Map<AppUser>(createUserDto);

            var createUserResult = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!createUserResult.Succeeded)
            {
                var errorMessage = string.Join(" ",
                    createUserResult.Errors.Select(error => $"{error.Code} : {error.Description}"));
                throw new CreateUserFailedException(errorMessage);
            }

            return user;
        }
    }
}
