// Decompiled with JetBrains decompiler
// Type: BriconLib.Win32.TrackerEventFlags
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

namespace BriconLib.Win32
{
  public enum TrackerEventFlags : uint
  {
    TME_HOVER = 1,
    TME_LEAVE = 2,
    TME_QUERY = 1073741824, // 0x40000000
    TME_CANCEL = 2147483648, // 0x80000000
  }
}
