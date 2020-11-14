// Decompiled with JetBrains decompiler
// Type: BriconLib.Win32.Gdi32
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.Runtime.InteropServices;

namespace BriconLib.Win32
{
  public class Gdi32
  {
    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    public static extern int CombineRgn(IntPtr dest, IntPtr src1, IntPtr src2, int flags);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr CreateRectRgnIndirect(ref RECT rect);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    public static extern bool FillRgn(IntPtr hDC, IntPtr hrgn, IntPtr hBrush);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    public static extern int GetClipBox(IntPtr hDC, ref RECT rectBox);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    public static extern int SelectClipRgn(IntPtr hDC, IntPtr hRgn);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr CreateBrushIndirect(ref LOGBRUSH brush);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    public static extern bool PatBlt(
      IntPtr hDC,
      int x,
      int y,
      int width,
      int height,
      uint flags);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr DeleteObject(IntPtr hObject);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    public static extern bool DeleteDC(IntPtr hDC);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
  }
}
