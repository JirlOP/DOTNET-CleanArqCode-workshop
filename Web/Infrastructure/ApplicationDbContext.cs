using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;

namespace UCR.ECCI.IS.EvaluacionTecnica.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<Contenido> Contenidos { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { 
    }


    [Obsolete("Is only used to mocking/testing purposes. DO NOT use it in production code.")]
    internal ApplicationDbContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureEntityRelationship(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void ConfigureEntityRelationship(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrera>()
            .HasMany(carrera => carrera.Contenidos)
            .WithMany(contenido => contenido.Carreras);
    }

}
