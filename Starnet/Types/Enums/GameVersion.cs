using System.Diagnostics.CodeAnalysis;

namespace LBPUnion.Starnet.Types.Enums;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public enum GameVersion
{
    LittleBigPlanet1 = 0,
    LittleBigPlanet2 = 1,
    LittleBigPlanet3 = 2,
    LittleBigPlanetVita = 3,
    LittleBigPlanetPSP = 4,
    Unknown = -1,
}