using ChallengeAPI.Models;
using Newtonsoft.Json;

namespace ChallengeAPI.Repositories;

public class GitHubRepository : IGitHubRepository
{
    private readonly HttpClient _httpClient;

    public GitHubRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<RepositoryResponseModel>> GetRepositories(string organization, int perPage = 30, int page = 1)
    {
        var url = $"https://api.github.com/orgs/{organization}/repos?per_page={perPage}&page={page}";
        var response = await _httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var repositories = JsonConvert.DeserializeObject<List<RepositoryResponseModel>>(content);

        return repositories ?? new List<RepositoryResponseModel>();
    }
}