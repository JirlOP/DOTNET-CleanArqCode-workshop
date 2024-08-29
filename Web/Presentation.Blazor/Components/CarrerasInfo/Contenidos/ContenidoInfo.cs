using System.ComponentModel.DataAnnotations;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor.Components.CarrerasInfo.Contenidos;

public class ContenidoInfo
{
    [StringLength(maximumLength: Codigo.MAXLENGTH, MinimumLength = Codigo.MAXLENGTH,
    ErrorMessage = "El acrónimo del contenido debe ser tamaño 6.")]
    [Required(ErrorMessage = "El acrónimo del contenido debe ser asignado")]
    public string? acronimo { get; set; }

    [StringLength(maximumLength: Nombre.MAXLENGTH,
        ErrorMessage = "El nombre del contenido debe ser tamaño menor a 100.")]
    [Required(ErrorMessage = "El nombre del contenido debe ser asignado")]
    public string? nombre { get; set; }

    [Range(Creditos.MinValue, Creditos.MaxValue,
        ErrorMessage = "Los créditos del conteido debe estar entre 0 a 10")]
    [Required(ErrorMessage = "Los créditos del contenido debe ser asignado")]
    public byte creditos { get; set; }

}
