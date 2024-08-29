using System.ComponentModel.DataAnnotations;

namespace UCR.ECCI.IS.EvaluacionTecnica.Presentation.Blazor.Components.CarrerasInfo.Carreras;

public class CarreraInfo
{
    [StringLength(maximumLength: Domain.ValueObjects.Codigo.MAXLENGTH,
    MinimumLength = Domain.ValueObjects.Codigo.MAXLENGTH,
    ErrorMessage = "El codigo de carrera debe ser tamaño 6.")]
    [RegularExpression("\\d+",
    ErrorMessage = "El codigo solo acepta numeros")]
    [Required(ErrorMessage = "El código de la carrera debe ser asignado")]
    public string? Codigo { get; set; }

    [StringLength(maximumLength: Domain.ValueObjects.Nombre.MAXLENGTH,
        ErrorMessage = "El codigo de carrera debe ser tamaño menor a 100.")]
    [Required(ErrorMessage = "El nombre de la carrera debe ser asignado")]
    public string? Nombre { get; set; }

    [StringLength(maximumLength: Domain.ValueObjects.Nombre.MAXLENGTH,
        ErrorMessage = "El codigo de carrera debe ser tamaño menor a 100.")]
    [Required(ErrorMessage = "El nombre de la escuela debe ser asignado")]
    public string? Escuela { get; set; }

    public bool IsSteam { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "El presupuesto de becas debe ser mayor o igual a 0")]
    public double PresupuestoBecas { get; set; }
}
