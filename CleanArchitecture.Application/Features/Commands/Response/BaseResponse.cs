
namespace CleanArchitecture.Application.Features.Commands.Response
{
    public abstract class BaseResponse
    {
        public bool Succeeded { get; set; } = true;
        public string Message { get; set; }
    }
    
}
