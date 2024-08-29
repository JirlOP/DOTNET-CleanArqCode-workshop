using FluentAssertions;
using Moq;
using UCR.ECCI.IS.EvaluacionTecnica.Application.Services;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.CoreServices;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Repositories;

namespace UCR.ECCI.IS.EvaluacionTecnica.Application.Test.Unit.Services;

public class CarreraServiceTests : IClassFixture<CarreraServiceFixture>
{

    // dependency injection carreras list fixture
    private readonly CarreraServiceFixture _carreraServiceFixture;

    public CarreraServiceTests(CarreraServiceFixture carreraServiceFixture)
    {
        _carreraServiceFixture = carreraServiceFixture;
    }

    [Fact]
    public async Task GetCarrerasAsync_WhenGivenCarreras_ShouldReturnsCarreras()
    {
        // Arrange
        var carreraRepositoryMock = new Mock<ICarreraRepository>();
        carreraRepositoryMock
            .Setup(carreraRepo => carreraRepo.GetCarrerasAsync())
            .ReturnsAsync(_carreraServiceFixture.Carreras);
        var carreraService = new CarreraService(
            carreraRepositoryMock.Object,
            new Mock<ICarreraBudgetCalculatorCoreService>().Object,
            new Mock<IExternalRegisterCarreraInfoRepository>().Object,
            new Mock<IContenidoRepository>().Object
        );

        // Act
        var result = await carreraService.GetCarrerasAsync();

        // Assert
        result.Should().BeEquivalentTo(_carreraServiceFixture.Carreras,
            because: "GetCarrerasAsync should return the list of carreras from the repository");
    }

    [Fact]
    public async Task CreateCarreraAsync_WhenGivenCarrera_ShouldReturnTrue()
    {
        // Arrange
        var carreraRepositoryMock = new Mock<ICarreraRepository>();
        carreraRepositoryMock
            .Setup(carreraRepo => carreraRepo.CreateCarreraAsync(It.IsAny<Carrera>()))
            .ReturnsAsync(true);

        var carreraService = new CarreraService(
            carreraRepositoryMock.Object,
            new Mock<ICarreraBudgetCalculatorCoreService>().Object,
            new Mock<IExternalRegisterCarreraInfoRepository>().Object,
            new Mock<IContenidoRepository>().Object
        );

        // Act
        var result = await carreraService.CreateCarreraAsync(_carreraServiceFixture.Carreras.First());

        // Assert
        result.Should().BeTrue(
            because: "CreateCarreraAsync should return true when the carrera is created successfully");
    }

    [Fact]
    public async Task UpdateCarreraScholarshipBudgetAsync_WhenGivenCodigo_ShouldReturnTrue()
    {
        // Arrange
        var carreraRepositoryMock = new Mock<ICarreraRepository>();
        var carreraBudgetCalculatorCoreServiceMock = new Mock<ICarreraBudgetCalculatorCoreService>();
        var externalRegisterCarreraInfoRepositoryMock = new Mock<IExternalRegisterCarreraInfoRepository>();
        var contenidoRepositoryMock = new Mock<IContenidoRepository>();

        // mock externalRegisterCarreraInfoRepository method to return the WomenPercentage
        externalRegisterCarreraInfoRepositoryMock
            .Setup(externalRegRepo => externalRegRepo.GetWomenPercentageAsync(_carreraServiceFixture.CodigoCarrera))
            .ReturnsAsync(_carreraServiceFixture.WomenPercentage);

        // mock carreraBudgetCalculatorCoreService method to return the scholarship budget
        carreraBudgetCalculatorCoreServiceMock
            .Setup(calcRepo => calcRepo.CalculateCarreraScholarshipBudget(
                _carreraServiceFixture.WomenPercentage, _carreraServiceFixture.Carreras.First(), _carreraServiceFixture.Contenidos))    
            .Returns(_carreraServiceFixture.ScholarshipBudget);

        // mock carreraRepository method to return true
        carreraRepositoryMock
            .Setup(carreraRepo => carreraRepo.FindCarreraAsync(_carreraServiceFixture.CodigoCarrera))
            .ReturnsAsync(_carreraServiceFixture.Carreras.First());
        carreraRepositoryMock
            .Setup(carreraRepo => carreraRepo.UpdateCarreraScholarshipBudgetAsync(
                _carreraServiceFixture.CodigoCarrera, _carreraServiceFixture.ScholarshipBudget))
            .ReturnsAsync(true);

        // mock contenidoRepository method to return the list of contenidos
        contenidoRepositoryMock
            .Setup(contenidoRepo => contenidoRepo.GetContenidosCarreraAsync(_carreraServiceFixture.CodigoCarrera))
            .ReturnsAsync(_carreraServiceFixture.Contenidos);

        var carreraService = new CarreraService(
            carreraRepositoryMock.Object,
            carreraBudgetCalculatorCoreServiceMock.Object,
            externalRegisterCarreraInfoRepositoryMock.Object,
            contenidoRepositoryMock.Object
        );

        // Act
        var result = await carreraService.UpdateCarreraScholarshipBudgetAsync(
            _carreraServiceFixture.CodigoCarrera);

        // Assert
        result.Should().BeTrue(
            because: "UpdateCarreraScholarshipBudgetAsync should return true when the budget is updated successfully");
    }

    [Fact]
    public async Task UpdateCarreraScholarshipBudgetFrontendAsync_WhenGivenCodigo_ShouldReturnTrue()
    {
        // Arrange
        var carreraRepositoryMock = new Mock<ICarreraRepository>();
        carreraRepositoryMock
            .Setup(carreraRepo => carreraRepo.UpdateCarreraScholarshipBudgetFrontendAsync(_carreraServiceFixture.CodigoCarrera))
            .ReturnsAsync(true);

        var carreraService = new CarreraService(
            carreraRepositoryMock.Object,
            new Mock<ICarreraBudgetCalculatorCoreService>().Object,
            new Mock<IExternalRegisterCarreraInfoRepository>().Object,
            new Mock<IContenidoRepository>().Object
        );

        // Act
        var result = await carreraService.UpdateCarreraScholarshipBudgetFrontendAsync(
            _carreraServiceFixture.CodigoCarrera);

        // Assert
        result.Should().BeTrue(
            because: "UpdateCarreraScholarshipBudgetFrontendAsync should return true when the budget is updated successfully");
    }
}