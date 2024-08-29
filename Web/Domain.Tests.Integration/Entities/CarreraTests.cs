using FluentAssertions;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.Tests.Integration.Entities;

public class CarreraTests
{
    [Fact]
    public void Constructor_WhenArgumentsAreValid_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        var codigo = Codigo.Create("123");
        var nombre = Nombre.Create("Ingeniería en Sistemas");
        var escuela = Nombre.Create("Escuela de Ciencias de la Computación e Informática");
        var isSteam = false;
        var presupuestoBecas = Budget.Create(1000.0);

        // Act
        var carrera = new Carrera(codigo, nombre, escuela, isSteam, presupuestoBecas);

        // Assert: this must be done for each property
        carrera.Codigo.Should().Be(codigo);
        carrera.Nombre.Should().Be(nombre);
        carrera.Escuela.Should().Be(escuela);
        carrera.IsSteam.Should().Be(isSteam);
        carrera.PresupuestoBecas.Should().Be(presupuestoBecas);

    }
}