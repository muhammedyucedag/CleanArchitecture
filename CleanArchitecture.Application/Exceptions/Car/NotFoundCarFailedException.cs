using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Application.Exceptions.Car;

public sealed class NotFoundCarFailedException : BaseException
{
    public NotFoundCarFailedException() : base("Araba bulunamadı.")
    {}
}
