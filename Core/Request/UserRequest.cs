namespace Core.Request;

public class UserRequest
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string PassWordHash { get; set; } = string.Empty;

}
