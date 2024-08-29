using FluentAssertions;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.CoreServices;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.Test.Unit.CoreServices;

/// <summary>
/// Unit testings for CarreraBudgetCalculatorRepository
/// </summary>
/// <remarks>
/// This test will be made it by a test database called ET2Test
public class CarreraBudgetCalculatorCoreServiceTests
{
    /*
     * Test the CalculateCarreraScholarshipBudget method
     * Equivalence classes:
     *   - Valid Values:
     *     - Carrera Codigo found without Contenidos (0).
     *     - Found Codigo with Contenidos:
     *       - Contenidos are tecnologicos and not.
     *         - IsSteam is false.
     *           - WomenPercentage is greater than 50
     *           - WomenPercentage is less than 50
     *         - IsSteam is true. (Assuming Computation is STEAM)
     *           - Is Computation or Not
     *             - WomenPercentage is less than 50
     *             - WomenPercentage is greater than 50
     *  This tests have different techniques of coverage:
     *    - Equivalence classes
     *    - Boundary values
     *    - Line cooverage
     *    - Branch coverage
     *    - Path coverage
     */

    // Valid Values
    [Fact]
    public void CalculateCarreraScholarshipBudget_WhenCarreraCodigoFoundWithoutContenidos_ReturnsBudgetZero()
    {
        // Arrange
        var inputPercentage = Percentage.Create(0.5);
        var expectedBudget = 0.0;

        // moq dbContext
        Carrera carrera =
                new Carrera(
                    codigo: Codigo.Create("600123"),
                    nombre: Nombre.Create("Gestion de los Recursos Naturales"),
                    escuela: Nombre.Create("Escuela de Ciencias Ambientales"),
                    isSteam: false,
                    presupuestoBecas: Budget.Create(0)
                );

        Contenido[] contenidos = []; // empty contenidos
       
        var carreraBudgetCalculatorRepository = new CarreraBudgetCalculatorCoreService();

        // Act
            var resultBudget = carreraBudgetCalculatorRepository.CalculateCarreraScholarshipBudget(
                inputPercentage, carrera, contenidos);
        var result = resultBudget.Value;

        // Assert
        result.Should().Be(expectedBudget,
            because: "carrera without Contenidos should return 0 budget");
    }

    // Found Codigo with Contenidos: - Contenidos are not tecnologicos - IsSteam is false or true - WomenPercentage is less than 50 and greater than 50
    //
    // Sn = SUM(Contenidos no tecnologicos)(2) + SUM(Contenidos tecnologicos)(0) = 200
    // Results:
    //  - Case 1: Sn + Sn(0.2) = 240
    //  - Case 2: Sn + Sn(0.2 + 0.1) = 260
    //  - Case 3: (Sn + Sn(0.5)) -> B(Base) = 300
    //    (=) B + B(0.1) = 330
    //  - Case 4: ((Sn + Sn(0.5 + 0.1)) -> B(Base) = 320
    //    (=) B + B(0.1 + 0.08) = 377.6
    //
    [Theory]
    [InlineData(0.3, false, 240.0)]
    [InlineData(0.6, false, 260.0)]
    [InlineData(0.3, true, 330.0)]
    [InlineData(0.6, true, 377.6)]
    public void CalculateCarreraScholarshipBudget_WhenContenidosNotTecnologicos_ReturnsValidValue(
        double percentage, bool isSteamCarrera, double expectedBudget)
    {
        // Arrange
        var womenInputPercentage = Percentage.Create(percentage);

        // moq dbContext
        Contenido[] contenidos =
            [
                new Contenido (
                    acronimo: Acronimo.Create("EG1"),
                    nombre: Nombre.Create("Humanidades 1"),
                    creditos: Creditos.Create(6),
                    tipo: TipoContenido.Create('s')
                ),
                new Contenido (
                    acronimo: Acronimo.Create("EG2"),
                    nombre: Nombre.Create("Humanidades 2"),
                    creditos: Creditos.Create(6),
                    tipo: TipoContenido.Create('s')
                )
            ];

        Carrera carrera =
                new Carrera(
                    codigo: Codigo.Create("600123"),
                    nombre: Nombre.Create("Test Carrera"),
                    escuela: Nombre.Create("Escuela del testeo"),
                    isSteam: isSteamCarrera,
                    presupuestoBecas: Budget.Create(0)
                 );
            
        var carreraBudgetCalculatorRepository = new CarreraBudgetCalculatorCoreService();

        // Act
        var resultBudget = carreraBudgetCalculatorRepository.CalculateCarreraScholarshipBudget(
            womenInputPercentage, carrera, contenidos);
        var result = resultBudget.Value;

        // Assert
        result.Should().Be(expectedBudget,
            because: "carrera with two Contenidos not tecnologico have to be" + expectedBudget + " budget");
    }

