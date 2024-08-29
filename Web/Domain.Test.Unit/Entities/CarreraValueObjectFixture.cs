using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.Test.Unit.Entities;

public class CarreraValueObjectFixture
{
    // VO values on Carrera
    private const string codigoValue = "123456";
    private const string nombreValue = "Ingeniería en Computación";
    private const string escuelaValue = "Escuela de Ciencias de la Computación e Informática";
    private const double presupuestoBecasValue = 2000.0;

    // VO fixtures
    public Codigo Codigo { get; }

    public Nombre Nombre { get; }

    public Nombre Escuela { get; }

    public Budget PresupuestoBecas { get; set; }

    public CarreraValueObjectFixture()
    {
        Codigo = Codigo.Create(codigoValue);
        Nombre = Nombre.Create(nombreValue);
        Escuela = Nombre.Create(escuelaValue);
        PresupuestoBecas = Budget.Create(presupuestoBecasValue);
    }

}