namespace YoVPM.Yggdrasil.Core.Models.Entity;

public sealed class FileEntity : EntityBase
{
    public required string Name { get; set; }
    public required string Hash { get; set; }
    public required string StorageKey { get; set; }
}
