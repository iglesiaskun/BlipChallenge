using ChallengeAPI.Models;
using ChallengeAPI.Repositories;

namespace ChallengeAPI.Services;

public class RepositoryService : IRepositoryService
{
    private readonly IGitHubRepository _gitHubRepository;

    public RepositoryService(IGitHubRepository gitHubRepository)
    {
        _gitHubRepository = gitHubRepository;
    }

    public async Task<ApiResponse> GetOldestRepositories(string organization, int count)
    {
        var allRepositories = new List<RepositoryResponseModel>();
        int perPage = 100;
        int page = 1;

        while (true)
        {
            var repositories = await _gitHubRepository.GetRepositories(organization, perPage, page);

            if (!repositories.Any())
                break;

            allRepositories.AddRange(repositories);
            page++;
        }
        
        var response = new ApiResponse
        {
            Items = allRepositories
                .OrderBy(repo => repo.CreatedAt)
                .Take(count)
                .Select(repo => new ApiItem
                {
                    Header = new ApiHeader
                    {
                        Value = new ApiValue
                        {
                            Title = repo.Name,
                            Text = repo.Description,
                            Uri = repo.Owner.AvatarUrl
                        }
                    }
                }).ToList()
        };

        return response;
    }
}