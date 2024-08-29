using Microsoft.EntityFrameworkCore;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Repositories;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.Repositories;

internal class SqlContenidoRepository : IContenidoRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SqlContenidoRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Contenido>> GetContenidosAsync()
    {
        return await _dbContext.Contenidos.ToListAsync();
    }

    public async Task<IEnumerable<Contenido>> GetContenidosCarreraAsync(Codigo codigoCarrera)
    {
         var result = await _dbContext
            .Contenidos
            .Where(contenido => contenido.Carreras.Any(carrera => carrera.Codigo == codigoCarrera))
            .ToListAsync();
        return result;
    }

    public async Task<bool> CreateContenidosAsync(Contenido contenidos)
    {
        try
        {
            await _dbContext.Contenidos.AddAsync(contenidos);
            var rowsAffected = await _dbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }
        catch
        {
            return false;
        }
    }

}
