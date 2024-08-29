using UCR.ECCI.IS.EvaluacionTecnica.Application.Services;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Repositories;
using UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.Repositories;
using FluentAssertions;
using UCR.ECCI.IS.ExampleProject.Infraestructure.Tests.Integration;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.CoreServices;

namespace UCR.ECCI.IS.EvaluacionTecnica.Application.Tests.Integration.Services;

public class CarreraServiceTests : IClassFixture<TestDatabaseFixture>
{

    public readonly TestDatabaseFixture _fixture;

    public CarreraServiceTests(TestDatabaseFixture testDatabaseFixture)
    {
        _fixture = testDatabaseFixture;
    }

    [Fact]
    public async Task UpdateCarreraScholarshipBudgetAsync_GivenCarreraCode_ShouldUpdateCarreraAndReturnTrue()
    {
        // Arrange
        // set up the service
        var carreraRepository = new SqlCarreraRepository(_fixture.ApplicationDbContext);
        var contenidoRepository = new SqlContenidoRepository(_fixture.ApplicationDbContext);
        var carreraBudgetCalculatorCoreService = new CarreraBudgetCalculatorCoreService();
        var externalRegisterCarreraInfoRepository = new ExternalRegisterCarreraInfoRepository();
        var carreraService = new CarreraService(carreraRepository, carreraBudgetCalculatorCoreService, externalRegisterCarreraInfoRepository, contenidoRepository);

        // Fill the database with some data
        await _fixture
            .FillDatabaseAsync();

        // Create a carrera code
        var inputCarreraCodigo = _fixture.GetCarreraWithContenidos().Codigo;

        // Act
        var result = await carreraService.UpdateCarreraScholarshipBudgetAsync(inputCarreraCodigo);

        // Assert
        result.Should().BeTrue(
            because: "UpdateCarreraScholarshipBudgetAsync should return true if the budget was updated successfully");
    }
}
