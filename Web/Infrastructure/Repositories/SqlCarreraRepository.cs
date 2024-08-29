using Microsoft.EntityFrameworkCore;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Repositories;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.Repositories;

internal class SqlCarreraRepository : ICarreraRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SqlCarreraRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Carrera>> GetCarrerasAsync()
    {
        return await _dbContext.Carreras.ToListAsync();
    }

    public async Task<bool> CreateCarreraAsync(Carrera carrera)
    {
        try
        {
            await _dbContext.Carreras.AddAsync(carrera);
            var rowsAffected = await _dbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> AddContenidoToCarreraAsync(Codigo codigoCarrera, Acronimo acronimoContenido)
    {
        try
        {
            var targetCarrera = await _dbContext.Carreras.FindAsync(codigoCarrera) ?? throw new InvalidOperationException("Carrera not found");
            var targetContenido = await _dbContext.Contenidos.FindAsync(acronimoContenido) ?? throw new InvalidOperationException("Contenido not found");
            targetCarrera.Contenidos.Add(targetContenido);
            var rowsAffected = await _dbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateCarreraScholarshipBudgetAsync(Codigo codigoCarrera, Budget budget)
    {
        try
        {
            // update only PresupuestoBecas column
            var targetCarrera = await _dbContext.Carreras.FindAsync(codigoCarrera) ?? throw new InvalidOperationException("Carrera not found");
            targetCarrera.PresupuestoBecas = budget;
            var rowsAffected = await _dbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }
        catch
        {
            return false;
        }
    }

    public async Task<Carrera> FindCarreraAsync(Codigo codigoCarrera)
    {
        return await _dbContext.Carreras.FindAsync(codigoCarrera)
            ?? throw new InvalidOperationException("Carrera not found");
    }

    public Task<bool> UpdateCarreraScholarshipBudgetFrontendAsync(Codigo codigoCarrera)
    {
        throw new NotImplementedException();
    }


}
