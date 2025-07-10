namespace YoVPM.Yggdrasil.Core.Models.Entity;

public sealed class PackageRepositoryEntity : EntityBase
{
    public required string VpmId { get; set; }
    public required string DisplayName { get; set; }
    public required string DisplayAuthor { get; set; }

    public ICollection<PackageEntity>? Packages { get; set; }
}
