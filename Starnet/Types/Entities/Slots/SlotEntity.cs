#nullable disable

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using LBPUnion.Starnet.Types.Enums;

namespace LBPUnion.Starnet.Types.Entities.Slots;

[Serializable]
[MeansImplicitUse(ImplicitUseTargetFlags.WithMembers)]
public class SlotEntity
{
    [JsonPropertyName("slotId")]
    public int SlotId { get; set; }

    [JsonPropertyName("internalSlotId")]
    public int InternalSlotId { get; set; }

    [JsonPropertyName("type")]
    public SlotType Type { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("iconHash")]
    public string IconHash { get; set; }

    [JsonPropertyName("isAdventure")]
    public bool IsAdventure { get; set; }

    [JsonPropertyName("creatorId")]
    public int CreatorId { get; set; }

    [JsonPropertyName("intiallyLocked")]
    public bool InitiallyLocked { get; set; }

    [JsonPropertyName("subLevel")]
    public bool SubLevel { get; set; }

    [JsonPropertyName("lbp1Only")]
    public bool Lbp1Only { get; set; }

    [JsonPropertyName("shareable")]
    public int Shareable { get; set; }

    [JsonPropertyName("authorLabels")]
    public string AuthorLabels { get; set; }

    [JsonPropertyName("levelTags")]
    public string[] LevelTags { get; set; }

    [JsonPropertyName("minimumPlayers")]
    public int MinimumPlayers { get; set; }

    [JsonPropertyName("maximumPlayers")]
    public int MaximumPlayers { get; set; }

    [JsonPropertyName("moveRequired")]
    public bool MoveRequired { get; set; }

    [JsonPropertyName("firstUploaded")]
    public long FirstUploaded { get; set; }

    [JsonPropertyName("lastUpdated")]
    public long LastUpdated { get; set; }

    [JsonPropertyName("teamPick")]
    public bool TeamPick { get; set; }

    [JsonPropertyName("location")]
    public Location Location { get; set; }

    [JsonPropertyName("gameVersion")]
    public GameVersion GameVersion { get; set; }

    [JsonPropertyName("plays")]
    public int Plays { get; set; }

    [JsonPropertyName("playsUnique")]
    public int PlaysUnique { get; set; }

    [JsonPropertyName("playsComplete")]
    public int PlaysComplete { get; set; }

    [JsonPropertyName("commentsEnabled")]
    public bool CommentsEnabled { get; set; }

    [JsonPropertyName("averageRating")]
    public double AverageRating { get; set; }

    [JsonPropertyName("levelType")]
    public string LevelType { get; set; }
}