using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.CoreServices;

public interface ICarreraBudgetCalculatorCoreService
{
    /// <summary>
    /// Calculate the budget for a Carrera based on Contenidos and student percentage
    /// </summary>
    /// <param name="codigo">Carrera code</param>
    /// <param name="womenPercentage">Women percentage</param>
    /// <returns>Dolars of budget</returns>
    public Budget CalculateCarreraScholarshipBudget(
        Percentage womenPercentage,
        Carrera carrera,
        IEnumerable<Contenido> contenidos
    );
}
