namespace Test.Src.UnitTests.Dependencies.DependencyRelationship;
public class Cart
{
    private readonly List<CartItem> Items = [];


    public bool AddItemToCart(CartItem cartItem)
    {
        Items.Add(cartItem);

        return true;
    }

    public decimal CalculateTotal()
    {
        var total = 0m;
        foreach (CartItem cartItem in Items)
        {
            total += cartItem.Amount;
        }
        return total;
    }
}


public class CartItem
{
    public string Name { get; set; }

    public decimal Amount { get; set; }
}