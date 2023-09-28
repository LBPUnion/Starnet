#nullable disable

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using LBPUnion.Starnet.Types.Enums;

namespace LBPUnion.Starnet.Types.Entities.RichPresence;

[Serializable]
[MeansImplicitUse(ImplicitUseTargetFlags.WithMembers)]
public class RichPresenceEntity
{
    [JsonPropertyName("applicationId")]
    public string ApplicationId { get; set; }

    [JsonPropertyName("partyIdPrefix")]
    public string PartyIdPrefix { get; set; }

    [JsonPropertyName("usernameType")]
    public UsernameType UsernameType { get; set; }

    [JsonPropertyName("assets")]
    public RichPresenceAssetsEntity Assets { get; set; }    
}