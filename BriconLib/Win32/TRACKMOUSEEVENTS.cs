// Decompiled with JetBrains decompiler
// Type: BriconLib.Win32.TRACKMOUSEEVENTS
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.Win32
{
  public struct TRACKMOUSEEVENTS
  {
    public const uint TME_HOVER = 1;
    public const uint TME_LEAVE = 2;
    public const uint TME_NONCLIENT = 16;
    public const uint TME_QUERY = 1073741824;
    public const uint TME_CANCEL = 2147483648;
    public const uint HOVER_DEFAULT = 4294967295;
    private uint cbSize;
    private uint dwFlags;
    private IntPtr hWnd;
    private uint dwHoverTime;

    public TRACKMOUSEEVENTS(uint dwFlags, IntPtr hWnd, uint dwHoverTime)
    {
      this.cbSize = 16U;
      this.dwFlags = dwFlags;
      this.hWnd = hWnd;
      this.dwHoverTime = dwHoverTime;
    }
  }
}
