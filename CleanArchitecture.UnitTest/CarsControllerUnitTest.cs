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
        // Arrange (Hazýrlýk)
        // Test senaryosu için gerekli tüm hazýrlýklar burada yapýlýr.
        var mediatorMock = new Mock<IMediator>();
        CreateCarCommandRequest createCarCommandRequest = new("Toyota", "Corolla", 5000);
        CreateCarCommandResponse response = new();
        CancellationToken cancellationToken = new();

        // Mediator mock'u üzerinde gerekli ayarlamalar yapýlýr.
        mediatorMock.Setup(m => m.Send(createCarCommandRequest, cancellationToken)).ReturnsAsync(response);

        // Test edilecek controller oluþturulur.
        CarsController carsController = new(mediatorMock.Object);

        // Act (Eylem)
        // Gerçek test eylemi burada gerçekleþtirilir.
        var result = await carsController.CreateAsync(createCarCommandRequest);

        // Assert (Doðrulama)
        // Test sonucunun beklenen sonuçlarla uyumlu olup olmadýðý burada kontrol edilir.
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<CreateCarCommandResponse>(okResult.Value);

        // Response deðerinin doðru dönüp dönmediði ve Mediator'un çaðrýldýðý doðrulanýr.
        Assert.Equal(response, returnValue);
        mediatorMock.Verify(m => m.Send(createCarCommandRequest, cancellationToken),Times.Once);
    }
}