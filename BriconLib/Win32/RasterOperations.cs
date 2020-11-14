// Decompiled with JetBrains decompiler
// Type: BriconLib.Win32.RasterOperations
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

namespace BriconLib.Win32
{
  public enum RasterOperations : uint
  {
    BLACKNESS = 66, // 0x00000042
    NOTSRCERASE = 1114278, // 0x001100A6
    NOTSRCCOPY = 3342344, // 0x00330008
    SRCERASE = 4457256, // 0x00440328
    DSTINVERT = 5570569, // 0x00550009
    PATINVERT = 5898313, // 0x005A0049
    SRCINVERT = 6684742, // 0x00660046
    SRCAND = 8913094, // 0x008800C6
    MERGEPAINT = 12255782, // 0x00BB0226
    MERGECOPY = 12583114, // 0x00C000CA
    SRCCOPY = 13369376, // 0x00CC0020
    SRCPAINT = 15597702, // 0x00EE0086
    PATCOPY = 15728673, // 0x00F00021
    PATPAINT = 16452105, // 0x00FB0A09
    WHITENESS = 16711778, // 0x00FF0062
  }
}
