namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Api.RegisterCommander;

/// <summary>
/// Class that represents the commander of the endpoints.
/// Is used to manage the endpoints.
/// The Command pattern was used to implement this class.
/// </summary>
internal interface IEndpointCommander
{
    /// <summary>
    /// Method that registers the endpoints.
    /// </summary>
    internal void RegisterEndpoints(IEndpointRouteBuilder routeBuilder, string route, string name, Delegate handler);
}
