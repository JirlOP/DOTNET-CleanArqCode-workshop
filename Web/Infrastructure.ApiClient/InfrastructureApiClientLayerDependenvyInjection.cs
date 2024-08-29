using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.CoreServices;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Repositories;
using UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.ApiClient.Repositories;

namespace UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.ApiClient;

public static class InfrastructureApiClientLayerDependenvyInjection
{
    public static IServiceCollection AddInfrastructureApiClientLayerServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IAuthenticationProvider, AnonymousAuthenticationProvider>();
        services.AddScoped<IRequestAdapter, HttpClientRequestAdapter>(serviceProvider =>
        {
            var adapter = new HttpClientRequestAdapter(
                serviceProvider.GetRequiredService<IAuthenticationProvider>(),
                httpClient: serviceProvider.GetRequiredService<HttpClient>());

            // Step 3: Define the base URL.
            adapter.BaseUrl = configuration["DownstreamApi:BaseUrl"];

            return adapter;
        });

        services.AddScoped<Client.ApiClientKiota>();
        services.AddScoped<ICarreraRepository, ApiClientCarreraRepository>();
        services.AddScoped<IContenidoRepository, ApiClientContenidoRepository>();
        // This services are not necessary for the current implementation
        services.AddScoped<ICarreraBudgetCalculatorCoreService, ApiClientCarreraBudgetCalculatorRepository>();
        services.AddScoped<IExternalRegisterCarreraInfoRepository, ApiClientExternalRegisterCarreraInfoRepository>();


        return services;
    }
}

