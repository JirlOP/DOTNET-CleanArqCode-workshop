using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor.Pages.CarrerasInfo.Carreras;

public partial class ListContenidosCarrera
{
    private async Task AddContenidoToCarrera()
    {
        var result = await carreraService.AddContenidoToCarreraAsync(codigocarrera, Acronimo.Create(acronimoContenidoAñadido));

        if (result)
        {
            _contenidosCarrera = await contenidoService.GetContenidosCarreraAsync(codigocarrera);
        }
        if (modal != null)
        {
            await modal.HideAsync();
        }
    }
}
