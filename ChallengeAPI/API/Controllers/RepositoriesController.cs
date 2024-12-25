using ChallengeAPI.Services;
using ChallengeAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeAPI.Controllers;

[ApiController]
[Route("api/repositories")]
public class RepositoriesController : ControllerBase
{
    private readonly IRepositoryService _repositoryService;

    public RepositoriesController(IRepositoryService repositoryService)
    {
        _repositoryService = repositoryService;
    }

    [HttpGet("/repositories/oldest/{organization}")]
    public async Task<IActionResult> GetRepositories(string organization, [FromQuery] int count = 5)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(organization))
                return BadRequest("Organização não informada.");

            if (count > 100)
                return BadRequest("O número máximo permitido de repositórios é 100.");

            var response = await _repositoryService.GetOldestRepositories(organization, count);

            if (response == null || response.Items == null || response.Items.Count == 0)
                return NotFound($"Nenhum repositório encontrado para a organização '{organization}'.");

            return Ok(response);
        }
        catch (HttpRequestException ex)
        {
            if (ex.Message.Contains("403"))
                return StatusCode(403, "Permissão negada. Verifique suas credenciais de autenticação.");
            
            if (ex.Message.Contains("429"))
                return StatusCode(429, "Limite de requisições excedido. Tente novamente mais tarde.");
            
            throw;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex);
            return StatusCode(500, "Erro interno ao obter repositórios.");
        }
    }
}