#nullable disable

using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace LBPUnion.Starnet.Entities;

[Serializable]
public class UserEntity
{
    [JsonPropertyName("userId")]
    public int UserId { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("emailAddressVerified")]
    public bool EmailAddressVerified { get; set; }

    [JsonPropertyName("iconHash")]
    public string IconHash { get; set; }

    [JsonPropertyName("biography")]
    public string Biography { get; set; }

    [JsonPropertyName("location")]
    public Location Location { get; set; }

    [JsonPropertyName("yayHash")]
    public string YayHash { get; set; }

    [JsonPropertyName("mehHash")]
    public string MehHash { get; set; }

    [JsonPropertyName("booHash")]
    public string BooHash { get; set; }

    [JsonPropertyName("lastLogin")]
    public long LastLogin { get; set; }

    [JsonPropertyName("lastLogout")]
    public long LastLogout { get; set; }

    [JsonPropertyName("levelVisibility")]
    public PrivacyType LevelVisibility { get; set; }

    [JsonPropertyName("profileVisibility")]
    public PrivacyType ProfileVisibility { get; set; }

    [JsonPropertyName("commentsEnabled")]
    public bool CommentsEnabled { get; set; }

    [JsonPropertyName("permissionLevel")]
    public PermissionLevel PermissionLevel { get; set; }
}

[Serializable]
public class Location
{
    [JsonPropertyName("x")]
    public int X { get; set; }

    [JsonPropertyName("y")]
    public int Y { get; set; }
}

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public enum PrivacyType
{
    PSN = 0,
    Game = 1,
    All = 2,
}

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public enum PermissionLevel
{
    Banned = -3,
    Restricted = -2,
    Silenced = -1,
    Default = 0,
    Moderator = 1,
    Administrator = 2,
}