using UCR.ECCI.IS.EvaluacionTecnica.Presentation.Api.InfoCarreras.Handlers;
using UCR.ECCI.IS.EvaluacionTecnica.Presentation.Api.RegisterCommander;

namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Api.InfoCarreras;

public static class InfoCarreraEndpoints
{
    private static readonly List<(IEndpointCommander command,
        string route, string name, Delegate handler)> endpointCommands =
        new List<(IEndpointCommander command, string route, string name, Delegate handler)>
        {
            // Carreras ndpoints
            (new GetEndpointCommand(), "/list-carreras", "GetCarreras", CarreraEndpointHandlers.GetCarreras),
            (new PostEndpointCommand(), "/create-carrera", "CreateCarrera", CarreraEndpointHandlers.CreateCarrera),
            (new PutEndpointCommand(), "/add-contenido-carrera", "AddContenidoCarrera", CarreraEndpointHandlers.AddContenidoCarrera),
            (new PutEndpointCommand(), "/update-carrera-scholarship-budget", "UpdateCarreraScholarshipBudget", CarreraEndpointHandlers.UpdateCarreraScholarshipBudget),
        
            // Contenidos endpoints
            (new GetEndpointCommand(), "/list-contenidos", "GetContenidos", ContenidoEndpointHandlers.GetContenidos),
            (new GetEndpointCommand(), "/list-contenidos-carrera", "GetContenidosCarrera", ContenidoEndpointHandlers.GetContenidosCarrera),
            (new PostEndpointCommand(), "/create-contenidos", "CreateContenidos", ContenidoEndpointHandlers.CreateContenidos),
        };

        /// <summary>
        /// Method that registers the endpoints of a list of commands.
        /// </summary>
        /// <param name="routeBuilder"></param>
        /// <returns></returns>
    public static IEndpointRouteBuilder RegisterInfoCarreraEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        // iterate over the endpointCommands list and register each endpoint
        foreach (var (command, route, name, handler) in endpointCommands)
        {
            command.RegisterEndpoints(routeBuilder, route, name, handler);
        }

        return routeBuilder;
    }
}

