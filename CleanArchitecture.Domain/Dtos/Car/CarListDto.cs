namespace CleanArchitecture.Domain.Dtos.Car;

public sealed record CarListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public int EnginePower { get; set; }

}
