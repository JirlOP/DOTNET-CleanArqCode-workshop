using UCR.ECCI.IS.EvaluacionTecnica.Domain.CoreServices;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Repositories;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Application.Services;

public class CarreraService : ICarreraService
{
    private readonly ICarreraRepository _carreraRepository;

    // DI of auxiliary repositories
    private readonly ICarreraBudgetCalculatorCoreService _carreraBudgetCalculatorCoreService;
    private readonly IExternalRegisterCarreraInfoRepository _externalRegisterCarreraInfoRepository;
    private readonly IContenidoRepository _contenidoRepository;

    public CarreraService(ICarreraRepository carreraRepository,
        ICarreraBudgetCalculatorCoreService carreraBudgetCalculatorCoreService,
        IExternalRegisterCarreraInfoRepository externalRegisterCarreraInfoRepository,
        IContenidoRepository contenidoRepository)
    {
        _carreraRepository = carreraRepository;
        _carreraBudgetCalculatorCoreService = carreraBudgetCalculatorCoreService;
        _externalRegisterCarreraInfoRepository = externalRegisterCarreraInfoRepository;
        _contenidoRepository = contenidoRepository;
    }

    public async Task<bool> AddContenidoToCarreraAsync(Codigo codigoCarrera, Acronimo acronimoContenido)
    {
        return await _carreraRepository.AddContenidoToCarreraAsync(codigoCarrera, acronimoContenido);
    }


    public async Task<IEnumerable<Carrera>> GetCarrerasAsync()
    {
        return await _carreraRepository.GetCarrerasAsync();
    }        

    public async Task<bool> CreateCarreraAsync(Carrera carrera)
    {
        return await _carreraRepository.CreateCarreraAsync(carrera);
    }

    public async Task<bool> UpdateCarreraScholarshipBudgetAsync(Codigo codigo)
    {
        // first calculate the new budget
        var womenPercentage = await _externalRegisterCarreraInfoRepository
            .GetWomenPercentageAsync(codigo);
        // then call the repository to update the budget of each carrera
        var carrera = await _carreraRepository.FindCarreraAsync(codigo);
        var contenidos = await _contenidoRepository.GetContenidosCarreraAsync(codigo);
        var scholarshipBudget = _carreraBudgetCalculatorCoreService
            .CalculateCarreraScholarshipBudget(womenPercentage, carrera, contenidos);

        // lastly call the repository to update the budget of each carrera
        return await _carreraRepository.UpdateCarreraScholarshipBudgetAsync(codigo, scholarshipBudget);
    }

    public async Task<bool> UpdateCarreraScholarshipBudgetFrontendAsync(Codigo codigoCarrera)
    {
        return await _carreraRepository.UpdateCarreraScholarshipBudgetFrontendAsync(codigoCarrera);
    }

}
