namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

/// <summary>
/// Represents a Acronimo value object. For Acronimo Contenidos Table attribute.
/// </summary>
public class Acronimo
{
    public string Value { get; }

    public static readonly char[] IllegalCharacters = { '/', '?', '!', '#', '@', '[', ']', ',', ';', '\'' };
    public const int MAXLENGTH = 6; // max lenght defined in the sql table

    public static readonly Acronimo Invalid = new(string.Empty);

    public Acronimo(string value)
    {
        // Run validation
        Value = value;
    }

    public static bool TryCreate(string? value, out Acronimo Acronimo)
    {
        // Run validation.
        Acronimo = Invalid;
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
        // If validation passed, then return true and assign the Acronimo to the out parameter.
        // Otherwise, return false
        Acronimo = new Acronimo(value);
        return true;

    }

    public static Acronimo Create(string? AcronimoString)
    {
        var result = TryCreate(AcronimoString, out var Acronimo);
        if (!result)
        {
            throw new ArgumentException("Invalid long Acronimo.");
        }
        return Acronimo;
    }
}