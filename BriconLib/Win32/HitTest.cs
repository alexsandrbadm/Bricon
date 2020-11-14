// Decompiled with JetBrains decompiler
// Type: BriconLib.Win32.HitTest
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

namespace BriconLib.Win32
{
  public enum HitTest
  {
    HTERROR = -2, // 0xFFFFFFFE
    HTTRANSPARENT = -1, // 0xFFFFFFFF
    HTNOWHERE = 0,
    HTCLIENT = 1,
    HTCAPTION = 2,
    HTSYSMENU = 3,
    HTGROWBOX = 4,
    HTSIZE = 4,
    HTMENU = 5,
    HTHSCROLL = 6,
    HTVSCROLL = 7,
    HTMINBUTTON = 8,
    HTREDUCE = 8,
    HTMAXBUTTON = 9,
    HTZOOM = 9,
    HTLEFT = 10, // 0x0000000A
    HTSIZEFIRST = 10, // 0x0000000A
    HTRIGHT = 11, // 0x0000000B
    HTTOP = 12, // 0x0000000C
    HTTOPLEFT = 13, // 0x0000000D
    HTTOPRIGHT = 14, // 0x0000000E
    HTBOTTOM = 15, // 0x0000000F
    HTBOTTOMLEFT = 16, // 0x00000010
    HTBOTTOMRIGHT = 17, // 0x00000011
    HTSIZELAST = 17, // 0x00000011
    HTBORDER = 18, // 0x00000012
    HTOBJECT = 19, // 0x00000013
    HTCLOSE = 20, // 0x00000014
    HTHELP = 21, // 0x00000015
  }
}
