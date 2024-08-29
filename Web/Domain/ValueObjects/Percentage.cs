using System.Linq;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

/// <summary>
/// Value Object that represents the type of content of the article.
/// </summary>
/// <remarks>
/// Made it with TDD.
/// </remarks>
public class Percentage
{
    public double Value { get; }

    public static readonly Percentage Invalid = new(double.NaN);

    public Percentage(double value)
    {
        // Run validation
        Value = value;
    }

    public static bool TryCreate(double? value, out Percentage percentage)
    {
        // Run validation.
        percentage = Invalid;

        if (!value.HasValue)
        {
            return false;
        }
        if (double.IsNaN(value.Value))
        {
            return false;
        }
        if (double.IsInfinity(value.Value))
        {
            return false;
        }
        if (value.Value < 0.0)
        {
            return false;
        }
        if (value.Value > 1.0)
        {
            return false;
        }

        percentage = new Percentage(value.Value);
        return true;
    }

    public static Percentage Create(double? percentageDouble)
    {
        var result = TryCreate(percentageDouble, out var percentage);
        if (!result)
        {
            throw new ArgumentException("Invalid Budget.");
        }
        return percentage;
    }
}