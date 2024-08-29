using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Application.Test.Unit.Services;

public class CarreraServiceFixture
{
    public IEnumerable<Carrera> Carreras { get; set; }

    public IEnumerable<Contenido> Contenidos { get; set; }

    public Percentage WomenPercentage { get; set; }

    public Codigo CodigoCarrera { get; set; }

    public Budget ScholarshipBudget { get; set; }

    public CarreraServiceFixture()
    {
        Carreras =
        [
            new Carrera(
                codigo: Codigo.Create("340301"),
                nombre: Nombre.Create("Ciencias Politicas"),
                escuela: Nombre.Create("Escuela de Ciencias Politicas"),
                isSteam: false,
                presupuestoBecas: Budget.Create(1500.0)
            ),
            new Carrera(
                codigo: Codigo.Create("420705"),
                nombre: Nombre.Create("Ciencias de la Computacion"),
                escuela: Nombre.Create("Escuela de Ciencias de la Computacion"),
                isSteam: true,
                presupuestoBecas: Budget.Create(2000.0)
            ),
        ];

        Contenidos =
        [
            new Contenido(
                acronimo: Acronimo.Create("CI0110"),
                nombre: Nombre.Create("Introducción a la Computación"),
                creditos: Creditos.Create(4),
                tipo: TipoContenido.Create('t')
            ),
            new Contenido(
                acronimo: Acronimo.Create("CP1501"),
                nombre: Nombre.Create("Epistemologia y logica de pensamiento"),
                creditos: Creditos.Create(4),
                tipo: TipoContenido.Create('s')
            ),
        ];

        WomenPercentage = Percentage.Create(0.5);
        CodigoCarrera = Codigo.Create("340301");
        ScholarshipBudget = Budget.Create(1500.0);
    }
}
