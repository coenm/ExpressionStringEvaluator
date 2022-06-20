namespace ExpressionStringEvaluator.Tests.Methods.Linq;

using ExpressionStringEvaluator.Methods;
using ExpressionStringEvaluator.Methods.Linq;
using ExpressionStringEvaluator.Tests.TestHelpers;
using FluentAssertions;
using Xunit;

public class CountMethodTest
{
    private const string METHOD_NAME = "Count";
    private readonly CountMethod _sut;

    public CountMethodTest()
    {
        _sut = new CountMethod();
    }

    [Theory]
    [InlineData("Count")]
    [InlineData("count")]
    [InlineData("COUNT")]
    [InlineData("CoUnt")]
    public void CanHandle_ShouldReturnTrue_WhenMethodIsCorrect(string methodName)
    {
        _sut.CanHandle(methodName).Should().BeTrue();
    }

    [Theory]
    [InlineData(" Count")]
    [InlineData("Count ")]
    [InlineData(" Count ")]
    [InlineData("XCount")]
    [InlineData("CountX")]
    [InlineData("")]
    [InlineData(null!)]
    public void CanHandle_ShouldReturnFalse_WhenMethodIsNotCorrect(string methodName)
    {
        _sut.CanHandle(methodName).Should().BeFalse();
    }

    [Fact]
    public void Handle_ShouldReturnInteger_WhenInputIsArray()
    {
        // arrange

        // act
        CombinedTypeContainer result = _sut.Handle(METHOD_NAME, CombinedTypeContainerHelper.CreateArray("1", "2"));

        // assert
        result.IsInt(out var intValue).Should().BeTrue();
        intValue.Should().Be(2);
    }
}