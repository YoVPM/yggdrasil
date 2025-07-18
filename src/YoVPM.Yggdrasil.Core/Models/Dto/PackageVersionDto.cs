using System.Text.Json.Serialization;

namespace YoVPM.Yggdrasil.Core.Models.Dto;

public class PackageVersionDto
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    [JsonPropertyName("displayName")]
    public required string DisplayName { get; set; }
    [JsonPropertyName("version")]
    public required string Version { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    public required string AuthorName { get; set; }
    public required string AuthorEmail { get; set; }
    public string? AuthorUrl { get; set; }

    [JsonPropertyName("unity")]
    public string? CompatibleUnityVersion { get; set; }
    [JsonPropertyName("unityRelease")]
    public string? CompatibleUnityRelease { get; set; }

    [JsonPropertyName("changelogUrl")]
    public string? ChangeLogUrl { get; set; }
    [JsonPropertyName("documentationUrl")]
    public string? DocumentationUrl { get; set; }

    [JsonPropertyName("keywords")]
    public string[]? Keywords { get; set; } = [];

    [JsonPropertyName("license")]
    public string? License { get; set; }
    [JsonPropertyName("licensesUrl")]
    public string? LicenseUrl { get; set; }

    [JsonPropertyName("type")]
    public string? UnityPackageInternalType { get; set; }

    [JsonPropertyName("hideInEditor")]
    public bool? HideInEditor { get; set; }

    [JsonPropertyName("samples")]
    public PackageVersionSampleDto[]? Samples { get; set; } = [];

    [JsonPropertyName("dependencies")]
    public Dictionary<string, string>? Dependencies { get; set; } = new();
    [JsonPropertyName("vpmDependencies")]
    public Dictionary<string, string>? VpmDependencies { get; set; } = new();
    [JsonPropertyName("gitDependencies")]
    public Dictionary<string, string>? GitDependencies { get; set; } = new();

    [JsonPropertyName("legacyPackages")]
    public string[]? LegacyPackages { get; set; } = [];
    [JsonPropertyName("legacyFolders")]
    public Dictionary<string, string>? LegacyFolders { get; set; } = new();
    [JsonPropertyName("legacyFiles")]
    public Dictionary<string, string>? LegacyFiles { get; set; } = new();
}

public class PackageVersionSampleDto
{
    [JsonPropertyName("displayName")]
    public required string DisplayName { get; set; }
    [JsonPropertyName("description")]
    public required string Description { get; set; }
    [JsonPropertyName("path")]
    public required string Path { get; set; }
}
