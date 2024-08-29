using FluentAssertions;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.Test.Unit.Entities;

public class ContenidoTests : IClassFixture<ContenidoValueObjectFixture>
{

    private readonly ContenidoValueObjectFixture _fixture;

    public ContenidoTests(ContenidoValueObjectFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Constructor_WithValidParameters_ShouldCreateInstance()
    { 
        // Act
        var carrera = new Contenido(
            _fixture.Acronimo, 
            _fixture.Nombre, 
            _fixture.Creditos, 
            _fixture.Tipo
        );

        // Assert
        carrera.Should().NotBeNull(
            because: "the parameters are valid");
    }

    [Fact]
    public void IsTecnologico_WithValidParameters_ShouldReturnTrue()
    {
        // Arrange
        _fixture.SetUpTipoTecnologico();
        var contenido = new Contenido(
            _fixture.Acronimo, 
            _fixture.Nombre, 
            _fixture.Creditos, 
            _fixture.Tipo
        );

        // Act
        var result = contenido.IsTecnologico();

        // Assert
        result.Should().BeTrue(
            because: "the content type is tecnologico");
    }

    // Equivalence class: tipo != 't'
    [Fact]
    public void IsTecnologico_WithInvalidParameters_ShouldReturnFalse()
    {
        // Arrange
        _fixture.SetUpTipoSocial();
        var contenido = new Contenido(
            _fixture.Acronimo,
            _fixture.Nombre,
            _fixture.Creditos,
            _fixture.Tipo
        );

        // Act
        var result = contenido.IsTecnologico();

        // Assert
        result.Should().BeFalse(
            because: "the content type is not tecnologico");
    }

    [Fact]
    public void IsSocial_WithValidParameters_ShouldReturnTrue()
    {
        // Arrange
        _fixture.SetUpTipoSocial();
        var contenido = new Contenido(
            _fixture.Acronimo,
            _fixture.Nombre,
            _fixture.Creditos,
            _fixture.Tipo
        );

        // Act
        var result = contenido.IsSocial();

        // Assert
        result.Should().BeTrue(
            because: "the content type is social");
    }

    // Equivalence class: tipo != 's'
    [Fact]
    public void IsSocial_WithInvalidParameters_ShouldReturnFalse()
    {
        // Arrange
        _fixture.SetUpTipoAmbiental();
        var contenido = new Contenido(
            _fixture.Acronimo,
            _fixture.Nombre,
            _fixture.Creditos,
            _fixture.Tipo
        );

        // Act
        var result = contenido.IsSocial();

        // Assert
        result.Should().BeFalse(
            because: "the content type is not social");
    }

    [Fact]
    public void IsAmbiental_WithValidParameters_ShouldReturnTrue()
    {
        // Arrange
        _fixture.SetUpTipoAmbiental();
        var contenido = new Contenido(
            _fixture.Acronimo,
            _fixture.Nombre,
            _fixture.Creditos,
            _fixture.Tipo
        );

        // Act
        var result = contenido.IsAmbiental();

        // Assert
        result.Should().BeTrue(
            because: "the content type is ambiental");
    }

    // Equivalence class: tipo != 'a'
    [Fact]
    public void IsAmbiental_WithInvalidParameters_ShouldReturnFalse()
    {
        // Arrange
        _fixture.SetUpTipoTecnologico();
        var contenido = new Contenido(
            _fixture.Acronimo,
            _fixture.Nombre,
            _fixture.Creditos,
            _fixture.Tipo
        );

        // Act
        var result = contenido.IsAmbiental();

        // Assert
        result.Should().BeFalse(
            because: "the content type is not ambiental");
    }
}