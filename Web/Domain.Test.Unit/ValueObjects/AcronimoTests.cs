using FluentAssertions;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.Test.Unit.ValueObjects;

public class AcronimoTests
{
    [Fact]
    public void TryCreate_WhenValueIsNull_ReturnsFalse()
    {
        // Arrange
        var inputValue = (string?)null;

        // Act
        var result = Acronimo.TryCreate(inputValue, out var output);

        // Assert
        result.Should().BeFalse("Because the input value is null");
    }

    [Fact]
    public void TryCreate_WhenValueIsEmpty_ReturnsFalse()
    {
        // Arrange
        var inputValue = string.Empty;

        // Act
        var result = Acronimo.TryCreate(inputValue, out var output);

        // Assert
        result.Should().BeFalse("Because the input value is empty");
    }

    [Fact]
    public void TryCreate_WhenValueHasIllegalCharacters_ReturnsFalse()
    {
        // Arrange
        var inputValue = "A/B";

        // Act
        var result = Acronimo.TryCreate(inputValue, out var output);

        // Assert
        result.Should().BeFalse("Because the input value have illegal characters");
    }

    [Fact]
    public void TryCreate_WhenValueIsTooLong_ReturnsFalse()
    {
        // Arrange
        var inputValue = "1234567";

        // Act
        var result = Acronimo.TryCreate(inputValue, out var output);

        // Assert
        result.Should().BeFalse("Because the input value is too long");
    }

    [Fact]
    public void TryCreate_WhenValueIsValid_ReturnsTrue()
    {
        // Arrange
        var inputValue = "CI0124";

        // Act
        var result = Acronimo.TryCreate(inputValue, out var output);

        // Assert
        result.Should().BeTrue("Because the input value is valid");
    }
}