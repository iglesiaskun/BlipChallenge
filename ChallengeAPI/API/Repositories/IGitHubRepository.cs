using ChallengeAPI.Models;

namespace ChallengeAPI.Repositories;

public interface IGitHubRepository
{
    Task<IEnumerable<RepositoryResponseModel>> GetRepositories(string organization, int perPage, int page);
}