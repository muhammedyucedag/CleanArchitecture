namespace CleanArchitecture.Domain.Dtos.Car;

public sealed class CreateCarDto
{
    public string Name { get; set; }
    public string Model { get; set; }
    public int EnginePower { get; set; }
}
