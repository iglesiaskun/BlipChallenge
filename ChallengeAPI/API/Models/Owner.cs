using Newtonsoft.Json;

namespace ChallengeAPI.Models;

public class Owner
{
    [JsonProperty("avatar_url")]
    public string AvatarUrl { get; set; }
}