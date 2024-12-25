using ChallengeAPI.Models;

namespace ChallengeAPI.Services;

public interface IRepositoryService
{
    Task<ApiResponse> GetOldestRepositories(string organization, int count);
}