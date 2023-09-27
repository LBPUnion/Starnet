using JetBrains.Annotations;

namespace LBPUnion.Starnet.Types.Entities.RichPresence;

[PublicAPI]
[Serializable]
public class RichPresenceAssetsEntity
{
    public bool UseApplicationAssets { get; init; }
    public string? PodAsset { get; init; }
    public string? MoonAsset { get; init; }
    public string? RemoteMoonAsset { get; init; }
    public string? DeveloperAsset { get; init; }
    public string? DeveloperAdventureAsset { get; init; }
    public string? DlcAsset { get; init; }
    public string? FallbackAsset { get; init; }
}