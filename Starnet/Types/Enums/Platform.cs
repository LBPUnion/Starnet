using System.Diagnostics.CodeAnalysis;

namespace LBPUnion.Starnet.Types.Enums;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public enum Platform
{
    PS3 = 0,
    RPCS3 = 1,
    Vita = 2,
    PSP = 3,
    UnitTest = 4,
    Unknown = -1,
}