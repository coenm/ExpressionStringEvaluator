namespace ExpressionStringEvaluator.Tests.Methods.Linq;

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
        var result = _sut.Handle(METHOD_NAME, ObjectHelper.CreateArrayContainer("1", "2"), 1);

        // assert
        var arrayValue = result.Should().BeOfType<object[]>().Subject;
        arrayValue.Should().BeEquivalentTo(ObjectHelper.CreateArray("1"));
    }
}