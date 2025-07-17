using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YoVPM.Yggdrasil.Core.Data;
using YoVPM.Yggdrasil.Core.Mappers;
using YoVPM.Yggdrasil.Core.Models.Dto;

namespace YoVPM.Yggdrasil.Api.Controllers;

[ApiController]
[Route("repos")]
[ApiVersion("1.0")]
public class RepoController(YggdrasilDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<PackageRepositoryResultDto[]> GetRepos()
    {
        var repos = await dbContext.Repositories.ToArrayAsync();

        return repos.Select(RepositoryMapper.ToPackageRepositoryResultDto).ToArray();
    }

    [HttpGet("{repoVpmId}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType<PackageRepositoryDto>(StatusCodes.Status200OK)]
    public async Task<ActionResult<PackageRepositoryDto>> GetRepo(string repoVpmId)
    {
        var repo = await dbContext.Repositories.SingleOrDefaultAsync(repo => repo.VpmId == repoVpmId);

        if (repo is null)
            return NotFound();

        return Ok(RepositoryMapper.ToPackageRepositoryResultDto(repo));
    }

    [HttpPost]
    [ProducesResponseType<PackageRepositoryDto>(StatusCodes.Status201Created)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PackageRepositoryDto>> CreateRepo([FromBody] PackageRepositoryDto repo)
    {
        var repoEntity = RepositoryMapper.ToPackageRepositoryEntity(repo);

        dbContext.Repositories.Add(repoEntity);
        await dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRepo), new { repoVpmId = repo.VpmId }, repo);
    }
}
