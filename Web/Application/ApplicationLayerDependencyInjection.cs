using Microsoft.Extensions.DependencyInjection;
using UCR.ECCI.IS.EvaluacionTecnica.Application.Services;

namespace UCR.ECCI.IS.EvaluacionTecnica.Application;

public static class ApplicationLayerDependencyInjection
{
    public static IServiceCollection AddApplicationLayerServices(this IServiceCollection services)
    {
        services.AddScoped<ICarreraService, CarreraService>();
        services.AddScoped<IContenidoService, ContenidoService>();

        return services;
    }
}
