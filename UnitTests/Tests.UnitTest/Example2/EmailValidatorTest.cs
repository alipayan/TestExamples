using FluentAssertions;
using Test.Src.UnitTests.Example2;

namespace Tests.UnitTest.Example2;
public class EmailValidatorTest
{
    [Theory]
    [InlineData("a", false)]
    [InlineData("a@.com", false)]
    [InlineData(".@.com", false)]
    [InlineData("b.@sum#.com", true)]
    [InlineData("", false)]
    [InlineData(null, false)]
    [InlineData("alipayan@gmail.com", true)]
    public void IsEmailValid_ShouldReturnExpectedResult(string email, bool expectedResult)
    {
        // arrange
        var sut = new EmailValidator();

        // fact
        var result = sut.IsValidEmail(email);

        // assert
        result.Should().Be(expectedResult);
    }
}
