namespace ExpressionStringEvaluator.Tests.Methods.Linq;

using ExpressionStringEvaluator.Methods;
using ExpressionStringEvaluator.Methods.Linq;
using ExpressionStringEvaluator.Tests.TestHelpers;
using FluentAssertions;
using Xunit;

public class TakeMethodTest
{
    private const string METHOD_NAME = "Take";
    private readonly TakeMethod _sut;

    public TakeMethodTest()
    {
        _sut = new TakeMethod();
    }

    [Theory]
    [InlineData("Take")]
    [InlineData("take")]
    [InlineData("TAKE")]
    [InlineData("TaKe")]
    public void CanHandle_ShouldReturnTrue_WhenMethodIsCorrect(string methodName)
    {
        _sut.CanHandle(methodName).Should().BeTrue();
    }

    [Theory]
    [InlineData(" Take")]
    [InlineData("Take ")]
    [InlineData(" Take ")]
    [InlineData("XTake")]
    [InlineData("TakeX")]
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
        result.IsArray(out CombinedTypeContainer[]? arrayValue).Should().BeTrue();
        arrayValue.Should().BeEquivalentTo(CombinedTypeContainerHelper.CreateArray("1"));
    }
}