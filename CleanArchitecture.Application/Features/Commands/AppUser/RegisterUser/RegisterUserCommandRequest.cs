using MediatR;

namespace CleanArchitecture.Application.Features.Commands.AppUser.RegisterUser
{
    public sealed record RegisterUserCommandRequest(
         string FullName,
         string Username,
         string Email,
         string Phone,
         string Password,
         string PasswordConfirm,
         string Language) : IRequest<RegisterUserCommandResponse>;
}