using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.Repositories;

public interface ICarreraRepository
{
    public Task<IEnumerable<Carrera>> GetCarrerasAsync();

    public Task<bool> CreateCarreraAsync(Carrera carrera);

    public Task<bool> AddContenidoToCarreraAsync(Codigo codigoCarrera, Acronimo acronimoContenido);

    public Task<bool> UpdateCarreraScholarshipBudgetAsync(Codigo codigoCarrera, Budget budget);

    public Task<Carrera> FindCarreraAsync(Codigo codigoCarrera);

    // Only for Frontend
    public Task<bool> UpdateCarreraScholarshipBudgetFrontendAsync(Codigo codigoCarrera);


}
