using Riok.Mapperly.Abstractions;
using YoVPM.Yggdrasil.Core.Models.Dto;
using YoVPM.Yggdrasil.Core.Models.Entity;

namespace YoVPM.Yggdrasil.Core.Mappers;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public static partial class RepositoryMapper
{
    public static partial PackageRepositoryResultDto ToPackageRepositoryResultDto(PackageRepositoryEntity entity);

    [MapperIgnoreTarget(nameof(PackageRepositoryEntity.Packages))]
    [MapperIgnoreTarget(nameof(PackageRepositoryEntity.Id))]
    [MapperIgnoreTarget(nameof(PackageRepositoryEntity.CreatedAt))]
    [MapperIgnoreTarget(nameof(PackageRepositoryEntity.UpdatedAt))]
    public static partial PackageRepositoryEntity ToPackageRepositoryEntity(PackageRepositoryDto dto);
}
