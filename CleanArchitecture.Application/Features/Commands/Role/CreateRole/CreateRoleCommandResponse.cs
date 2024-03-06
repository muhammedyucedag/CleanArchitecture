using CleanArchitecture.Application.Features.Commands.Response;

namespace CleanArchitecture.Application.Features.Commands.Role.CreateRole
{
    public class CreateRoleCommandResponse : BaseResponse
    {
        public string Name { get; set; }

        public CreateRoleCommandResponse(string name)
        {
            Name = name;
            Message = $"The role with name {Name} has been successfully created.";
        }
    }
}