    // Found Codigo with Contenidos: - Some Contenidos are tecnologicos - IsSteam is false or true - WomenPercentage is less than 50 and greater than 50
    //
    // Sn = SUM(Contenidos no tecnologicos)(2) + SUM(Contenidos tecnologicos)(1) = 400
    // Results:
    //  - Case 1: Sn + Sn(0.2) = 480
    //  - Case 2: Sn + Sn(0.2 + 0.1) = 520
    //  - Case 3: (Sn + Sn(0.5)) -> B(Base) = 600
    //    (=) B + B(0.1) = 660
    //  - Case 4: ((Sn + Sn(0.5 + 0.1)) -> B(Base) = 640
    //    (=) B + B(0.1 + 0.08) = 755.2
    //
    [Theory]
    [InlineData(0.3, false, 480.0)]
    [InlineData(0.6, false, 520.0)]
    [InlineData(0.3, true, 660.0)]
    [InlineData(0.6, true, 755.2)]
    public void CalculateCarreraScholarshipBudget_WhenContenidosTecnologicos_ReturnsValidValue(
        double percentage, bool isSteamCarrera, double expectedBudget)
    {
        // Arrange
        var womenInputPercentage = Percentage.Create(percentage);

        // moq dbContext
        Contenido[] contenidos =
            [
                new Contenido (
                    acronimo: Acronimo.Create("EG1"),
                    nombre: Nombre.Create("Humanidades 1"),
                    creditos: Creditos.Create(6),
                    tipo: TipoContenido.Create('s')
                ),
                new Contenido (
                    acronimo: Acronimo.Create("EG2"),
                    nombre: Nombre.Create("Humanidades 2"),
                    creditos: Creditos.Create(6),
                    tipo: TipoContenido.Create('s')
                ),
                new Contenido (
                    acronimo: Acronimo.Create("CI0202"),
                    nombre: Nombre.Create("Principio de Informatica"),
                    creditos: Creditos.Create(4),
                    tipo: TipoContenido.Create('t')
                )
            ];

        Carrera carrera =
            
                new Carrera (
                    codigo: Codigo.Create("600123"),
                    nombre: Nombre.Create("Test Carrera"),
                    escuela: Nombre.Create("Escuela del testeo"),
                    isSteam: isSteamCarrera,
                    presupuestoBecas: Budget.Create(0)
                 );

        var carreraBudgetCalculatorRepository = new CarreraBudgetCalculatorCoreService();

        // Act
        var resultBudget = carreraBudgetCalculatorRepository.CalculateCarreraScholarshipBudget(
            womenInputPercentage, carrera, contenidos);
        var result = resultBudget.Value;

        // Assert
        result.Should().Be(expectedBudget,
            because: "carrera with two Contenidos not tecnologico and one tecnologico have to be" + expectedBudget + " budget");
    }


    // Found Codigo with Contenidos: - Some Contenidos are tecnologicos - IsSteam true - WomenPercentage is less than 50 and greater than 50
    //      + Escuela de Computación
    //
    // Sn = SUM(Contenidos no tecnologicos)(2) + SUM(Contenidos tecnologicos)(1) = 400
    // Results:
    //  - Case 1: (Sn + Sn(0.5)) -> B(Base) = 600
    //    (=) B + B(0.1 + 0.05) =  690
    //  - Case 2: ((Sn + Sn(0.5 + 0.1)) -> B(Base) = 640
    //    (=) B + B(0.1 + 0.08 + 0.05) = 787.2
    //
    [Theory]
    [InlineData(0.3, 690.0)]
    [InlineData(0.6, 787.2)]
    public void CalculateCarreraScholarshipBudget_WhenCarreraComputacion_ReturnsValidValue(
    double percentage, double expectedBudget)
    {
        // Arrange
        var womenInputPercentage = Percentage.Create(percentage);

        // moq dbContext
        Contenido[] contenidos =
            [
                new Contenido (
                    acronimo: Acronimo.Create("EG1"),
                    nombre: Nombre.Create("Humanidades 1"),
                    creditos: Creditos.Create(6),
                    tipo: TipoContenido.Create('s')
                ),
                new Contenido (
                    acronimo: Acronimo.Create("EG2"),
                    nombre: Nombre.Create("Humanidades 2"),
                    creditos: Creditos.Create(6),
                    tipo: TipoContenido.Create('s')
                ),
                new Contenido (
                    acronimo: Acronimo.Create("CI0110"),
                    nombre: Nombre.Create("Introduccion a la Computación"),
                    creditos: Creditos.Create(4),
                    tipo: TipoContenido.Create('t')
                )
            ];

        Carrera carrera =
                new Carrera (
                    codigo: Codigo.Create("420705"),
                    nombre: Nombre.Create("Computación en varios enfasis"),
                    escuela: Nombre.Create("Escuela de Ciencias de la Computación e Informática"),
                    isSteam: true,
                    presupuestoBecas: Budget.Create(0)
                 );

        var carreraBudgetCalculatorRepository = new CarreraBudgetCalculatorCoreService();

        // Act
        var resultBudget = carreraBudgetCalculatorRepository.CalculateCarreraScholarshipBudget(
            womenInputPercentage, carrera, contenidos);
        var result = resultBudget.Value;

        // Assert
        result.Should().Be(expectedBudget,
            because: "carrera with two Contenidos not tecnologico, one tecnologico and Computacion have to be" + expectedBudget + " budget");
    }

}

