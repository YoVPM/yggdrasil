using System.ComponentModel.DataAnnotations;

namespace YoVPM.Yggdrasil.Core.Models.Dto;

public class PackageRepositoryDto
{
    [Required] public required string VpmId { get; set; }
    [Required] public required string DisplayName { get; set; }
    [Required] public required string DisplayAuthor { get; set; }
}

public class PackageRepositoryResultDto : PackageRepositoryDto
{
    public required DateTimeOffset CreatedAt { get; set; }
    public required DateTimeOffset UpdatedAt { get; set; }
}
