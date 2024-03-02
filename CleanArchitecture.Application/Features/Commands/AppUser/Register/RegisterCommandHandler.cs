    using CleanArchitecture.Application.Abstractions.Services;
using CleanArchitecture.Domain.Dtos.User;
using CleanArchitecture.Domain.ValueObjects;
using MediatR;

namespace CleanArchitecture.Application.Features.Commands.AppUser.RegisterUser
{
    public sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResponse>
    {
        private readonly IUserService _userService;

        public RegisterCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<RegisterCommandResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var createUserDto = new CreateUserDto
            {
                FullName = request.FullName,
                UserName = request.Username,
                Email = new EmailAddress(request.Email),
                Password = request.Password,
                PhoneNumber = new Phone(request.Phone),
                Language = request.Language
            };

            await _userService.RegisterAsync(createUserDto);

            return new RegisterCommandResponse();
        }
    }
}
