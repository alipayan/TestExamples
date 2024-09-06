namespace Test.Src.UnitTests.Dependencies;
public class Receipt
{
    private List<Good> goods;

    private PaymentMethod paymentMethod;

    public Receipt(List<Good> goods, PaymentMethod paymentMethod)
    {
        this.goods = goods;
        this.paymentMethod = paymentMethod;
    }

    public string GenerateReceipt()
    {
        var total = goods.Sum(x => x.Amount);
        return $"Total: {total} and paid with PaymentMethod:{paymentMethod.GetType().Name}";
    }

}

public class Good
{
    public string Name { get; set; }
    public decimal Amount { get; set; }
}
