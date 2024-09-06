namespace Test.Src.UnitTests.Dependencies.DependencyRelationship;
public class UserAuthentication
{
    public bool IsAuthenticated { get; set; }

    public void Login(string username, string password)
    {
        IsAuthenticated = true;
    }
}
