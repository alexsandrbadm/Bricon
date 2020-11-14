// Decompiled with JetBrains decompiler
// Type: BriconLib.Win32.ShowWindowStyles
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

namespace BriconLib.Win32
{
  public enum ShowWindowStyles : short
  {
    SW_HIDE = 0,
    SW_NORMAL = 1,
    SW_SHOWNORMAL = 1,
    SW_SHOWMINIMIZED = 2,
    SW_MAXIMIZE = 3,
    SW_SHOWMAXIMIZED = 3,
    SW_SHOWNOACTIVATE = 4,
    SW_SHOW = 5,
    SW_MINIMIZE = 6,
    SW_SHOWMINNOACTIVE = 7,
    SW_SHOWNA = 8,
    SW_RESTORE = 9,
    SW_SHOWDEFAULT = 10, // 0x000A
    SW_FORCEMINIMIZE = 11, // 0x000B
    SW_MAX = 11, // 0x000B
  }
}
