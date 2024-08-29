using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.Test.Unit.Entities;

public class ContenidoValueObjectFixture
{
    // VO values on Contenido
    private const string acronimoValue = "123456";
    private const string nombreValue = "Ingenieria en Software";
    private const byte creditosValue = 10;
    private const char tipoValueT = 't';
    private const char tipoValueS = 's';
    private const char tipoValueA = 'a';

    // VO fixtures
    public Acronimo Acronimo { get; }
    public Nombre Nombre { get; }
    public Creditos Creditos { get; }
    public TipoContenido Tipo { get; private set; }

    /// <summary>
    /// Constructor for the ContenidoValueObjectFixture.
    /// Type is set to tecnologico by default.
    /// </summary>
    public ContenidoValueObjectFixture()
    {
        Acronimo = Acronimo.Create(acronimoValue);
        Nombre = Nombre.Create(nombreValue);
        Creditos = Creditos.Create(creditosValue);
        Tipo = TipoContenido.Create(tipoValueT);
    }

    // methods to change tipoValue 
    public void SetUpTipoTecnologico()
    {
        Tipo = TipoContenido.Create(tipoValueT);
    }

    public void SetUpTipoSocial()
    {
        Tipo = TipoContenido.Create(tipoValueS);
    }

    public void SetUpTipoAmbiental()
    {
        Tipo = TipoContenido.Create(tipoValueA);
    }
}