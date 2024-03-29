namespace ExpressionStringEvaluator.Tests.Methods;

using ExpressionStringEvaluator.Methods;
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
    public void Handle_ShouldReturnTrue_WhenStringInputIsEqual()
    {
        // arrange

        // act
        var result = _sut.Handle(METHOD_NAME, ObjectHelper.CreateArray("1", "1"));

        // assert
        var boolValue = result.Should().BeOfType<bool>().Subject;
        boolValue.Should().BeTrue();
    }

    [Theory]
    [InlineData("1 ")]
    [InlineData(" 1")]
    [InlineData("adsf")]
    [InlineData("")]
    public void Handle_ShouldReturnFalse_WhenStringInputIsEqual(string input)
    {
        // arrange

        // act
        var result = _sut.Handle(METHOD_NAME, ObjectHelper.CreateArray("1", input));

        // assert
        var boolValue = result.Should().BeOfType<bool>().Subject;
        boolValue.Should().BeFalse();
    }

    [Fact]
    public void Handle_ShouldReturnTrue_WhenIntInputIsEqual()
    {
        // arrange

        // act
        var result = _sut.Handle(METHOD_NAME, ObjectHelper.CreateArray(1, 1));

        // assert
        var boolValue = result.Should().BeOfType<bool>().Subject;
        boolValue.Should().BeTrue();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(int.MaxValue)]
    public void Handle_ShouldReturnFalse_WhenIntInputIsEqual(int input)
    {
        // arrange

        // act
        var result = _sut.Handle(METHOD_NAME, ObjectHelper.CreateArray(1, input));

        // assert
        var boolValue = result.Should().BeOfType<bool>().Subject;
        boolValue.Should().BeFalse();
    }
}