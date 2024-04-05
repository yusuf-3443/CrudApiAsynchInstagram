namespace Domain.Models;

public class Comment
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public string Title { get; set; }
    public int Published { get; set; }
    public string Context { get; set; }
}