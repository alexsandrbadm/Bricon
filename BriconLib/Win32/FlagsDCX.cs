// Decompiled with JetBrains decompiler
// Type: BriconLib.Win32.FlagsDCX
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Win32
{
  [Flags]
  public enum FlagsDCX : uint
  {
    DCX_WINDOW = 1,
    DCX_CACHE = 2,
    DCX_NORESETATTRS = 4,
    DCX_CLIPCHILDREN = 8,
    DCX_CLIPSIBLINGS = 16, // 0x00000010
    DCX_PARENTCLIP = 32, // 0x00000020
    DCX_EXCLUDERGN = 64, // 0x00000040
    DCX_INTERSECTRGN = 128, // 0x00000080
    DCX_EXCLUDEUPDATE = 256, // 0x00000100
    DCX_INTERSECTUPDATE = 512, // 0x00000200
    DCX_LOCKWINDOWUPDATE = 1024, // 0x00000400
    DCX_NORECOMPUTE = 1048576, // 0x00100000
    DCX_VALIDATE = 2097152, // 0x00200000
  }
}
