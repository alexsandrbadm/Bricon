// Decompiled with JetBrains decompiler
// Type: BriconLib.Win32.DialogCodes
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

namespace BriconLib.Win32
{
  public enum DialogCodes
  {
    DLGC_WANTARROWS = 1,
    DLGC_WANTTAB = 2,
    DLGC_WANTALLKEYS = 4,
    DLGC_WANTMESSAGE = 4,
    DLGC_HASSETSEL = 8,
    DLGC_DEFPUSHBUTTON = 16, // 0x00000010
    DLGC_UNDEFPUSHBUTTON = 32, // 0x00000020
    DLGC_RADIOBUTTON = 64, // 0x00000040
    DLGC_WANTCHARS = 128, // 0x00000080
    DLGC_STATIC = 256, // 0x00000100
    DLGC_BUTTON = 8192, // 0x00002000
  }
}
