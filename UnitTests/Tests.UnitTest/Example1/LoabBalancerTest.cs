using FluentAssertions;
using Test.Src.UnitTests.Example1;

namespace Tests.UnitTest.Example1;
public class LoabBalancerTest
{
    private readonly LoadBalancer _sut;

    // setup
    public LoabBalancerTest()
    {
        var connections = new[] { "conn1", "conn2", "conn3" };
        _sut = new LoadBalancer(connections);
    }

    [Fact]
    public void MoveNext_ShouldRouteThroughConnections()
    {
        // act
        var tenant1 = _sut.MoveNext();
        var tenant2 = _sut.MoveNext();
        var tenant3 = _sut.MoveNext();
        var tenant4 = _sut.MoveNext();

        // assert
        tenant1.ConnectionString.Should().Be("conn1");
        tenant1.Id.Should().Be(1);
        tenant1.Predicate.Should().Be('a');

        tenant2.ConnectionString.Should().Be("conn2");
        tenant2.Id.Should().Be(2);
        tenant2.Predicate.Should().Be('b');

        tenant3.ConnectionString.Should().Be("conn3");
        tenant3.Id.Should().Be(3);
        tenant3.Predicate.Should().Be('c');

        tenant4.ConnectionString.Should().Be("conn1");
        tenant4.Id.Should().Be(1);
        tenant4.Predicate.Should().Be('a');
    }

    [Theory]
    [InlineData('a', "conn1")]
    [InlineData('b', "conn2")]
    [InlineData('c', "conn3")]
    public void GetConnectionStringByPredicateId_ShouldReturnCorrectConnectionString(char act, string excepted)
    {
        // act
        var conn1 = _sut.GetConnectionStringByPredicateId(act);

        // assert
        conn1.Should().Be(excepted);
    }

    [Fact]
    public void GetConnectionStringByPredicateId_ShouldTrowExceptionInMaxIndex()
    {
        // act
        var connFunc = () => _sut.GetConnectionStringByPredicateId('d');

        // assert
        connFunc.Should().Throw<IndexOutOfRangeException>();
    }

}
