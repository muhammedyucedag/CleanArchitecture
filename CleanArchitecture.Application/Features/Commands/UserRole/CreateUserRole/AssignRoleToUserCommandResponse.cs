using CleanArchitecture.Application.Features.Commands.Response;

namespace CleanArchitecture.Application.Features.Commands.UserRole.CreateUserRole
{
    public class AssignRoleToUserCommandResponse : BaseResponse
    {

        public AssignRoleToUserCommandResponse(Guid userId, string roleName)
        {

            Message = $"The role {roleName} has been successfully assigned to the user with ID {userId}.";
        }
    }
}