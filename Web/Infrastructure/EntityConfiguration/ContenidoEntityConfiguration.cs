using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.Entities;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.EntityConfiguration;

internal class ContenidoEntityConfiguration : IEntityTypeConfiguration<Contenido>
{
    public void Configure(EntityTypeBuilder<Contenido> builder)
    {
        builder.ToTable("Contenidos");
        builder.HasKey(cont => cont.Acronimo);

        builder.Property(cont => cont.Acronimo)
            .IsRequired()
            .HasMaxLength(Acronimo.MAXLENGTH)
            .HasConversion(
                // C# -> SQL conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: nameString => Acronimo.Create(nameString)
            );

        builder.Property(cont => cont.Nombre)
            .IsRequired()
            .HasMaxLength(Nombre.MAXLENGTH)
            .HasConversion(
                // C# -> SQL conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: nameString => Nombre.Create(nameString)
            );

        builder.Property(cont => cont.Creditos)
            .IsRequired()
            .HasMaxLength(Creditos.MaxValue)
            .HasConversion(
                // C# -> SQL conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: creditosByte => Creditos.Create(creditosByte)
            );

        builder.Property(cont => cont.Tipo)
            .HasConversion(
                // C# -> SQL conversion
                convertToProviderExpression: valueObject => valueObject.Value,
                // SQL -> C# conversion
                convertFromProviderExpression: tipoChar => TipoContenido.Create(tipoChar)
            );



    }
}
