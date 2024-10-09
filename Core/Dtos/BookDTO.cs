namespace Core.Dtos;

public class BookDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; }
    public string Gender { get; set; } = string.Empty;
    public  bool isActive{ get; set; }

}
