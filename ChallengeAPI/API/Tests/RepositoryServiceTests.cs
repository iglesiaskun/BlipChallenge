using ChallengeAPI.Repositories;
using ChallengeAPI.Services;
using ChallengeAPI.Utils;
using Xunit;

namespace ChallengeAPI.Tests;
public class RepositoryServiceTests
{
    [Fact]
    public async Task GetOldestRepositories_ShouldReturnFiveRepositories_WhenOrganizationIsTakenet()
    {
        using (var httpClient = new HttpClient())
        {
            var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN");
            
            if (string.IsNullOrEmpty(token))
                throw new InvalidOperationException("Bearer token não configurado. Configure a variável de ambiente GITHUB_TOKEN.");

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("ChallengeApi");

            var gitHubRepository = new GitHubRepository(httpClient);
            var repositoryService = new RepositoryService(gitHubRepository);

            var result = await repositoryService.GetOldestRepositories("takenet", 5);

            Assert.NotNull(result);
            Assert.NotNull(result.Items);

            Assert.Equal(5, result.Items.Count);

            foreach (var item in result.Items)
            {
                Assert.NotNull(item.Header);
                Assert.NotNull(item.Header.Value);

                Assert.False(string.IsNullOrEmpty(item.Header.Value.Title));
                Assert.False(string.IsNullOrEmpty(item.Header.Value.Text));
                Assert.False(string.IsNullOrEmpty(item.Header.Value.Uri));

                Logger.LogInfo($"Repo: {item.Header.Value.Title}, Descrição: {item.Header.Value.Text}, Avatar URL: {item.Header.Value.Uri}.");
            }
        }
    }
    
    [Fact]
    public async Task TestGitHubApiConnection_ReturnsSuccess()
    {
        using (var httpClient = new HttpClient())
        {
            var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN");
            
            if (string.IsNullOrEmpty(token))
                throw new InvalidOperationException("Bearer token não configurado. Configure a variável de ambiente GITHUB_TOKEN.");

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("ChallengeApi");

            const string url = "https://api.github.com/";

            var response = await httpClient.GetAsync(url);

            Assert.True(response.IsSuccessStatusCode, "Falha na conexão com a API do GitHub. Verifique o token.");

            var content = await response.Content.ReadAsStringAsync();
            
            Assert.False(string.IsNullOrEmpty(content), "O conteúdo retornado pela API está vazio.");

            Logger.LogInfo("Conectado a API do GitHub.");
        }
    }
}