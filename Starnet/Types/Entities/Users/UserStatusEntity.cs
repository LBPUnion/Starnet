using System.Text.Json.Serialization;
using JetBrains.Annotations;
using LBPUnion.Starnet.Types.Entities.Rooms;
using LBPUnion.Starnet.Types.Enums;

namespace LBPUnion.Starnet.Types.Entities.Users;

[Serializable]
[MeansImplicitUse(ImplicitUseTargetFlags.WithMembers)]
public class UserStatusEntity
{
    [JsonPropertyName("statusType")]
    public StatusType StatusType { get; set; }

    [JsonPropertyName("currentVersion")]
    public GameVersion? CurrentVersion { get; set; }

    [JsonPropertyName("currentPlatform")]
    public Platform? CurrentPlatform { get; set; }

    [JsonPropertyName("currentRoom")]
    public RoomEntity? CurrentRoom { get; set; }

    [JsonPropertyName("lastLogin")]
    public long LastLogin { get; set; }

    [JsonPropertyName("lastLogout")]
    public long LastLogout { get; set; }
}