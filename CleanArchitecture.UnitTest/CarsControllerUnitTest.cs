using CleanArchitecture.Application.Features.Commands.Car.CreateCar;
using CleanArchitecture.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CleanArchitecture.UnitTest;

public class CarsControllerUnitTest
{
    [Fact]
    public async void Create_ReturnsOkResult_WhenRequestIsValid()
    {
        // Arrange (Haz�rl�k)
        // Test senaryosu i�in gerekli t�m haz�rl�klar burada yap�l�r.
        var mediatorMock = new Mock<IMediator>();
        CreateCarCommandRequest createCarCommandRequest = new("Toyota", "Corolla", 5000);
        CreateCarCommandResponse response = new();
        CancellationToken cancellationToken = new();

        // Mediator mock'u �zerinde gerekli ayarlamalar yap�l�r.
        mediatorMock.Setup(m => m.Send(createCarCommandRequest, cancellationToken)).ReturnsAsync(response);

        // Test edilecek controller olu�turulur.
        CarsController carsController = new(mediatorMock.Object);

        // Act (Eylem)
        // Ger�ek test eylemi burada ger�ekle�tirilir.
        var result = await carsController.CreateAsync(createCarCommandRequest);

        // Assert (Do�rulama)
        // Test sonucunun beklenen sonu�larla uyumlu olup olmad��� burada kontrol edilir.
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<CreateCarCommandResponse>(okResult.Value);

        // Response de�erinin do�ru d�n�p d�nmedi�i ve Mediator'un �a�r�ld��� do�rulan�r.
        Assert.Equal(response, returnValue);
        mediatorMock.Verify(m => m.Send(createCarCommandRequest, cancellationToken),Times.Once);
    }
}