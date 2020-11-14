// Decompiled with JetBrains decompiler
// Type: BriconLib.Win32.ProtectionLevel
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

namespace BriconLib.Win32
{
  public enum ProtectionLevel
  {
    PAGE_NOACCESS = 1,
    PAGE_READONLY = 2,
    PAGE_READWRITE = 4,
    PAGE_WRITECOPY = 8,
    PAGE_EXECUTE = 16, // 0x00000010
  }
}
