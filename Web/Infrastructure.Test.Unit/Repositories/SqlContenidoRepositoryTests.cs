using Moq;
using MockQueryable.Moq;
using FluentAssertions;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;
using UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.Repositories;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
namespace UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.Test.Unit.Repositories;

public class SqlContenidoRepositoryTests
{

    [Fact]
    public async Task GetContenidosAsync_WhenCalled_ReturnsContenidos()
    {
        // Arrange
        var contenidos = new List<Contenido>
        {
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
        };

        var mockContenidoDbSet = contenidos.BuildMock().BuildMockDbSet();
        var dbContextMock = new Mock<ApplicationDbContext>();
        dbContextMock
            .Setup(x => x.Contenidos)
            .Returns(mockContenidoDbSet.Object);

        var repository = new SqlContenidoRepository(dbContextMock.Object);

        // Act
        var result = await repository.GetContenidosAsync();

        // Assert
        result.Should().BeEquivalentTo(contenidos,
            because: "GetContenidosAsync should return all Contenidos");
    }

    [Fact]
    public async Task CreateContenidosAsync_WhenCalled_ReturnsTrue()
    {
        // Arrange
        var contenido = new Contenido(
            acronimo: Acronimo.Create("EG1"),
            nombre: Nombre.Create("Humanidades 1"),
            creditos: Creditos.Create(6),
            tipo: TipoContenido.Create('s')
        );

        var mockContenidoDbSet = new List<Contenido>().BuildMock().BuildMockDbSet();

        var dbContextMock = new Mock<ApplicationDbContext>();
        dbContextMock
            .Setup(x => x.Contenidos)
            .Returns(mockContenidoDbSet.Object);
        dbContextMock
            .Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        var repository = new SqlContenidoRepository(dbContextMock.Object);

        // Act
        var result = await repository.CreateContenidosAsync(contenido);

        // Assert
        mockContenidoDbSet
            .Verify(m => m.AddAsync(contenido, It.IsAny<CancellationToken>()), Times.Once);
        result.Should().BeTrue();
    }

   
}
