namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

/// <summary>
/// Represents a Codigo value object. For Codigo Carrera Table attribute. 
/// </summary>
public class Codigo
{

    public string Value { get; }

    // legal characters are [0-9]
    public static readonly string LegalCharacters = "0123456789";

    public const int MAXLENGTH = 6; // max lenght defined in the sql table

    public static readonly Codigo Invalid = new(string.Empty);

    private Codigo (string value)
    {
        Value = value;
    }

    public static bool TryCreate(string? value, out Codigo codigo)
    {
        codigo = Invalid;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        if (value.Any(c => !LegalCharacters.Contains(c)))
        {
            return false;
        }

        if (value.Length > MAXLENGTH)
        {
            return false;
        }

        codigo = new Codigo(value);
        return true;
    }

    public static Codigo Create(string? value)
    {
        var result = TryCreate(value, out var codigo);
        if (!result)
        {
            throw new ArgumentException("Invalid codigo.");
        }
        return codigo;
    }
}
