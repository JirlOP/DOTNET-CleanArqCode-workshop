using FluentAssertions;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.Test.Unit.Entities;

public class CarreraTests : IClassFixture<CarreraValueObjectFixture>
{

    private readonly CarreraValueObjectFixture _fixture;

    public CarreraTests(CarreraValueObjectFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Constructor_WithValidParameters_ShouldCreateInstance()
    {
        // Arrange
        const bool isSteam = false;

        // Act
        var carrera = new Carrera(
            _fixture.Codigo, 
            _fixture.Nombre, 
            _fixture.Escuela, 
            isSteam, 
            _fixture.PresupuestoBecas
        );

        // Assert
        carrera.Should().NotBeNull(
            because: "the parameters are valid");
    }

}