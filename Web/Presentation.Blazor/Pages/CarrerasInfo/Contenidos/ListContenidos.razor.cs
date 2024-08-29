using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;

namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor.Pages.CarrerasInfo.Contenidos;

public partial class ListContenidos
{
    // HTML attributes
    private bool dense = false;
    private bool hover = true;
    private bool striped = false;
    private bool bordered = false;

    // List of carreras
    private IEnumerable<Contenido>? _contenidos;
}
