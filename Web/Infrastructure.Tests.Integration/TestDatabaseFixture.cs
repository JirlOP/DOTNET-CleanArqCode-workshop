using Microsoft.EntityFrameworkCore;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Infrastructure;

namespace UCR.ECCI.IS.ExampleProject.Infraestructure.Tests.Integration;

public partial class TestDatabaseFixture
{
    public const string TestConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ET2Test;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public ApplicationDbContext ApplicationDbContext { get; }

    public TestDatabaseFixture()
    {
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(TestConnectionString);
        ApplicationDbContext = new(dbContextOptionsBuilder.Options);
    }

    public async Task FillDatabaseAsync()
    {
        // Delete all existing carreras
        await ApplicationDbContext
            .Carreras
            .ExecuteDeleteAsync();

        // Delete all existing contenidos
        await ApplicationDbContext
            .Contenidos
            .ExecuteDeleteAsync();


        // Re-add carreras and contenidos
        await ApplicationDbContext
            .Carreras
            .AddRangeAsync(Carreras());

        await ApplicationDbContext
            .Contenidos
            .AddRangeAsync(Contenidos());

        await ApplicationDbContext
            .SaveChangesAsync();

        // Clear change tracker
        ApplicationDbContext
            .ChangeTracker
            .Clear();
    }

    public async Task AddContenidosToFirstCarreraAsync()
    {

        // fill all contenidos to first carrera
        var carrera = Carreras().First();
        var contenidos = Contenidos().ToList();
        foreach (var contenido in contenidos)
        {
            carrera.Contenidos.Add(contenido);
        }
        
        ApplicationDbContext
            .Carreras
            .Update(carrera);

        await ApplicationDbContext
            .SaveChangesAsync();

        // Clear change tracker
        ApplicationDbContext
            .ChangeTracker
            .Clear();
    }

    public async Task EraseTablesAsync()
    {
        await ApplicationDbContext
            .Carreras
            .ExecuteDeleteAsync();

        await ApplicationDbContext
            .Contenidos
            .ExecuteDeleteAsync();

        ApplicationDbContext
            .ChangeTracker
            .Clear();
    }
}
