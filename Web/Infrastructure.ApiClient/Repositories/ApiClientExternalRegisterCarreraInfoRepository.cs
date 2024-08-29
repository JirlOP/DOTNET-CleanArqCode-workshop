using UCR.ECCI.IS.EvaluacionTecnica.Domain.Repositories;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.ApiClient.Repositories;

internal class ApiClientExternalRegisterCarreraInfoRepository : IExternalRegisterCarreraInfoRepository
{
    public Task<Percentage> GetWomenPercentageAsync(Codigo codigo)
    {
        throw new System.NotImplementedException();
    }

    // Auxiliary method for testing purposes
    public void SetWomenPercentage(Dictionary<string, double> percentages)
    {
        throw new System.NotImplementedException();
    }
}
