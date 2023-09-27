#nullable disable

using JetBrains.Annotations;
using LBPUnion.Starnet.Types.Enums;

namespace LBPUnion.Starnet.Types.Entities.RichPresence;

[PublicAPI]
[Serializable]
public class RichPresenceEntity
{
    public string ApplicationId { get; set; }
    public string PartyIdPrefix { get; set; }
    public UsernameType UsernameType { get; set; }
    public RichPresenceAssetsEntity Assets { get; set; }    
}