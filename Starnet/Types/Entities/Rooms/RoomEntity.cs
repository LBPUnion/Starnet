#nullable disable

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using LBPUnion.Starnet.Types.Enums;

namespace LBPUnion.Starnet.Types.Entities.Rooms;

[Serializable]
[MeansImplicitUse(ImplicitUseTargetFlags.WithMembers)]
public class RoomEntity
{
    private int roomId;

    [JsonPropertyName("roomId")]
    public int RoomId
    {
        get => this.roomId;
        set
        {
            this.RedisId = value.ToString();
            this.roomId = value;
        }
    }

    [JsonPropertyName("redisId")]
    public string RedisId { get; set; }

    [JsonPropertyName("playerIds")]
    public List<int> PlayerIds { get; set; }

    [JsonPropertyName("roomVersion")]
    public GameVersion RoomVersion { get; set; }

    [JsonPropertyName("roomPlatform")]
    public Platform RoomPlatform { get; set; }

    [JsonPropertyName("slot")]
    public RoomSlotEntity Slot { get; set; }

    [JsonPropertyName("state")]
    public RoomState State { get; set; }
}