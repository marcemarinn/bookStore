namespace Core.Request;

public class FilterBookRequest
{
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }

}
