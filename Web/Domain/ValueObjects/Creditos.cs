namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

/// <summary>
/// Represents a Creditos value object. For Contenidos Table Creditos attribute.
/// </summary>
public class Creditos
{
    public byte Value { get; private set; }

    // min value is 0
    private static Creditos Invalid => new(byte.MaxValue);

    public const byte MinValue = byte.MinValue;
    public const byte MaxValue = 10;

    private Creditos(byte value)
    {
        Value = value;
    }

    public static bool TryCreate(byte? value, out Creditos CreditosOutput)
    {
        // Run validation.
        CreditosOutput = Invalid;
        if (!value.HasValue)
        {
            return false;
        }
        if (value < MinValue || value > MaxValue)
        {
            return false;
        }

        CreditosOutput = new Creditos(value.Value);

        return true;
    }

    public static Creditos Create(byte? CreditosValue)
    {
        var validation = TryCreate(CreditosValue, out var CreditosOutput);
        if (!validation)
        {
            throw new ArgumentException("Invalid Creditos.");
        }
        return CreditosOutput;
    }
}
