using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Application.Services;

public interface ICarreraService
{
    public Task<IEnumerable<Carrera>> GetCarrerasAsync();

    public Task<bool> CreateCarreraAsync(Carrera carrera);

    public Task<bool> AddContenidoToCarreraAsync(Codigo codigoCarrera, Acronimo acronimoContenido);

    public Task<bool> UpdateCarreraScholarshipBudgetAsync(Codigo codigo);

    // Only for Frontend
    public Task<bool> UpdateCarreraScholarshipBudgetFrontendAsync(Codigo codigoCarrera);

}
