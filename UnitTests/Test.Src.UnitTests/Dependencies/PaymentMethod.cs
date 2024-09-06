namespace Test.Src.UnitTests.Dependencies;
public abstract class PaymentMethod
{
    public abstract bool Process(decimal amount);
}

public class CreditCardPayment : PaymentMethod
{
    public override bool Process(decimal amount)
    {
        return true;
    }
}

public class PayPalPaymentMethod : PaymentMethod
{
    public override bool Process(decimal amount)
    {
        return true;
    }
}