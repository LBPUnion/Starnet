using System.Text.Json.Serialization;
using JetBrains.Annotations;
using LBPUnion.Starnet.Types.Enums;

namespace LBPUnion.Starnet.Types.Entities.Rooms;

[PublicAPI]
[Serializable]
public class RoomSlotEntity
{
    public static readonly RoomSlotEntity PodSlot = new()
    {
        SlotType = SlotType.Pod,
        SlotId = 0,
    };

    [JsonPropertyName("slotId")]
    public int SlotId { get; set; }

    [JsonPropertyName("slotType")]
    public SlotType SlotType { get; set; }
}