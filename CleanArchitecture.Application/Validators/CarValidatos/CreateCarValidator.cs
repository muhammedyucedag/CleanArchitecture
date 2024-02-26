using CleanArchitecture.Application.Features.Commands.Car.CreateCar;
using FluentValidation;

namespace CleanArchitecture.Application.Validators.CarValidatos
{
    public class CreateCarValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Vehicle name cannot be empty.");
            RuleFor(p => p.Name).NotNull().WithMessage("Vehicle name cannot be empty.");
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("Vehicle name must be at least 3 characters long.");

            RuleFor(p => p.Model).NotEmpty().WithMessage("Vehicle model cannot be empty.");
            RuleFor(p => p.Model).NotNull().WithMessage("Vehicle model cannot be empty.");
            RuleFor(p => p.Model).MinimumLength(3).WithMessage("Vehicle model must be at least 3 characters long.");

            RuleFor(p => p.EnginePower).NotEmpty().WithMessage("Vehicle engine power cannot be empty.");
            RuleFor(p => p.EnginePower).NotNull().WithMessage("Vehicle engine power cannot be empty.");
            RuleFor(p => p.EnginePower).GreaterThan(0).WithMessage("Vehicle engine power must be greater than 0.");

        }
    }
}
