using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.Repositories;

public interface IContenidoRepository
{

    /// <summary>
    /// Get all contents.
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<Contenido>> GetContenidosAsync();

    /// <summary>
    /// Get all contents of a career.
    /// </summary>
    /// <param name="codigoCarrera"> 
    /// Career code to get the contents.
    /// </param>
    /// <returns></returns>
    public Task<IEnumerable<Contenido>> GetContenidosCarreraAsync(Codigo codigoCarrera);

    /// <summary>
    /// Create a new content for a career.
    /// </summary>
    /// <param name="contenidos">
    /// Content to create.
    /// </param>
    /// <returns></returns>
    public Task<bool> CreateContenidosAsync(Contenido contenidos);
}
