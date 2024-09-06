using FluentAssertions;
using NSubstitute;
using Test.Src.UnitTests.Dependencies;
using Test.Src.UnitTests.Dependencies.DependencyRelationship;

namespace Tests.UnitTest.Dependencies.DependencyRelationship;
public class CartTests
{
    //[Fact]
    //public void AddItemToCard_ShouldFail_IfNotLoggedIn()
    //{
    //    var auth = new UserAuthentication();
    //    var cart = new Cart(auth);

    //    Assert.Throws<InvalidOperationException>(() => cart.AddItemToCart("iPhone"));
    //}

    //[Fact]
    //public void SerachAndAddItem_shoulBeIndependent()
    //{
    //    var search = new Search();
    //    var serachItem = search.SearchItem("iPhone");

    //    var auth = new UserAuthentication();
    //    var cart = new Cart(auth);

    //    Assert.Throws<InvalidOperationException>(() => cart.AddItemToCart(serachItem));
    //}

    [Fact]
    public void Cart_shouldCalculateTotalCorectly()
    {
        var cart = new Cart();
        cart.AddItemToCart(new CartItem { Name = "Iphone", Amount = 1 });
        cart.AddItemToCart(new CartItem { Name = "Samsung", Amount = 2 });
        cart.AddItemToCart(new CartItem { Name = "Ipad", Amount = 3 });
        cart.AddItemToCart(new CartItem { Name = "xiaumi", Amount = 4 });

        var result = cart.CalculateTotal();

        result.Should().Be(10);
    }


    [Fact]
    public void Payment_ShouldProcessCorrectly_WithDefferentMethod()
    {
        PaymentMethod method1 = new CreditCardPayment();
        PaymentMethod method2 = new PayPalPaymentMethod();

        method1.Process(100m).Should().BeTrue();
        method2.Process(100m).Should().BeTrue();
    }

    [Fact]
    public void Receipt_ShouldGenerateCorectly()
    {
        var goods = new List<Good>
        {
            new Good
            {
                Amount = 5m,
                Name = "NaneBarbari"
            },
            new Good
            {
                Amount = 2m,
                Name = "NaneSangak"
            }
        };
        PaymentMethod method1 = new CreditCardPayment();
        var receipt = new Receipt(goods, method1);

        receipt.GenerateReceipt().Length.Should().BeGreaterThan(1);
    }

    [Fact]
    public void Receipt_ShouldGenerateCorectly_SendData()
    {
        ApiClient apiClient = new ApiClient();

        var receipt = new OrderService(apiClient);

        receipt.SendData("Test").Should().BeTrue();
    }

    [Fact]
    public void Receipt_ShouldGenerateInCorectly_SendData()
    {
        var apicleint = Substitute.For<IApiClient>();

        apicleint.GetKey(Arg.Any<string>()).Returns((str) => throw new Exception());

        var receipt = new OrderService(apicleint);

        receipt.SendData("Test").Should().BeFalse();
    }
}
