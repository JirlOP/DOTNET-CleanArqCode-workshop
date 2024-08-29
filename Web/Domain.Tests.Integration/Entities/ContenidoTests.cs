using FluentAssertions;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.Tests.Integration.Entities;

public class ContenidoTests
{
    [Fact]
    public void Constructor_WhenArgumentsAreValid_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        var acronimo = Acronimo.Create("CI0126");
        var nombre = Nombre.Create("Ingeniería en Software");
        var creditos = Creditos.Create(4);
        var tipo = TipoContenido.Create('t');

        // Act
        var contenido = new Contenido(acronimo, nombre, creditos, tipo);

        // Assert: this must be done for each property
        contenido.Acronimo.Should().Be(acronimo);
        contenido.Nombre.Should().Be(nombre);
        contenido.Creditos.Should().Be(creditos);
        contenido.Tipo.Should().Be(tipo);
    }
}