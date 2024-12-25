namespace ChallengeAPI.Models;

public class ApiItem
{
    public ApiHeader Header { get; set; }
    public List<object> Options { get; set; } = new List<object>();
}