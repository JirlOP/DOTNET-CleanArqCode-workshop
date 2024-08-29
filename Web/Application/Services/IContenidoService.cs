using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Application.Services;

public interface IContenidoService
{

    public Task<IEnumerable<Contenido>> GetContenidosAsync();

    public Task<IEnumerable<Contenido>> GetContenidosCarreraAsync(Codigo codigoCarrera);

    public Task<bool> CreateContenidosAsync(Contenido contenidos);
}
