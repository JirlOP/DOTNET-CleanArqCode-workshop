using Riok.Mapperly.Abstractions;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Infrastructure.ApiClient.Dtos;

[Mapper]
internal static partial class ContenidoDtoMapper
{
    internal static partial Domain.Entities.Contenido ToEntity(Client.Models.Contenido carreraDto);

    internal static Acronimo ToValueObject(Client.Models.Acronimo acronimoDto)
    {
        return Acronimo.Create(acronimoDto.Value);
    }

    internal static Nombre ToValueObject(Client.Models.Nombre nombreDto)
    {
        return Nombre.Create(nombreDto.Value);
    }

    internal static Creditos ToValueObject(Client.Models.Creditos creditosDto)
    {
        return Creditos.Create(((byte?)creditosDto.Value));
    }

    internal static TipoContenido ToValueObject(Client.Models.TipoContenido tipoContenidoDto)
    {
        if (tipoContenidoDto.Value == null)
            return TipoContenido.Create(null);
        return TipoContenido.Create(tipoContenidoDto.Value[0]);
    }

}
