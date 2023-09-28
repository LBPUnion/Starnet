using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace LBPUnion.Starnet.Types.Entities.RichPresence;

[Serializable]
[MeansImplicitUse(ImplicitUseTargetFlags.WithMembers)]
public class RichPresenceAssetsEntity
{
    [JsonPropertyName("useApplicationAssets")]
    public bool UseApplicationAssets { get; set; }

    [JsonPropertyName("podAsset")]
    public string? PodAsset { get; set; }

    [JsonPropertyName("moonAsset")]
    public string? MoonAsset { get; set; }

    [JsonPropertyName("remoteMoonAsset")]
    public string? RemoteMoonAsset { get; set; }

    [JsonPropertyName("developerAsset")]
    public string? DeveloperAsset { get; set; }

    [JsonPropertyName("developerAdventureAsset")]
    public string? DeveloperAdventureAsset { get; set; }

    [JsonPropertyName("dlcAsset")]
    public string? DlcAsset { get; set; }

    [JsonPropertyName("fallbackAsset")]
    public string? FallbackAsset { get; set; }
}