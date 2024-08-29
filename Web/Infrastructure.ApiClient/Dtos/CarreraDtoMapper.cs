using Riok.Mapperly.Abstractions;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;
namespace UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.ApiClient.Dtos;

[Mapper]
internal static partial class CarreraDtoMapper
{
    internal static partial Domain.Entities.Carrera ToEntity(Client.Models.Carrera carreraDto);

    internal static Codigo ToValueObject(Client.Models.Codigo codigoDto)
    {
        return Codigo.Create(codigoDto.Value);
    }

    internal static Nombre ToValueObject(Client.Models.Nombre nombreDto)
    {
        return Nombre.Create(nombreDto.Value);
    }
    
    internal static Budget ToValueObject(Client.Models.Budget budgetDto)
    {
        return Budget.Create(budgetDto.Value);
    }

}
