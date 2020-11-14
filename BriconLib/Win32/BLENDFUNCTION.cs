// Decompiled with JetBrains decompiler
// Type: BriconLib.Win32.BLENDFUNCTION
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System.Runtime.InteropServices;

namespace BriconLib.Win32
{
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct BLENDFUNCTION
  {
    public byte BlendOp;
    public byte BlendFlags;
    public byte SourceConstantAlpha;
    public byte AlphaFormat;
  }
}
