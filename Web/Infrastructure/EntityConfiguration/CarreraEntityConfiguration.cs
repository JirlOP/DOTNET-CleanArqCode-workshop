using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.EntityConfiguration;

internal class CarreraEntityConfiguration : IEntityTypeConfiguration<Carrera>
{
    public void Configure(EntityTypeBuilder<Carrera> builder)
    {
        builder.ToTable("Carreras");
        builder.HasKey(u => u.Codigo);

        builder.Property(u => u.Codigo)
            .IsRequired()
            .HasMaxLength(Codigo.MAXLENGTH)
            .HasConversion(
                // C# -> SQL conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: nameString => Codigo.Create(nameString)
            );

        builder.Property(u => u.Nombre)
            .IsRequired()
            .HasMaxLength(Nombre.MAXLENGTH)
            .HasConversion(
                // C# -> SQL conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: nameString => Nombre.Create(nameString)
            );

        builder.Property(u => u.Escuela)
            .IsRequired()
            .HasMaxLength(Nombre.MAXLENGTH)
            .HasConversion(
                // C# -> SQL conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: nameString => Nombre.Create(nameString)
            );

        builder.Property(u => u.IsSteam)
            .IsRequired();

        builder.Property(u => u.PresupuestoBecas)
            .HasConversion(
                // C# -> SQL conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: budget => Budget.Create(budget)
            );
    }
}
