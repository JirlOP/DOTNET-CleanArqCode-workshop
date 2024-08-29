using FluentAssertions;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.Test.Unit.ValueObjects;

/// <summary>
/// This class contains the unit tests for the Percentage value object
/// This was TDD developed
/// </summary>
public class PercentageTests
{

    /* TryCreate tests */
    [Fact]
    public void TryCreate_WhenValueIsNull_ReturnsFalse()
    {
        // Arrange
        var inputValue = (double?)null;

        // Act
        var result = Percentage.TryCreate(inputValue, out var output);

        // Assert
        result.Should().BeFalse("Because the input value is null");
    }

    [Fact]
    public void TryCreate_WhenValueIsNaN_ReturnsFalse()
    {
        // Arrange
        double inputValue = double.NaN;

        // Act
        var result = Percentage.TryCreate(inputValue, out var output);

        // Assert
        result.Should().BeFalse("Because the input value is NaN");
    }

    // infinities
    [Theory]
    [InlineData(double.NegativeInfinity)]
    [InlineData(double.PositiveInfinity)]
    public void TryCreate_WhenValueIsInfinity_ReturnsFalse(double inputValue)
    {
        // Act
        var result = Percentage.TryCreate(inputValue, out var output);

        // Assert
        result.Should().BeFalse("Because the input value is infinity");
    }

    [Fact]
    public void TryCreate_WhenValueIsNegative_ReturnsFalse()
    {
        // Arrange
        double inputValue = -0.1;

        // Act
        var result = Percentage.TryCreate(inputValue, out var output);

        // Assert
        result.Should().BeFalse("Because the input value is negative");
    }

    [Fact]
    public void TryCreate_WhenValueIsGreaterThanOne_ReturnsFalse()
    {
        // Arrange
        double inputValue = 1.1;

        // Act
        var result = Percentage.TryCreate(inputValue, out var output);

        // Assert
        result.Should().BeFalse("Because the input value is greater than 1");
    }

    [Fact]
    public void TryCreate_WhenValueIsValid_ReturnsTrue()
    {
        // Arrange
        double inputValue = 0.5;

        // Act
        var result = Percentage.TryCreate(inputValue, out var output);

        // Assert
        result.Should().BeTrue("Because the input value is valid");
    }

    // boundaries
    [Fact]
    public void TryCreate_WhenValueIsZero_ReturnsTrue()
    {
        // Arrange
        double inputValue = 0.0;

        // Act
        var result = Percentage.TryCreate(inputValue, out var output);

        // Assert
        result.Should().BeTrue("Because the input value is valid");
    }

    [Fact]
    public void TryCreate_WhenValueIsOne_ReturnsTrue()
    {
        // Arrange
        double inputValue = 1.0;

        // Act
        var result = Percentage.TryCreate(inputValue, out var output);

        // Assert
        result.Should().BeTrue("Because the input value is valid");
    }

    /* Create tests */
    [Fact]
    public void Create_WhenValueIsNull_ThrowsArgumentException()
    {
        // Arrange
        double? inputValue = null;

        // Act
        Action act = () => Percentage.Create(inputValue);

        // Assert
        act.Should().Throw<ArgumentException>("Because the input value is null");
    }

    [Fact]
    public void Create_WhenValueIsNegative_ThrowsArgumentException()
    {
        // Arrange
        double inputValue = -0.1;

        // Act
        Action act = () => Percentage.Create(inputValue);

        // Assert
        act.Should().Throw<ArgumentException>("Because the input value is negative");
    }

    [Fact]
    public void Create_WhenValueIsGreaterThanOne_ThrowsArgumentException()
    {
        // Arrange
        double inputValue = 1.1;

        // Act
        Action act = () => Percentage.Create(inputValue);

        // Assert
        act.Should().Throw<ArgumentException>("Because the input value is greater than 1");
    }

    [Fact]
    public void Create_WhenValueIsValid_ReturnsPercentage()
    {
        // Arrange
        double inputValue = 0.5;

        // Act
        var result = Percentage.Create(inputValue);

        // Assert
        result.Should().BeOfType<Percentage>("Because the input value is valid");
    }

    // boundaries
    [Fact]
    public void Create_WhenValueIsZero_ReturnsPercentage()
    {
        // Arrange
        double inputValue = 0.0;

        // Act
        var result = Percentage.Create(inputValue);

        // Assert
        result.Should().BeOfType<Percentage>("Because the input value is valid");
    }

    [Fact]
    public void Create_WhenValueIsOne_ReturnsPercentage()
    {
        // Arrange
        double inputValue = 1.0;

        // Act
        var result = Percentage.Create(inputValue);

        // Assert
        result.Should().BeOfType<Percentage>("Because the input value is valid");
    }
}
