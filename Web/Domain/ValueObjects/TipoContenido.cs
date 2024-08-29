using System.Linq;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

/// <summary>
/// Value Object that represents the type of content of the article.
/// </summary>
public class TipoContenido
{
    public char Value { get; }

    // the types of contents are: tecnologico, social, ambiental y otros
    public static readonly char[] LegalCharacters = { 't', 's', 'a', 'o' };

    public static readonly TipoContenido Invalid = new(char.MinValue);

    public TipoContenido(char value)
    {
        // Run validation
        Value = value;
    }

    public static bool TryCreate(char? value, out TipoContenido Type)
    {
        // Run validation.
        Type = Invalid;
        if (value == null)
        {
            return false;
        }

        if (!LegalCharacters.Contains((char)value))
        {
            return false;
        }

        Type = new TipoContenido((char)value);
        return true;
    }

    public static TipoContenido Create(char? NameString)
    {
        var result = TryCreate(NameString, out var TipoContenido);
        if (!result)
        {
            throw new ArgumentException("Invalid Type, must be: t, s, a or o.");
        }
        return TipoContenido;
    }
}