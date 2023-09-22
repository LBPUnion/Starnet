using System.Diagnostics.CodeAnalysis;

namespace LBPUnion.Starnet.Types.Enums;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public enum SlotType
{
    Developer = 0,
    User = 1,
    Moon = 2,
    Unknown = 3,
    Unknown2 = 4,
    Pod = 5,
    Local = 6,
    DLC = 8,
}