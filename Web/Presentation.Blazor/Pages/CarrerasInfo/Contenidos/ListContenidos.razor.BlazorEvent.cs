namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor.Pages.CarrerasInfo.Contenidos;

public partial class ListContenidos
{
    protected override async Task OnInitializedAsync()
    {
        base.OnInitialized();

        _contenidos = await contenidoService.GetContenidosAsync();
    }
}
