// Decompiled with JetBrains decompiler
// Type: BriconLib.Win32.FlagsSetWindowPos
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Win32
{
  [Flags]
  public enum FlagsSetWindowPos : uint
  {
    SWP_NOSIZE = 1,
    SWP_NOMOVE = 2,
    SWP_NOZORDER = 4,
    SWP_NOREDRAW = 8,
    SWP_NOACTIVATE = 16, // 0x00000010
    SWP_FRAMECHANGED = 32, // 0x00000020
    SWP_SHOWWINDOW = 64, // 0x00000040
    SWP_HIDEWINDOW = 128, // 0x00000080
    SWP_NOCOPYBITS = 256, // 0x00000100
    SWP_NOOWNERZORDER = 512, // 0x00000200
    SWP_NOSENDCHANGING = 1024, // 0x00000400
    SWP_DRAWFRAME = SWP_FRAMECHANGED, // 0x00000020
    SWP_NOREPOSITION = SWP_NOOWNERZORDER, // 0x00000200
    SWP_DEFERERASE = 8192, // 0x00002000
    SWP_ASYNCWINDOWPOS = 16384, // 0x00004000
  }
}
