using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace LBPUnion.Starnet.Types.Entities.Statistics;

[Serializable]
[MeansImplicitUse(ImplicitUseTargetFlags.WithMembers)]
public class StatisticsEntity
{
    [JsonPropertyName("recentMatches")]
    public int RecentMatches { get; set; }

    [JsonPropertyName("slots")]
    public int Slots { get; set; }

    [JsonPropertyName("users")]
    public int Users { get; set; }

    [JsonPropertyName("teamPicks")]
    public int TeamPicks { get; set; }

    [JsonPropertyName("photos")]
    public int Photos { get; set; }
}