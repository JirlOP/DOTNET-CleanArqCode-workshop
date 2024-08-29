using Moq;
using MockQueryable.Moq;
using FluentAssertions;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;
using UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.Repositories;
namespace UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.Test.Unit.Repositories;

public class SqlCarreraRepositoryTests
{

    [Fact]
    public async Task GetCarrerasAsync_WhenCalled_ReturnsAllCarreras()
    {
        // Arrange

        Carrera[] carreras =
            [
                new Carrera(
                    codigo: Codigo.Create("600123"),
                    nombre: Nombre.Create("Gestion de los Recursos Naturales"),
                    escuela: Nombre.Create("Escuela de Ciencias Ambientales"),
                    isSteam: false,
                    presupuestoBecas: Budget.Create(0)
                ),
                new Carrera (
                    codigo: Codigo.Create("420705"),
                    nombre: Nombre.Create("Computación en varios enfasis"),
                    escuela: Nombre.Create("Escuela de Ciencias de la Computación e Informática"),
                    isSteam: true,
                    presupuestoBecas: Budget.Create(0)
                 )
            ];

        // mock DbSet
        var mockDbSetCarrera = carreras.BuildMock().BuildMockDbSet();

        // mock DbContext
        var mockDbContext = new Mock<ApplicationDbContext>();
        mockDbContext
            .Setup(c => c.Carreras)
            .Returns(mockDbSetCarrera.Object);
        
        var repository = new SqlCarreraRepository(mockDbContext.Object);
      
        // Act
        var result = await repository.GetCarrerasAsync();

        // Assert
        result.Should().BeEquivalentTo(carreras);
    }

    // empty list test
    [Fact]
    public async Task GetCarrerasAsync_WhenCalled_ReturnsEmptyList()
    {
        // Arrange
        Carrera[] carreras = [];

        // mock DbSet
        var mockDbSetCarrera = carreras.BuildMock().BuildMockDbSet();

        // mock DbContext
        var mockDbContext = new Mock<ApplicationDbContext>();
        mockDbContext
            .Setup(c => c.Carreras)
            .Returns(mockDbSetCarrera.Object);
        
        var repository = new SqlCarreraRepository(mockDbContext.Object);
      
        // Act
        var result = await repository.GetCarrerasAsync();

        // Assert
        result.Should().BeEquivalentTo(carreras,
            because: "There are no carreras in the database");
    }


    [Fact]
    public async Task FindCarreraAsync_GivenValidCodigo_ReturnsCarrera()
    {
        // Arrange
        var inputCodigo = Codigo.Create("420705");

        var expectedCarrera =
            new Carrera(
                    codigo: inputCodigo,
                    nombre: Nombre.Create("Computación en varios enfasis"),
                    escuela: Nombre.Create("Escuela de Ciencias de la Computación e Informática"),
                    isSteam: true,
                    presupuestoBecas: Budget.Create(0)
        );

        Carrera[] carreras =
            [
                new Carrera(
                    codigo: Codigo.Create("600123"),
                    nombre: Nombre.Create("Gestion de los Recursos Naturales"),
                    escuela: Nombre.Create("Escuela de Ciencias Ambientales"),
                    isSteam: false,
                    presupuestoBecas: Budget.Create(0)
                ),
                expectedCarrera
            ];


        // mock DbSet
        var mockDbSetCarrera = carreras.BuildMock().BuildMockDbSet();

        // mock DbContext
        var mockDbContext = new Mock<ApplicationDbContext>();
        mockDbContext
            .Setup(c => c.Carreras)
            .Returns(mockDbSetCarrera.Object);
        mockDbContext
            .Setup(c => c.Carreras.FindAsync(inputCodigo))
            .ReturnsAsync(expectedCarrera);

        var repository = new SqlCarreraRepository(mockDbContext.Object);
      
        // Act
        var carreraResults = await repository.FindCarreraAsync(inputCodigo);

        // Assert
        carreraResults.Should().BeEquivalentTo(expectedCarrera,
            because: "The carrera with the given codigo is in the database");
    }

    // sad path of FindCarrera test Invalid Operation Exception
    [Fact]
    public async Task FindCarreraAsync_GivenInvalidCodigo_ThrowsInvalidOperationException()
    {
        // Arrange
        var inputCodigo = Codigo.Create("420705");

        Carrera[] carreras =
            [
                new Carrera(
                    codigo: Codigo.Create("600123"),
                    nombre: Nombre.Create("Gestion de los Recursos Naturales"),
                    escuela: Nombre.Create("Escuela de Ciencias Ambientales"),
                    isSteam: false,
                    presupuestoBecas: Budget.Create(0)
                )
            ];

        // mock DbSet
        var mockDbSetCarrera = carreras.BuildMock().BuildMockDbSet();

        // mock DbContext
        var mockDbContext = new Mock<ApplicationDbContext>();
        mockDbContext
            .Setup(c => c.Carreras)
            .Returns(mockDbSetCarrera.Object);

        var repository = new SqlCarreraRepository(mockDbContext.Object);

        // Act
        Func<Task> action = async () => await repository.FindCarreraAsync(inputCodigo);

        // Assert
        await action.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("Carrera not found");
    }

