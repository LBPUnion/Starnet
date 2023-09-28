using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace LBPUnion.Starnet.Types.Entities;

[Serializable]
[MeansImplicitUse(ImplicitUseTargetFlags.WithMembers)]
public class Location
{
    [JsonPropertyName("x")]
    public int X { get; set; }

    [JsonPropertyName("y")]
    public int Y { get; set; }
}