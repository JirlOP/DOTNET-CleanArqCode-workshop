using FluentAssertions;
using UCR.ECCI.IS.EvaluacionTecnica.Domain.ValueObjects;

namespace UCR.ECCI.IS.EvaluacionTecnica.Domain.Test.Unit.ValueObjects;

public class TipoContenidoTests
{
    [Fact]
    public void TryCreate_WhenValueIsNull_ReturnsFalse()
    {
        // Arrange
        var inputValue = (char?)null;

        // Act
        var result = TipoContenido.TryCreate(inputValue, out var output);

        // Assert
        result.Should().BeFalse("Because the input value is null");
    }

    [Fact]
    public void TryCreate_WhenValueHasIllegalCharacters_ReturnsFalse()
    {
        // Arrange
        //legal characters are: t, s, a or o
        var inputValue = 'z';

        // Act
        var result = TipoContenido.TryCreate(inputValue, out var output);

        // Assert
        result.Should().BeFalse("Because the input value have illegal characters");
    }

    [Fact]
    public void TryCreate_WhenValueIsLegal_ReturnsTrue()
    {
        // Arrange
        //legal characters are: t, s, a or o
        var inputValue = 't';

        // Act
        var result = TipoContenido.TryCreate(inputValue, out var output);

        // Assert
        result.Should().BeTrue("Because the input value is t");
    }

    [Fact]
    public void Create_WhenValueIsLegal_ReturnsTipoContenido()
    {
        // Arrange
        //legal characters are: t, s, a or o
        var inputValue = 't';

        // Act
        var result = TipoContenido.Create(inputValue);

        // Assert
        result.Value.Should().Be(inputValue, "Because the input value is t");
    }

    [Theory]
    [InlineData(null)]
    [InlineData('z')]
    public void Create_WhenValueIsIllegal_ThrowsArgumentException(char? inputValue)
    {
        // Arrange
        //legal characters are: t, s, a or o

        // Act
        Action act = () => TipoContenido.Create(inputValue);

        // Assert
        act.Should().Throw<ArgumentException>("Because the input value have illegal characters");
    }
}
