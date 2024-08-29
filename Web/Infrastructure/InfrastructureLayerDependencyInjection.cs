using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.CoreServices;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Repositories;
using UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.Repositories;

namespace UCR.ECCI.IS.EvaluacionTecnica.Infrastructure;

public static class InfrastructureLayerDependencyInjection
{
    public static IServiceCollection AddInfrastructureLayerServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<ICarreraRepository, SqlCarreraRepository>();
        services.AddScoped<IContenidoRepository, SqlContenidoRepository>();
        services.AddScoped<ICarreraBudgetCalculatorCoreService, CarreraBudgetCalculatorCoreService>();
        services.AddScoped<IExternalRegisterCarreraInfoRepository, ExternalRegisterCarreraInfoRepository>();
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}
