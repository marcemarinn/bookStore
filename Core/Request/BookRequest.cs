namespace Core.Request;

public class BookRequest
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; } 
    public string Gender { get; set; } = string.Empty;
    public bool IsActive { get; set; }


}
