namespace ChallengeAPI.Models;

public class ApiResponse
{
    public string ItemType { get; set; } = "application/vnd.lime.document-select+json";
    public List<ApiItem> Items { get; set; } = new List<ApiItem>();
}