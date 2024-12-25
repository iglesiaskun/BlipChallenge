namespace ChallengeAPI.Models;

public class ApiValue
{
    public string Title { get; set; }
    public string Text { get; set; }
    public string Type { get; set; } = "image/jpeg";
    public string Uri { get; set; }
}