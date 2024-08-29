namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor.Pages.CarrerasInfo.Carreras;

public partial class ListContenidosCarrera
{
    private async Task AddAcronimoContenidos()
    {
        var acronimoContenidosAdicionales = _acronimoContenidos.Except(_acronimoContenidosCarrera);
        _acronimoContenidosAdicionales = acronimoContenidosAdicionales.ToList();

        if (modal != null)
        {
            await modal.ShowAsync();
        }
    }
}
