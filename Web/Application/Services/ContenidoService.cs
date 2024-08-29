using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Repositories;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Application.Services;

public class ContenidoService : IContenidoService
{
    private readonly IContenidoRepository _ContenidoRepository;

    public ContenidoService(IContenidoRepository ContenidoRepository)
    {
        _ContenidoRepository = ContenidoRepository;
    }

    public Task<IEnumerable<Contenido>> GetContenidosAsync()
    {
        return _ContenidoRepository.GetContenidosAsync();
    }

    public Task<IEnumerable<Contenido>> GetContenidosCarreraAsync(Codigo codigoCarrera)
    {
        return _ContenidoRepository.GetContenidosCarreraAsync(codigoCarrera);
    }

    public Task<bool> CreateContenidosAsync(Contenido contenidos)
    {
        return _ContenidoRepository.CreateContenidosAsync(contenidos);
    }
}
