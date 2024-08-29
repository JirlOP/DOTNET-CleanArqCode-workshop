using FluentAssertions;
using UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.Repositories;
using UCR.ECCI.IS.ExampleProject.Infraestructure.Tests.Integration;

namespace UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.Tests.Integration.Repositories;

public class SqlContenidoRepositoryTests : IClassFixture<TestDatabaseFixture>
{

    private readonly TestDatabaseFixture _fixture;

    public SqlContenidoRepositoryTests(TestDatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task CreateContenidosAsync_GivenContenido_ShouldCreateContenidoReturnTrue()
    {
        // Arrange
        var contenidoRepo = new SqlContenidoRepository(_fixture.ApplicationDbContext);
        var contenidos = _fixture.GetUnknownContenido();

        // Act
        var result = await contenidoRepo.CreateContenidosAsync(contenidos);

        // Assert
        result.Should().BeTrue(
            because: "the contenidos were created successfully");
    }

}
