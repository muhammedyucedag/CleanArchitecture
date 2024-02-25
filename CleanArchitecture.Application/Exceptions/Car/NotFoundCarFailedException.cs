namespace CleanArchitecture.Application.Exceptions.Car;

public sealed class NotFoundCarFailedException : BaseException
{
    public NotFoundCarFailedException() : base("The car could not be not found.")
    {
    }
}
