using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.IS.EvaluacionTecnica.Application.Services;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;
using UCR.ECCI.IS.EvaluacionTecnica.Presentation.Api.InfoCarreras.Requests;
using UCR.ECCI.IS.EvaluacionTecnica.Presentation.Api.InfoCarreras.Responses;

namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Api.InfoCarreras.Handlers;

public static class CarreraEndpointHandlers
{
    public static async Task<IEnumerable<Carrera>> GetCarreras(
        [FromServices] ICarreraService carreraService)
    {
        return await carreraService.GetCarrerasAsync();
    }

    public static async Task<bool> CreateCarrera(
        [FromServices] ICarreraService carreraService,
        string codigo, string nombre, string escuela, bool isSteam, double presupuesto)
    {
        Carrera carrera = new Carrera
        (
            codigo: Codigo.Create(codigo),
            nombre: Nombre.Create(nombre),
            escuela: Nombre.Create(escuela),
            isSteam: isSteam,
            presupuestoBecas: Budget.Create(presupuesto)
        );
        return await carreraService.CreateCarreraAsync(carrera);
    }

    public static async Task<bool> AddContenidoCarrera(
        [FromServices] ICarreraService carreraService,
        string codigo, string acronimo)
    {
        return await carreraService.AddContenidoToCarreraAsync(
            Codigo.Create(codigo),
            Acronimo.Create(acronimo)
        );
    }

    public static async Task<StatusResponse> UpdateCarreraScholarshipBudget(
        [FromServices] ICarreraService carreraService,
        [FromBody] CodigoCarreraRequest codigoCarreraRequest)
    {
        var response = await carreraService.UpdateCarreraScholarshipBudgetAsync(
            Codigo.Create(codigoCarreraRequest.Codigo)
        );
        return new StatusResponse(response);
    }
}
