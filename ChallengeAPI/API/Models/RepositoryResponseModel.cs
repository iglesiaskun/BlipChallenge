using Newtonsoft.Json;

namespace ChallengeAPI.Models;

public class RepositoryResponseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Owner Owner { get; set; }
    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }
}