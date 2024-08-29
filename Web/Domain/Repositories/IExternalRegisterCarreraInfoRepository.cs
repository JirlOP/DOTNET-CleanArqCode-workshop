using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.Repositories;

/// <summary>
/// External Carrera Info Repository.
/// </summary>
/// <remarks>
/// Have all the info about students that are registered in the carrera.
/// </remarks>
public interface IExternalRegisterCarreraInfoRepository
{
    
    /// <summary>
    /// Get the percentage of women in the carrera.
    /// </summary>
    /// <param name="carrera"> 
    /// Carrera to get the percentage of women enrrrolled.
    /// </param>
    /// <returns>The percentaje Decimal</returns>
    public Task<Percentage> GetWomenPercentageAsync(Codigo codigo);
}
