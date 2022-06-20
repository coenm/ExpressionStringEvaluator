namespace ExpressionStringEvaluator.Tests.Methods.Linq;

using ExpressionStringEvaluator.Methods;
using ExpressionStringEvaluator.Methods.Linq;
using ExpressionStringEvaluator.Tests.TestHelpers;
using FluentAssertions;
using Xunit;

public class FirstMethodTest
{
    private const string METHOD_NAME = "First";
    private readonly FirstMethod _sut;

    public FirstMethodTest()
    {
        _sut = new FirstMethod();
    }

    [Theory]
    [InlineData("First")]
    [InlineData("first")]
    [InlineData("FIRST")]
    [InlineData("FiRsT")]
    public void CanHandle_ShouldReturnTrue_WhenMethodIsCorrect(string methodName)
    {
        _sut.CanHandle(methodName).Should().BeTrue();
    }

    [Theory]
    [InlineData(" First")]
    [InlineData("First ")]
    [InlineData(" First ")]
    [InlineData("XFirst")]
    [InlineData("FirstX")]
    [InlineData("")]
    [InlineData(null!)]
    public void CanHandle_ShouldReturnFalse_WhenMethodIsNotCorrect(string methodName)
    {
        _sut.CanHandle(methodName).Should().BeFalse();
    }

    [Fact]
    public void Handle_ShouldReturnSubArrayArray_WhenInputIsArray()
    {
        // arrange

        // act
        CombinedTypeContainer result = _sut.Handle(METHOD_NAME, CombinedTypeContainerHelper.CreateArrayContainer("1", "2"), new CombinedTypeContainer(1));

        // assert
        result.IsString(out string? stringValue).Should().BeTrue();
        stringValue.Should().Be("1");
    }
}