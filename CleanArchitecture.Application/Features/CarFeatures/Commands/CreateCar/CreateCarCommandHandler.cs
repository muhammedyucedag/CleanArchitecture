using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;

public sealed class CreateCarCommandHandler : IRequestHandler<CreateCarCommandRequest, CreateCarCommandResponse>
{
    public async Task<CreateCarCommandResponse> Handle(CreateCarCommandRequest request, CancellationToken cancellationToken)
    {
        return new();
    }
}
