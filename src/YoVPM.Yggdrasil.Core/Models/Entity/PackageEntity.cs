﻿namespace YoVPM.Yggdrasil.Core.Models.Entity;

public sealed class PackageEntity : EntityBase
{
    public required string Name { get; set; }

    public string? DisplayName { get; set; }
    public string? Description { get; set; }

    public required string AuthorName { get; set; }
    public required string AuthorEmail { get; set; }
    public string? AuthorUrl { get; set; }

    public string? CompatibleUnityVersion { get; set; }
    public string? CompatibleUnityRelease { get; set; }

    public string[] Keywords { get; set; } = [];

    public string? License { get; set; }

    public string? UnityPackageInternalType { get; set; }

    public bool? HideInEditor { get; set; }

    public PackageRepositoryEntity? Repository { get; set; }
    public required Guid RepositoryId { get; set; }

    public string? LatestVersion { get; set; }

    public ICollection<PackageVersionEntity>? Versions { get; set; }
}
