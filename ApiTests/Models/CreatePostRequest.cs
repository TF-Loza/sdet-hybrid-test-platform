namespace ApiTests.Models;

public class CreatePostRequest
{
    public int UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}