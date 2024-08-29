namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor.Pages.CarrerasInfo.Carreras;

public partial class ListCarreras
{
    protected override async Task OnInitializedAsync()
    {
        _carreras = await carrerraService.GetCarrerasAsync();
    }

}
