using System.ComponentModel.DataAnnotations;

namespace YoVPM.Yggdrasil.Core.Models.Entity;

public abstract class EntityBase : EntityBaseWithoutId
{
    [Key]
    public Guid Id { get; set; } = Guid.CreateVersion7();
}

public abstract class EntityBaseWithoutId
{
    public DateTimeOffset CreatedAt { get; set; } = TimeProvider.System.GetUtcNow();
    public DateTimeOffset UpdatedAt { get; set; } = TimeProvider.System.GetUtcNow();
}
