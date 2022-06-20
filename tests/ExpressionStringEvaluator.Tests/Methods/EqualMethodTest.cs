namespace ExpressionStringEvaluator.Tests.Methods;

using ExpressionStringEvaluator.Methods;
using ExpressionStringEvaluator.Methods.Linq;
using ExpressionStringEvaluator.Tests.TestHelpers;
using FluentAssertions;
using Xunit;

public class EqualMethodTest
{
    private const string METHOD_NAME = "Equal";
    private readonly EqualMethod _sut;

    public EqualMethodTest()
    {
        _sut = new EqualMethod();
    }

    [Theory]
    [InlineData("Equal")]
    [InlineData("equal")]
    [InlineData("EQUAL")]
    [InlineData("EquaL")]
    public void CanHandle_ShouldReturnTrue_WhenMethodIsCorrect(string methodName)
    {
        _sut.CanHandle(methodName).Should().BeTrue();
    }

    [Theory]
    [InlineData(" Equal")]
    [InlineData("Equal ")]
    [InlineData(" Equal ")]
    [InlineData("XEqual")]
    [InlineData("EqualX")]
    [InlineData("")]
    [InlineData(null!)]
    public void CanHandle_ShouldReturnFalse_WhenMethodIsNotCorrect(string methodName)
    {
        _sut.CanHandle(methodName).Should().BeFalse();
    }

    [Fact]
    public void Handle_ShouldReturnTrue_WhenInputIsEqual()
    {
        // arrange

        // act
        CombinedTypeContainer result = _sut.Handle(
            METHOD_NAME, CombinedTypeContainerHelper.CreateArray("1", "1"));

        // assert
        result.IsBool(out var boolValue).Should().BeTrue();
        boolValue.Should().BeTrue();
    }
}