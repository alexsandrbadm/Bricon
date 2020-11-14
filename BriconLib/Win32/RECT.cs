// Decompiled with JetBrains decompiler
// Type: BriconLib.Win32.RECT
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

namespace BriconLib.Win32
{
  public struct RECT
  {
    public int left;
    public int top;
    public int right;
    public int bottom;

    public override string ToString() => "{left=" + this.left.ToString() + ", top=" + this.top.ToString() + ", right=" + this.right.ToString() + ", bottom=" + this.bottom.ToString() + "}";
  }
}
