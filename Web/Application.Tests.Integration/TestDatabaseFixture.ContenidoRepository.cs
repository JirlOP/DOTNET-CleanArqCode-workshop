using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.ExampleProject.Infraestructure.Tests.Integration;

public partial class TestDatabaseFixture
{
    public static IEnumerable<Contenido> Contenidos()
    {
        yield return new Contenido(
            acronimo: Acronimo.Create("EG1"),
            nombre: Nombre.Create("Humanidades 1"),
            creditos: Creditos.Create(6),
            tipo: TipoContenido.Create('s')
        );
        yield return new Contenido(
            acronimo: Acronimo.Create("EG2"),
            nombre: Nombre.Create("Humanidades 2"),
            creditos: Creditos.Create(6),
            tipo: TipoContenido.Create('s')
        );
    }

    public Contenido GetKnownContenido()
    {
        return Contenidos().First();
    }

    public Contenido GetUnknownContenido()
    {
        return new Contenido(
            acronimo: Acronimo.Create("EG3"),
            nombre: Nombre.Create("Humanidades 3"),
            creditos: Creditos.Create(6),
            tipo: TipoContenido.Create('s')
        );
    }

    //public async Task SetAllUsersAsInactiveAsync()
    //{
    //    var activeUsers = await ApplicationDbContext
    //        .Carreras
    //        .ToListAsync();

    //    activeUsers.ForEach(u => u.SetInactive());

    //    await ApplicationDbContext
    //        .SaveChangesAsync();

    //    ApplicationDbContext
    //        .ChangeTracker
    //        .Clear();
    //}
}
