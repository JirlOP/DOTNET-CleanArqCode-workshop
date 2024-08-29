namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

/// <summary>
/// Represents a Nombre value object. For Nombre Carreras and Contenidos Tables attribute.
/// </summary>
public class Nombre
{
    public string Value { get; }

    public static readonly char[] IllegalCharacters = { '/', '?', '!', '#', '@', '[', ']', ',', ';', '\'' };
    public const int MAXLENGTH = 100; // max lenght defined in the sql table

    public static readonly Nombre Invalid = new(string.Empty);

    public Nombre(string value)
    {
        // Run validation
        Value = value;
    }

    public static bool TryCreate(string? value, out Nombre Name)
    {
        // Run validation.
        Name = Invalid;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        if (value.IndexOfAny(IllegalCharacters) != -1)
        {
            return false;
        }

        if (value.Length > MAXLENGTH)
        {
            return false;
        }
        // If validation passed, then return true and assign the Name to the out parameter.
        // Otherwise, return false
        Name = new Nombre(value);
        return true;

    }

    public static Nombre Create(string? NameString)
    {
        var result = TryCreate(NameString, out var Name);
        if (!result)
        {
            throw new ArgumentException("Invalid long name.");
        }
        return Name;
    }
}