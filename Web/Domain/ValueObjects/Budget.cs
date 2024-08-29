using System.Linq;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

/// <summary>
/// Value Object that represents the type of content of the article.
/// </summary>
public class Budget
{
    public double Value { get; }

    public static readonly Budget Invalid = new(double.NaN);

    public Budget(double value)
    {
        // Run validation
        Value = value;
    }

    public static bool TryCreate(double? value, out Budget type)
    {
        // Run validation.
        type = Invalid;

        if (!value.HasValue)
        {
            return false;
        }
        if (double.IsNaN(value.Value))
        {
            return false;
        }
        if(double.IsInfinity(value.Value))
        {
            return false;
        }
        if (value.Value < 0.0)
        {
            return false;
        }

        type = new Budget(value.Value);
        return true;
    }

    public static Budget Create(double? budgetDouble)
    {
        var result = TryCreate(budgetDouble, out var budget);
        if (!result)
        {
            throw new ArgumentException("Invalid Budget.");
        }
        return budget;
    }
}