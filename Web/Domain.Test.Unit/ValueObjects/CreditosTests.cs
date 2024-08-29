using FluentAssertions;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.Test.Unit.ValueObjects;

public class CreditosTests
{
    [Fact]
    public void TryCreate_WhenValueIsNull_ReturnsFalse()
    {
        // Arrange
        var inputValue = (byte?)null;

        // Act
        var result = Creditos.TryCreate(inputValue, out var output);

        // Assert
        result.Should().BeFalse("Because the input value is null");
    }

    [Fact]
    public void TryCreate_WhenValueIsTooLarge_ReturnsFalse()
    {
        // Arrange
        byte inputValue = 200;

        // Act
        var result = Creditos.TryCreate(inputValue, out var output);

        // Assert
        result.Should().BeFalse("Because the input value is too long");
    }

    [Fact]
    public void TryCreate_WhenValueIsValid_ReturnsTrue()
    {
        // Arrange
        // 4 creditos
        byte inputValue = 4;

        // Act
        var result = Creditos.TryCreate(inputValue, out var output);

        // Assert
        result.Should().BeTrue("Because the input value is valid");
    }
}