using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;

namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor.Pages.CarrerasInfo.Carreras;

public partial class ListCarreras
{
    private bool SearchCall(Carrera element) => Search(element, searchString);
    private bool Search(Carrera element, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (element.Nombre.Value.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    }
}
