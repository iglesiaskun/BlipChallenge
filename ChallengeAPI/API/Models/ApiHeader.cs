namespace ChallengeAPI.Models;

public class ApiHeader
{
    public string Type { get; set; } = "application/vnd.lime.media-link+json";
    public ApiValue Value { get; set; }
}