    [Fact]
    public async Task CreateCarreraAsync_GivenValidCarrera_ReturnsTrue()
    {
        // Arrange
        var carrera = new Carrera(
            codigo: Codigo.Create("420705"),
            nombre: Nombre.Create("Computación en varios enfasis"),
            escuela: Nombre.Create("Escuela de Ciencias de la Computación e Informática"),
            isSteam: true,
            presupuestoBecas: Budget.Create(0)
        );

        // mock DbSet
        var mockDbSetCarrera = new List<Carrera>().BuildMock().BuildMockDbSet();

        // mock DbContext
        var mockDbContext = new Mock<ApplicationDbContext>();
        mockDbContext
            .Setup(db => db.Carreras)
            .Returns(mockDbSetCarrera.Object);
        mockDbContext
            .Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        var repository = new SqlCarreraRepository(mockDbContext.Object);
      
        // Act
        var result = await repository.CreateCarreraAsync(carrera);

        // Assert
        mockDbSetCarrera
            .Verify(m => m.AddAsync(carrera, It.IsAny<CancellationToken>()), Times.Once);
        result.Should().BeTrue(
            because: "The carrera was successfully added to the database");
    }

    [Fact]
    public async Task CreateCarreraAsync_GivenInvalidCarrera_ReturnsFalse()
    {
        // Arrange
        var carrera = new Carrera(
            codigo: Codigo.Create("420705"),
            nombre: Nombre.Create("Computación en varios enfasis"),
            escuela: Nombre.Create("Escuela de Ciencias de la Computación e Informática"),
            isSteam: true,
            presupuestoBecas: Budget.Create(0)
        );

        // mock DbSet
        var mockDbSetCarrera = new List<Carrera>().BuildMock().BuildMockDbSet();

        // mock DbContext
        var mockDbContext = new Mock<ApplicationDbContext>();
        mockDbContext
            .Setup(c => c.Carreras)
            .Returns(mockDbSetCarrera.Object);
        mockDbContext
            .Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(0);

        var repository = new SqlCarreraRepository(mockDbContext.Object);
      
        // Act
        var result = await repository.CreateCarreraAsync(carrera);

        // Assert
        result.Should().BeFalse(
            because: "The carrera already exists in the database");
    }

    [Fact]
    public async Task AddContenidoToCarreraAsync_GivenValidCarreraAndContenido_ReturnsTrue()
    {
        // Arrange
        var carrera = new Carrera(
            codigo: Codigo.Create("420705"),
            nombre: Nombre.Create("Computación en varios enfasis"),
            escuela: Nombre.Create("Escuela de Ciencias de la Computación e Informática"),
            isSteam: true,
            presupuestoBecas: Budget.Create(0)
        );

        var contenido = new Contenido(
            acronimo: Acronimo.Create("CI123"),
            nombre: Nombre.Create("Introducción a la Computación"),
            creditos: Creditos.Create(4),
            tipo: TipoContenido.Create('t')
        );

        // mock DbSet
        var mockDbSetCarrera = new List<Carrera> { carrera }.BuildMock().BuildMockDbSet();
        mockDbSetCarrera
            .Setup(m => m.FindAsync(carrera.Codigo))
            .ReturnsAsync(carrera);
        var mockDbSetContenido = new List<Contenido> { contenido }.BuildMock().BuildMockDbSet();
        mockDbSetContenido
            .Setup(m => m.FindAsync(contenido.Acronimo))
            .ReturnsAsync(contenido);

        // mock DbContext
        var mockDbContext = new Mock<ApplicationDbContext>();
        mockDbContext
            .Setup(c => c.Carreras)
            .Returns(mockDbSetCarrera.Object);
        mockDbContext
            .Setup(c => c.Contenidos)
            .Returns(mockDbSetContenido.Object);
        mockDbContext
            .Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        var repository = new SqlCarreraRepository(mockDbContext.Object);
      
        // Act
        var result = await repository.AddContenidoToCarreraAsync(carrera.Codigo, contenido.Acronimo);

        // Assert
        mockDbSetCarrera
            .Verify(m => m.FindAsync(carrera.Codigo), Times.Once);
        mockDbSetContenido
            .Verify(m => m.FindAsync(contenido.Acronimo), Times.Once);
        result.Should().BeTrue(
                       because: "The contenido was successfully added to the carrera");
    }


    [Fact]
    public async Task UpdateCarreraScholarshipBudgetAsync_GivenValidCarreraAndBudget_ReturnsTrue()
    {
        // Arrange
        var carrera = new Carrera(
            codigo: Codigo.Create("420705"),
            nombre: Nombre.Create("Computación en varios enfasis"),
            escuela: Nombre.Create("Escuela de Ciencias de la Computación e Informática"),
            isSteam: true,
            presupuestoBecas: Budget.Create(0)
        );

        var budget = Budget.Create(100000);

        // mock DbSet
        var mockDbSetCarrera = new List<Carrera> { carrera }.BuildMock().BuildMockDbSet();
        mockDbSetCarrera
            .Setup(m => m.FindAsync(carrera.Codigo))
            .ReturnsAsync(carrera);

        // mock DbContext
        var mockDbContext = new Mock<ApplicationDbContext>();
        mockDbContext
            .Setup(c => c.Carreras)
            .Returns(mockDbSetCarrera.Object);
        mockDbContext
            .Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        var repository = new SqlCarreraRepository(mockDbContext.Object);
      
        // Act
        var result = await repository.UpdateCarreraScholarshipBudgetAsync(carrera.Codigo, budget);

        // Assert
        mockDbSetCarrera
            .Verify(m => m.FindAsync(carrera.Codigo), Times.Once);
        result.Should().BeTrue(
            because: "The budget was successfully updated");
    }

}
