using FluentAssertions;
using Moq;
using UCR.ECCI.IS.EvaluacionTecnica.Application.Services;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Repositories;

namespace UCR.ECCI.IS.EvaluacionTecnica.Application.Test.Unit.Services;

public class ContenidoServiceTests : IClassFixture<ContenidoServiceFixture>
{
    private readonly ContenidoServiceFixture _fixture;

    public ContenidoServiceTests(ContenidoServiceFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task GetContenidosAsync_GivenValidParameters_ShouldReturnContenidos()
    {
        // Arrange
        var contenidoRepositoryMock = new Mock<IContenidoRepository>();
        contenidoRepositoryMock
            .Setup(contenidoRepo => contenidoRepo.GetContenidosAsync())
            .ReturnsAsync(_fixture.Contenidos);

        var contenidoService = new ContenidoService(contenidoRepositoryMock.Object);

        // Act
        var result = await contenidoService.GetContenidosAsync();

        // Assert
        result.Should().BeEquivalentTo(_fixture.Contenidos,
            because: "GetContenidosAsync should return the list of contenidos from the repository");
    }

    [Fact]
    public async Task GetContenidosCarreraAsync_GivenValidParameters_ShouldReturnContenidos()
    {
        // Arrange
        var contenidoRepositoryMock = new Mock<IContenidoRepository>();
        contenidoRepositoryMock
            .Setup(contenidoRepo => contenidoRepo.GetContenidosCarreraAsync(_fixture.CodigoCarreraHappyPath))
            .ReturnsAsync(_fixture.ContenidosCarrera);

        var contenidoService = new ContenidoService(contenidoRepositoryMock.Object);

        // Act
        var result = await contenidoService.GetContenidosCarreraAsync(_fixture.CodigoCarreraHappyPath);

        // Assert
        result.Should().BeEquivalentTo(_fixture.ContenidosCarrera,
            because: "GetContenidosCarreraAsync should return the list of contenidos from the repository");
    }

    [Fact]
    public async Task GetContenidosCarreraAsync_GivenValidCodigoButNotContenidos_ShouldReturnEmptyList()
    {
        // Arrange
        var contenidoRepositoryMock = new Mock<IContenidoRepository>();
        contenidoRepositoryMock
            .Setup(contenidoRepo => contenidoRepo.GetContenidosCarreraAsync(_fixture.CodigoCarreraSadPath))
            .ReturnsAsync(new List<Contenido>());

        var contenidoService = new ContenidoService(contenidoRepositoryMock.Object);

        // Act
        var result = await contenidoService.GetContenidosCarreraAsync(_fixture.CodigoCarreraSadPath);

        // Assert
        result.Should().BeEmpty(
            because: "GetContenidosCarreraAsync should return an empty list when no contenidos are found");
    }

    [Fact]
    public async Task CreateContenidosAsync_GivenValidParameters_ShouldReturnTrue()
    {
        // Arrange
        var contenidoRepositoryMock = new Mock<IContenidoRepository>();
        contenidoRepositoryMock
            .Setup(contenidoRepo => contenidoRepo.CreateContenidosAsync(It.IsAny<Contenido>()))
            .ReturnsAsync(true);

        var contenidoService = new ContenidoService(contenidoRepositoryMock.Object);

        // Act
        var result = await contenidoService.CreateContenidosAsync(_fixture.Contenidos.First());

        // Assert
        result.Should().BeTrue();
    }
}
