// Decompiled with JetBrains decompiler
// Type: BriconLib.Win32.FlagsAnimateWindow
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Win32
{
  [Flags]
  public enum FlagsAnimateWindow : uint
  {
    AW_HOR_POSITIVE = 1,
    AW_HOR_NEGATIVE = 2,
    AW_VER_POSITIVE = 4,
    AW_VER_NEGATIVE = 8,
    AW_CENTER = 16, // 0x00000010
    AW_HIDE = 65536, // 0x00010000
    AW_ACTIVATE = 131072, // 0x00020000
    AW_SLIDE = 262144, // 0x00040000
    AW_BLEND = 524288, // 0x00080000
  }
}
