using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.IS.EvaluacionTecnica.Application.Services;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Api.InfoCarreras.Handlers;

public static class ContenidoEndpointHandlers
{
    public static async Task<IEnumerable<Contenido>> GetContenidos(
        [FromServices] IContenidoService contenidoService)
    {
        return await contenidoService.GetContenidosAsync();
    }

    public static async Task<IEnumerable<Contenido>> GetContenidosCarrera(
        [FromServices] IContenidoService contenidoService,
        string codigoCarrera)
    {
        return await contenidoService.GetContenidosCarreraAsync(
            Codigo.Create(codigoCarrera));
    }

    public static async Task<bool> CreateContenidos(
        [FromServices] IContenidoService contenidoService,
        string acronimo, string nombre, byte creditos, char tipo)
    {
        Contenido contenido = new Contenido
        (
            acronimo: Acronimo.Create(acronimo),
            nombre: Nombre.Create(nombre),
            creditos: Creditos.Create(creditos),
            tipo: TipoContenido.Create(tipo)
        );
        return await contenidoService.CreateContenidosAsync(contenido);
    }
}
