using FluentAssertions;
using Test.Src.UnitTests.Example3;

namespace Tests.UnitTest.Example3;
public class DiscountCalculatorTests
{
    [Theory]
    [InlineData(MembershipLevel.None, 100, 100)]
    [InlineData(MembershipLevel.Silver, 100, 95)]
    [InlineData(MembershipLevel.Silver, 200, 190)]
    [InlineData(MembershipLevel.Gold, 100, 90)]
    [InlineData(MembershipLevel.Gold, 200, 180)]
    [InlineData(MembershipLevel.Platinum, 100, 80)]
    [InlineData(MembershipLevel.Platinum, 500, 400)]
    public void CalcaulteDiscount_ShouldReturnExpectedDiscount(MembershipLevel level, decimal totalAmount, decimal expectedAmount)
    {
        // arrange

        var sut = new DiscountCalculator();

        // act
        var result = sut.CalculateDiscount(totalAmount, level);

        // assert
        result.Should().Be(expectedAmount);
    }
}
