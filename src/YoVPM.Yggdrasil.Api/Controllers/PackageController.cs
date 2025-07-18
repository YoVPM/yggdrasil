using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YoVPM.Yggdrasil.Core.Data;
using YoVPM.Yggdrasil.Core.Mappers;
using YoVPM.Yggdrasil.Core.Models.Dto;

namespace YoVPM.Yggdrasil.Api.Controllers;

[ApiController]
[Route("repo/{repoVpmId}/packages")]
[ApiVersion("1.0")]
public class PackageController(YggdrasilDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PackageDtoBase[]>> GetRepoPackages(string repoVpmId)
    {
        if (await dbContext.Repositories.SingleOrDefaultAsync(r => r.VpmId == repoVpmId) is not { } repo)
            return NotFound();

        var packages = await dbContext.Packages.Where(package => package.RepositoryId == repo.Id).ToArrayAsync();

        return packages.Select(PackageMapper.ToPackageDto).ToArray();
    }

    [HttpGet("{packageName}")]
    public async Task<ActionResult<PackageDtoBaseWithVersion>> GetRepoPackage(string repoVpmId, string packageName)
    {
        if (await dbContext.Repositories.SingleOrDefaultAsync(r => r.VpmId == repoVpmId) is not { } repo)
            return NotFound();

        var package = await dbContext.Packages
            .Where(p => p.RepositoryId == repo.Id && p.Name == packageName)
            .SingleOrDefaultAsync();

        if (package is null)
            return NotFound();

        var packageVersions = await dbContext.PackageVersions
            .Where(pv => pv.PackageId == package.Id)
            .ToArrayAsync();

        var packageVersionsDto = packageVersions
            .Select(PackageVersionMapper.ToPackageVersionDto)
            .ToArray();

        return PackageMapper.ToPackageDtoWithVersion(package, packageVersionsDto);
    }

    [HttpPost]
    public async Task<ActionResult> CreatePackage(string repoVpmId, [FromBody] PackageDtoBase packageDtoBase)
    {
        if (await dbContext.Repositories.SingleOrDefaultAsync(r => r.VpmId == repoVpmId) is not { } repo)
            return NotFound();

        if (await dbContext.Packages.AnyAsync(p => p.RepositoryId == repo.Id && p.Name == packageDtoBase.Name))
            return Conflict("Package already exists in the repository.");

        var package = PackageMapper.ToPackageEntity(packageDtoBase, repo.Id);
        dbContext.Packages.Add(package);
        await dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRepoPackage), new { repoVpmId, packageName = package.Name }, packageDtoBase);
    }
}
