using Microsoft.EntityFrameworkCore;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;
using UCR.ECCI.IS.EvaluacionTecnica.Infrastructure;

namespace UCR.ECCI.IS.ExampleProject.Infraestructure.Tests.Integration;

public partial class TestDatabaseFixture
{
    public static IEnumerable<Carrera> Carreras()
    {
        yield return new Carrera(
            codigo: Codigo.Create("600123"),
            nombre: Nombre.Create("Gestion de los Recursos Naturales"),
            escuela: Nombre.Create("Escuela de Ciencias Ambientales"),
            isSteam: false,
            presupuestoBecas: Budget.Create(0)
        );
        yield return new Carrera(
            codigo: Codigo.Create("420705"),
            nombre: Nombre.Create("Computación en varios enfasis"),
            escuela: Nombre.Create("Escuela de Ciencias de la Computación e Informática"),
            isSteam: true,
            presupuestoBecas: Budget.Create(0)
        );
    }

    public Carrera GetCarreraWithContenidos()
    {
        return Carreras().First();
    }

    public Carrera GetCarreraWithoutContenidos()
    {
        return Carreras().Last();
    }
}
