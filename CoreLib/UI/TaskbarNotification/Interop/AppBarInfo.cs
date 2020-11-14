// Decompiled with JetBrains decompiler
// Type: CoreLib.UI.TaskbarNotification.Interop.AppBarInfo
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CoreLib.UI.TaskbarNotification.Interop
{
  internal class AppBarInfo
  {
    private const int ABE_BOTTOM = 3;
    private const int ABE_LEFT = 0;
    private const int ABE_RIGHT = 2;
    private const int ABE_TOP = 1;
    private const int ABM_GETTASKBARPOS = 5;
    private const uint SPI_GETWORKAREA = 48;
    private AppBarInfo.APPBARDATA m_data;

    [DllImport("user32.dll")]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("shell32.dll")]
    private static extern uint SHAppBarMessage(uint dwMessage, ref AppBarInfo.APPBARDATA data);

    [DllImport("user32.dll")]
    private static extern int SystemParametersInfo(
      uint uiAction,
      uint uiParam,
      IntPtr pvParam,
      uint fWinIni);

    public AppBarInfo.ScreenEdge Edge => (AppBarInfo.ScreenEdge) this.m_data.uEdge;

    public Rectangle WorkArea
    {
      get
      {
        AppBarInfo.RECT rect = new AppBarInfo.RECT();
        IntPtr num1 = Marshal.AllocHGlobal(Marshal.SizeOf((object) rect));
        int num2 = AppBarInfo.SystemParametersInfo(48U, 0U, num1, 0U);
        AppBarInfo.RECT structure = (AppBarInfo.RECT) Marshal.PtrToStructure(num1, rect.GetType());
        if (num2 != 1)
          return new Rectangle(0, 0, 0, 0);
        Marshal.FreeHGlobal(num1);
        return new Rectangle(structure.left, structure.top, structure.right - structure.left, structure.bottom - structure.top);
      }
    }

    public void GetPosition(string strClassName, string strWindowName)
    {
      this.m_data = new AppBarInfo.APPBARDATA();
      this.m_data.cbSize = (uint) Marshal.SizeOf(this.m_data.GetType());
      if (!(AppBarInfo.FindWindow(strClassName, strWindowName) != IntPtr.Zero))
        throw new Exception("Failed to find an AppBar that matched the given criteria");
      if (AppBarInfo.SHAppBarMessage(5U, ref this.m_data) != 1U)
        throw new Exception("Failed to communicate with the given AppBar");
    }

    public void GetSystemTaskBarPosition() => this.GetPosition("Shell_TrayWnd", (string) null);

    public enum ScreenEdge
    {
      Undefined = -1, // 0xFFFFFFFF
      Left = 0,
      Top = 1,
      Right = 2,
      Bottom = 3,
    }

    private struct APPBARDATA
    {
      public uint cbSize;
      public IntPtr hWnd;
      public uint uCallbackMessage;
      public uint uEdge;
      public AppBarInfo.RECT rc;
      public int lParam;
    }

    private struct RECT
    {
      public int left;
      public int top;
      public int right;
      public int bottom;
    }
  }
}
