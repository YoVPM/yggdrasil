using Riok.Mapperly.Abstractions;
using YoVPM.Yggdrasil.Core.Models.Dto;
using YoVPM.Yggdrasil.Core.Models.Entity;

namespace YoVPM.Yggdrasil.Core.Mappers;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public static partial class PackageVersionMapper
{
    public static partial PackageVersionDto ToPackageVersionDto(PackageVersionEntity packageVersionEntity);

    // These value will be generating automatically (by the ctor())
    [MapperIgnoreTarget(nameof(PackageVersionEntity.CreatedAt))]
    [MapperIgnoreTarget(nameof(PackageVersionEntity.UpdatedAt))]
    [MapperIgnoreTarget(nameof(PackageVersionEntity.Id))]
    // Safe to ignore (navigation properties)
    [MapperIgnoreTarget(nameof(PackageVersionEntity.Package))]
    [MapperIgnoreTarget(nameof(PackageVersionEntity.File))]
    public static partial PackageVersionEntity ToPackageVersionEntity(PackageVersionDto packageVersionDto, Guid packageId, Guid fileId);

    public static KeyValuePair<string, string> ToKeyValuePair(PackageVersionDependencyEntity dependencyEntity)
    {
        return new KeyValuePair<string, string>(dependencyEntity.Name, dependencyEntity.VersionOrGitUrl);
    }

    public static KeyValuePair<string, string> ToKeyValuePair(PackageLegacyFileOrFolderEntity dependencyEntity)
    {
        return new KeyValuePair<string, string>(dependencyEntity.Path, dependencyEntity.ItemGuid);
    }

    public static PackageVersionDependencyEntity ToPackageVersionDependencyEntity(KeyValuePair<string, string> pair)
    {
        return new PackageVersionDependencyEntity()
        {
            Id = Guid.CreateVersion7(),
            Name = pair.Key,
            VersionOrGitUrl = pair.Value
        };
    }

    public static PackageLegacyFileOrFolderEntity ToPackageLegacyFileOrFolderEntity(KeyValuePair<string, string> pair)
    {
        return new PackageLegacyFileOrFolderEntity()
        {
            Id = Guid.CreateVersion7(),
            Path = pair.Key,
            ItemGuid = pair.Value
        };
    }

    public static PackageVersionSampleEntity ToPackageVersionSampleEntity(PackageVersionSampleDto sampleDto)
    {
        return new PackageVersionSampleEntity()
        {
            Id = Guid.CreateVersion7(),
            DisplayName = sampleDto.DisplayName,
            Description = sampleDto.Description,
            Path = sampleDto.Path
        };
    }
}
