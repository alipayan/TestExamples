namespace Test.Src.UnitTests.Dependencies;


public class ApiClient : IApiClient
{
    public string GetKey(string user)
        => "access_token";
}

public interface IApiClient
{
    public string GetKey(string user)
        => "access_token";
}
public class OrderService
{
    private readonly IApiClient _client;

    public OrderService(IApiClient client)
    {
        _client = client;
    }

    public bool SendData(string orderData)
    {
        try
        {
            _client.GetKey(orderData);

            return true;
        }
        catch
        {
            return false;
        }
    }
}
