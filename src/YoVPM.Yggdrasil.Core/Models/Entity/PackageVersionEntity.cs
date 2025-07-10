using System.ComponentModel.DataAnnotations;

namespace YoVPM.Yggdrasil.Core.Models.Entity;

public sealed class PackageVersionEntity : EntityBase
{
    public required string Name { get; set; }
    public required string Version { get; set; }

    public string? DisplayName { get; set; }
    public string? Description { get; set; }

    public string? CompatibleUnityVersion { get; set; }
    public string? CompatibleUnityRelease { get; set; }

    public string? ChangeLogUrl { get; set; }
    public string? DocumentationUrl { get; set; }

    public string[] Keywords { get; set; } = [];

    public string? Llicense { get; set; }
    public string? LicenseUrl { get; set; }

    // TODO: Author

    public string? UnityPackageInteralType { get; set; }

    public ICollection<PackageVersionSampleEntity> Samples { get; set; } = [];

    public ICollection<PackageVersionDependencyEntity> Dependencies { get; set; } = [];
    public ICollection<PackageVersionDependencyEntity> VpmDependencies { get; set; } = [];
    public ICollection<PackageVersionDependencyEntity> GitDependencies { get; set; } = [];

    public ICollection<PackageLegacyFileOrFolderEntity> LegacyFiles { get; set; } = [];
    public ICollection<PackageLegacyFileOrFolderEntity> LegacyFolders { get; set; } = [];

    public ICollection<string> LegacyPackages { get; set; } = [];

    public bool? HideInEditor { get; set; }

    public required Guid PackageId { get; set; }
    public required PackageEntity Package { get; set; }

    public required Guid FileId { get; set; }
    public required FileEntity File { get; set; }
}

public sealed class PackageVersionDependencyEntity
{
    [Key]
    public required Guid Id { get; set; } = Guid.CreateVersion7();

    public required string Name { get; set; }
    public required string VersionOrGitUrl { get; set; }
}

public sealed class PackageVersionSampleEntity
{
    [Key]
    public required Guid Id { get; set; } = Guid.CreateVersion7();

    public required string DisplayName { get; set; }
    public required string Description { get; set; }
    public required string Path { get; set; }
}

public sealed class PackageLegacyFileOrFolderEntity
{
    [Key]
    public required Guid Id { get; set; } = Guid.CreateVersion7();

    public required string Path { get; set; }
    public required string ItemGuid { get; set; }
}
