using System.Diagnostics.CodeAnalysis;

namespace LBPUnion.Starnet.Types.Enums;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public enum RoomState
{
    Idle = 0,
    PlayingLevel = 1,
    Unknown = 2,
    DivingIn = 3,
    DivingInWaiting = 4,
}