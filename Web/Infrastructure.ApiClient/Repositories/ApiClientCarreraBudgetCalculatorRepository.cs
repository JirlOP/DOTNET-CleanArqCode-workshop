using UCR.ECCI.IS.EvaluacionTecnica.Domain.CoreServices;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.ApiClient.Repositories;

internal class ApiClientCarreraBudgetCalculatorRepository : ICarreraBudgetCalculatorCoreService
{
    public Budget CalculateCarreraScholarshipBudget(
        Percentage womenPercentage,
        Carrera carrera,
        IEnumerable<Contenido> contenidos)
    {
        throw new System.NotImplementedException();
    }

}
