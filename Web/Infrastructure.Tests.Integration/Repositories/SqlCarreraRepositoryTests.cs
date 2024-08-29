using FluentAssertions;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;
using UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.Repositories;
using UCR.ECCI.IS.ExampleProject.Infraestructure.Tests.Integration;

namespace UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.Tests.Integration.Repositories;

public class SqlCarreraRepositoryTests : IClassFixture<TestDatabaseFixture>
{

    private readonly TestDatabaseFixture _fixture;

    public SqlCarreraRepositoryTests(TestDatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task GetCarrerasAsync_GivenNoCarreras_ShouldReturnEmptyList()
    {
        // Arrange
        var carreraRepo = new SqlCarreraRepository(_fixture.ApplicationDbContext);

        // Act
        var carreras = await carreraRepo.GetCarrerasAsync();

        // Assert
        carreras.Should().BeEmpty(
            because: "there are no carreras in the database");
    }

    [Fact]
    public async Task GetCarrerasAsync_GivenNoCarreras_ShouldReturnCarreras()
    {
        // Arrange
        var carreraRepo = new SqlCarreraRepository(_fixture.ApplicationDbContext);
        await _fixture
            .FillDatabaseAsync();

        // Act
        var carreras = await carreraRepo.GetCarrerasAsync();

        // Assert
        carreras.Should().NotBeEmpty(
            because: "there are carreras in the database");
    }

    [Fact]
    public async Task AddContenidoToCarreraAsync_GivenCodigoAndAcronimo_ShouldAddContenidoToCarrera()
    {
        // Arrange
        var carreraRepo = new SqlCarreraRepository(_fixture.ApplicationDbContext);
        var carrera = _fixture.GetCarreraWithoutContenidos();
        var contenido = _fixture.GetKnownContenido();
        await _fixture.FillDatabaseAsync();


        // Act
        var result = await carreraRepo.AddContenidoToCarreraAsync(carrera.Codigo, contenido.Acronimo);   

        // erase database
        await _fixture.EraseTablesAsync();

        // Assert
        result.Should().BeTrue(
            because: "the contenido was added to the carrera");
    }

    // if contenido is already in carrera, it should not be added again and return false
    [Fact]
    public async Task AddContenidoToCarreraAsync_GivenCodigoAndAcronimo_ShouldNotAddContenidoToCarrera()
    {
        // Arrange
        var carreraRepo = new SqlCarreraRepository(_fixture.ApplicationDbContext);
        var carrera = _fixture.GetCarreraWithContenidos();
        var contenido = _fixture.GetKnownContenido();
        await _fixture.FillDatabaseAsync();
        await _fixture.AddContenidosToFirstCarreraAsync();

        // Act
        var result = await carreraRepo.AddContenidoToCarreraAsync(carrera.Codigo, contenido.Acronimo);

        // erase database
        await _fixture.EraseTablesAsync();

        // Assert
        result.Should().BeFalse(
            because: "the contenido was already in the carrera");
    }

    [Fact]
    public async Task UpdateCarreraScholarshipBudgetAsync_GivenCodigoAndBudget_ShouldUpdateCarreraScholarshipBudget()
    {
        // Arrange
        var carreraRepo = new SqlCarreraRepository(_fixture.ApplicationDbContext);
        var carrera = _fixture.GetCarreraWithoutContenidos();
        var budget = Budget.Create(1000);
        await _fixture.FillDatabaseAsync();

        // Act
        var result = await carreraRepo.UpdateCarreraScholarshipBudgetAsync(carrera.Codigo, budget);

        // erase database
        await _fixture.EraseTablesAsync();

        // Assert
        result.Should().BeTrue(
                       because: "the budget was updated");
    }
}
