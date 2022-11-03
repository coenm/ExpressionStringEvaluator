namespace ExpressionStringEvaluator.Tests.Methods.Linq;

using System;
using ExpressionStringEvaluator.Methods.Linq;
using ExpressionStringEvaluator.Tests.TestHelpers;
using FluentAssertions;
using Xunit;

public class SkipMethodTest
{
    private const string METHOD_NAME = "Skip";
    private readonly SkipMethod _sut;

    public SkipMethodTest()
    {
        _sut = new SkipMethod();
    }

    [Theory]
    [InlineData("Skip")]
    [InlineData("skip")]
    [InlineData("SKIP")]
    [InlineData("SkIP")]
    public void CanHandle_ShouldReturnTrue_WhenMethodIsCorrect(string methodName)
    {
        _sut.CanHandle(methodName).Should().BeTrue();
    }

    [Theory]
    [InlineData(" Skip")]
    [InlineData("Skip ")]
    [InlineData(" Skip ")]
    [InlineData("XSkip")]
    [InlineData("SkipX")]
    [InlineData("")]
    [InlineData(null!)]
    public void CanHandle_ShouldReturnFalse_WhenMethodIsNotCorrect(string methodName)
    {
        _sut.CanHandle(methodName).Should().BeFalse();
    }

    [Fact]
    public void Handle_ShouldReturnSkippedArray_WhenInputIsArray()
    {
        // arrange

        // act
        var result = _sut.Handle(METHOD_NAME, ObjectHelper.CreateArrayContainer("1", "2"), 1);

        // assert
        if (result is object[] arrayValue)
        {
            arrayValue.Should().BeEquivalentTo(ObjectHelper.CreateArray("2"));
        }
        else
        {
            throw new Exception();
        }
    }
}