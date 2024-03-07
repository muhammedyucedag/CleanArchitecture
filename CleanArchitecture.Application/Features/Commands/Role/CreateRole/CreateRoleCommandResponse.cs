using CleanArchitecture.Application.Features.Commands.Response;

namespace CleanArchitecture.Application.Features.Commands.Role.CreateRole
{
    public class CreateRoleCommandResponse : BaseResponse
    {
        public CreateRoleCommandResponse(string name)
        {
            Message = $"The role with name {name} has been successfully created.";
        }
    }
}
