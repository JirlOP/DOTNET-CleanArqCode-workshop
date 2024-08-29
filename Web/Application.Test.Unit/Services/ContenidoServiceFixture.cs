using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Application.Test.Unit.Services;

public class ContenidoServiceFixture
{
    public IEnumerable<Contenido> Contenidos { get; set; }

    public IEnumerable<Contenido> ContenidosCarrera { get; set; }

    public Codigo CodigoCarreraHappyPath { get; set; }
    public Codigo CodigoCarreraSadPath { get; set; }

    public ContenidoServiceFixture()
    {
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

        ContenidosCarrera =
        [
            new Contenido(
                acronimo: Acronimo.Create("CI0110"),
                nombre: Nombre.Create("Introducción a la Computación"),
                creditos: Creditos.Create(4),
                tipo: TipoContenido.Create('t')
            )
        ];

        CodigoCarreraHappyPath = Codigo.Create("420705");
        CodigoCarreraSadPath = Codigo.Create("420706");
    }
}
