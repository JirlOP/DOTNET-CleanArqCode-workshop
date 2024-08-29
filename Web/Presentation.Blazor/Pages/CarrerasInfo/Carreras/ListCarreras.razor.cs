using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;

namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor.Pages.CarrerasInfo.Carreras;

public partial class ListCarreras
{
    // is loading
    private bool IsLoadingContents { get; set; } = false;

    // filter functions
    private string searchString = "";

    // HTML attributes
    private bool dense = false;
    private bool hover = true;
    private bool striped = false;
    private bool bordered = false;

    // List of carreras
    private IEnumerable<Carrera>? _carreras;

}
