using FluentAssertions;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;


namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.Test.Unit.ValueObjects;

public class BudgetTests
{
    [Theory]
    // Valid values
    [InlineData(0.0)]
    // positive equivalence class
    [InlineData(100.0)]
    public void TryCreate_WithValidValue_ShouldReturnTrue(double value)
    {
        // Act
        var result = Budget.TryCreate(value, out var budget);

        // Assert
        result.Should().BeTrue(because: "the Budget value is valid");
    }

    [Theory]
    // Invalid values
    [InlineData(null)]
    [InlineData(double.NaN)]
    // boundaries
    [InlineData(double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity)]
    // negative values enquivalence class
    [InlineData(-1.0)]
    public void TryCreate_WithInvalidValue_ShouldReturnFalse(double? value)
    {
        // Act
        var result = Budget.TryCreate(value, out var budget);

        // Assert
        result.Should().BeFalse(because: "the Budget value is invalid");
    }

    [Theory]
    // Valid values
    [InlineData(0.0)]
    // positive equivalence class
    [InlineData(100.0)]
    public void Create_WithValidValue_ShouldBeCreated(double value)
    {
        // Act
        var budget = Budget.Create(value);

        // Assert
        budget.Value.Should().Be(value,
            because: "the Budget value is valid and the Budget should be created");
    }

    [Theory]
    [InlineData(null)]
    [InlineData(double.NaN)]
    [InlineData(double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity)]
    [InlineData(-1.0)]
    public void Create_WithInvalidValue_ShouldThrowArgumentException(double? value)
    {
        // Act
        Action act = () => Budget.Create(value);

        // Assert
        act.Should().Throw<ArgumentException>(
            because: "the Budget value is invalid");
    }
}
