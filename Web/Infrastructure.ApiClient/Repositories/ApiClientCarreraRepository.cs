using Microsoft.Kiota.Abstractions;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Repositories;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;
using UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.ApiClient.Client.Models;
using UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.ApiClient.Dtos;
using static UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.ApiClient.Client.AddContenidoCarrera.AddContenidoCarreraRequestBuilder;
using static UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.ApiClient.Client.CreateCarrera.CreateCarreraRequestBuilder;

namespace UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.ApiClient.Repositories;

internal class ApiClientCarreraRepository : ICarreraRepository
{
    private readonly Client.ApiClientKiota _apiClient;

    public ApiClientCarreraRepository(Client.ApiClientKiota apiClient)
    {
        _apiClient = apiClient;
    }
    public async Task<IEnumerable<Domain.Entities.Carrera>> GetCarrerasAsync()
    {
        var carrerasDtos = await _apiClient.ListCarreras.GetAsync();
        var carreraEntities = carrerasDtos?.Select(CarreraDtoMapper.ToEntity);
        if (carreraEntities == null)
        {
            return Enumerable.Empty<Domain.Entities.Carrera>();
        }
        return carreraEntities;
    }

    public async Task<bool> CreateCarreraAsync(Domain.Entities.Carrera carrera)
    {
        var requestConfiguration = new Action<RequestConfiguration<CreateCarreraRequestBuilderPostQueryParameters>>(config =>
        {
            config.QueryParameters = new CreateCarreraRequestBuilderPostQueryParameters
            {
                Codigo = carrera.Codigo.Value,
                Escuela = carrera.Escuela.Value,
                Nombre = carrera.Nombre.Value,
                IsSteam = carrera.IsSteam,
                Presupuesto = carrera.PresupuestoBecas.Value
            };
        });
        var createCarreraResponse = await _apiClient.CreateCarrera.PostAsync(requestConfiguration);
        if (createCarreraResponse != null)
        {
            bool response = (bool)createCarreraResponse;
            return response;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> AddContenidoToCarreraAsync(Domain.ValueObjects.Codigo codigoCarrera, Domain.ValueObjects.Acronimo acronimoContenido)
    {
        var requestConfiguration = new Action<RequestConfiguration<AddContenidoCarreraRequestBuilderPutQueryParameters>>(config =>
        {
            config.QueryParameters = new AddContenidoCarreraRequestBuilderPutQueryParameters
            {
                Codigo = codigoCarrera.Value,
                Acronimo = acronimoContenido.Value
            };
        });
        var createCarreraResponse = await _apiClient.AddContenidoCarrera.PutAsync(requestConfiguration);
        if (createCarreraResponse != null)
        {
            bool response = (bool)createCarreraResponse;
            return response;
        }
        else
        {
            return false;
        }
    }

    public Task<Domain.Entities.Carrera> FindCarreraAsync(Domain.ValueObjects.Codigo codigoCarrera)
    {
        throw new NotImplementedException();
    }


    public Task<bool> UpdateCarreraScholarshipBudgetAsync(Domain.ValueObjects.Codigo codigoCarrera, Domain.ValueObjects.Budget budget)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateCarreraScholarshipBudgetFrontendAsync(Domain.ValueObjects.Codigo codigoCarrera)
    {
        var codigoCarreraRequestbody = new CodigoCarreraRequest
        {
            Codigo = codigoCarrera.Value
        };

        var createCarreraResponse = await _apiClient.UpdateCarreraScholarshipBudget.PutAsync(codigoCarreraRequestbody);

        if(createCarreraResponse != null)
        {
            return createCarreraResponse.Response ?? false;
        }
        else
        {
            return false;
        }
    }

}
