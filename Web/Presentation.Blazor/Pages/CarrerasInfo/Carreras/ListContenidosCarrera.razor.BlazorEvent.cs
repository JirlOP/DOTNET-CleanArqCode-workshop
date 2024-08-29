using System.Web;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor.Pages.CarrerasInfo.Carreras;

public partial class ListContenidosCarrera
{
    protected override async Task OnInitializedAsync()
    {
        // Obtener el objeto Building de la URL
        var uri = new Uri(NavigationManager.Uri);

        // Get the query parameters
        string query = uri.Query;

        // Parse the query parameters
        var queryParams = HttpUtility.ParseQueryString(query);

        // Access the parameters
        codigoCarreraString = queryParams["Codigo"] ?? string.Empty;
        nombreCarreraString = queryParams["Nombre"] ?? string.Empty;
        escuelaCarreraString = queryParams["Escuela"] ?? string.Empty;
        isSteamString = queryParams["IsSteam"] ?? string.Empty;
        presupuestoCarreraString = queryParams["PresupuestoBecas"] ?? string.Empty;

        codigocarrera = Codigo.Create(codigoCarreraString);

        _contenidosCarrera = await contenidoService.GetContenidosCarreraAsync(codigocarrera);
        _contenidos = await contenidoService.GetContenidosAsync();

        _acronimoContenidosCarrera = _contenidosCarrera.Select(c => c.Acronimo.Value);
        _acronimoContenidos = _contenidos.Select(c => c.Acronimo.Value);
    }
}
