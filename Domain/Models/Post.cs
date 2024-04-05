namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public int Published { get; set; }
}