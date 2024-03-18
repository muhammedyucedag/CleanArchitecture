using CleanArchitecture.Application.Features.Commands.Response;

namespace CleanArchitecture.Application.Features.Commands.UserRole.CreateUserRole;

public class AssignRoleToUserCommandResponse : BaseResponse
{

    public AssignRoleToUserCommandResponse(Guid userId, string roleName)
    {

        Message = $"{roleName} rolü, {userId} kimliğine sahip kullanıcıya başarıyla atandı.";
    }
}