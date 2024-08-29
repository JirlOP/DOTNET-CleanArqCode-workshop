using Microsoft.Kiota.Abstractions;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Repositories;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;
using UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.ApiClient.Dtos;
using static UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.ApiClient.Client.CreateContenidos.CreateContenidosRequestBuilder;
using static UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.ApiClient.Client.ListContenidosCarrera.ListContenidosCarreraRequestBuilder;

namespace UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.ApiClient.Repositories;

internal class ApiClientContenidoRepository : IContenidoRepository
{
    private readonly Client.ApiClientKiota _apiClient;

    public ApiClientContenidoRepository(Client.ApiClientKiota apiClient)
    {
        _apiClient = apiClient;
    }


    public async Task<IEnumerable<Contenido>> GetContenidosAsync()
    {
        var contenidosDtos = await _apiClient.ListContenidos.GetAsync();
        var contenidosEntities = contenidosDtos?.Select(ContenidoDtoMapper.ToEntity)
            ?? throw new NullReferenceException();
        return contenidosEntities;
    }


    public async Task<IEnumerable<Contenido>> GetContenidosCarreraAsync(Codigo codigoCarrera)
    {
        try {
            var requestConfiguration = new Action<RequestConfiguration<ListContenidosCarreraRequestBuilderGetQueryParameters>>(config =>
            {
                config.QueryParameters = new ListContenidosCarreraRequestBuilderGetQueryParameters
                {
                    CodigoCarrera = codigoCarrera.Value
                };
            });
            var contenidosDtos = await _apiClient.ListContenidosCarrera.GetAsync(requestConfiguration);

            var contenidoEntities = contenidosDtos?.Select(ContenidoDtoMapper.ToEntity)
                ?? throw new NullReferenceException();

            return contenidoEntities;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al listar los contenidos", ex);
        }
    }

    public async Task<bool> CreateContenidosAsync(Contenido contenidos)
    {
        try
        {
            var requestconfiguration = new Action<RequestConfiguration<CreateContenidosRequestBuilderPostQueryParameters>>(config =>
            {
                config.QueryParameters = new CreateContenidosRequestBuilderPostQueryParameters
                {
                    Acronimo = contenidos.Acronimo.Value,
                    Creditos = contenidos.Creditos.Value,
                    Nombre = contenidos.Nombre.Value,
                    Tipo = contenidos.Tipo.Value.ToString()
                };
            });
            var contenidosresponse = await _apiClient.CreateContenidos.PostAsync(requestconfiguration);
            if (contenidosresponse != null)
            {
                bool response = (bool)contenidosresponse;
                return response;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("error al crear los contenidos de la carrera", ex);
        }
    }
}
