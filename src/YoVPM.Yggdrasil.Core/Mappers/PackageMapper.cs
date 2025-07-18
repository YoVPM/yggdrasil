using Riok.Mapperly.Abstractions;
using YoVPM.Yggdrasil.Core.Models.Dto;
using YoVPM.Yggdrasil.Core.Models.Entity;

namespace YoVPM.Yggdrasil.Core.Mappers;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public static partial class PackageMapper
{
    public static partial PackageDtoBase ToPackageDto(PackageEntity packageEntity);

    public static partial PackageDtoBaseWithVersion ToPackageDtoWithVersion(PackageEntity packageEntity, PackageVersionDto[] versions);

    // These value will be generating automatically (by the ctor())
    [MapperIgnoreTarget(nameof(PackageVersionEntity.CreatedAt))]
    [MapperIgnoreTarget(nameof(PackageVersionEntity.UpdatedAt))]
    [MapperIgnoreTarget(nameof(PackageVersionEntity.Id))]
    // Safe to ignore (navigation properties)
    [MapperIgnoreTarget(nameof(PackageEntity.Repository))]
    [MapperIgnoreTarget(nameof(PackageEntity.Versions))]
    // Safe to keep it null
    [MapperIgnoreTarget(nameof(PackageEntity.LatestVersion))]
    public static partial PackageEntity ToPackageEntity(PackageDtoBase packageDtoBase, Guid repositoryId);

    // // These value will be generating automatically (by the ctor())
    // [MapperIgnoreTarget(nameof(PackageEntity.CreatedAt))]
    // [MapperIgnoreTarget(nameof(PackageEntity.UpdatedAt))]
    // [MapperIgnoreTarget(nameof(PackageEntity.Id))]
    // // Safe to ignore (navigation properties)
    // [MapperIgnoreTarget(nameof(PackageEntity.Repository))]
    // public static partial PackageEntity ToPackageEntity(PackageDto packageDto, Guid repositoryId);
}
