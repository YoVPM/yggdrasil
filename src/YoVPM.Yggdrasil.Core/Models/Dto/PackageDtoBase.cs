using System.ComponentModel.DataAnnotations;

namespace YoVPM.Yggdrasil.Core.Models.Dto;

public class PackageDtoBase
{
    [Required]
    public required string Name { get; set; }

    public string? DisplayName { get; set; }
    public string? Description { get; set; }

    [Required]
    public required string AuthorName { get; set; }
    [Required]
    public required string AuthorEmail { get; set; }
    public string? AuthorUrl { get; set; }

    public string? CompatibleUnityVersion { get; set; }
    public string? CompatibleUnityRelease { get; set; }

    public string[] Keywords { get; set; } = [];

    public string? License { get; set; }

    public string? UnityPackageInternalType { get; set; }

    public bool? HideInEditor { get; set; }
}

public class PackageDto : PackageDtoBase
{
    public string? LatestVersion { get; set; }
}

public class PackageDtoBaseWithVersion : PackageDto
{
    public PackageVersionDto[] Versions { get; set; } = [];
}
